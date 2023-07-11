using UnityEngine;

public class ReachOrder : MonoBehaviour
{
    [SerializeField] Ordercenter ordercenter;

    [SerializeField] GameObject particlefirework;
    [SerializeField] GameObject particlestar;

    GameObject houseA;
    GameObject houseB;

    int numberA;
    int numberB;

    [Header("Sound")]
    [SerializeField] AudioSource star;
    [SerializeField] AudioSource gepack;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "House")
        {
            if (houseA == null)
            {
                if (collision.transform.gameObject.GetComponent<SignupOrder>().packagetype == "sender")
                {
                    houseA = collision.transform.gameObject;
                    numberA = houseA.GetComponent<SignupOrder>().packagecode;

                    houseA.GetComponent<Collider2D>().enabled = false;
                    houseA.GetComponent<FadeEffect>().FadeOUT();

                    ordercenter.ReceivePackage(houseA);

                    Vector3 fireworkpos = houseA.transform.position;
                    fireworkpos.z = -5f;
                    particlefirework.transform.position = fireworkpos;
                    particlefirework.GetComponent<Animator>().SetTrigger("isWorking");

                    //deliveryman
                    transform.Find("package").gameObject.SetActive(true);
                    transform.Find("package").GetComponent<SpriteRenderer>().color
                    = houseA.GetComponent<SignupOrder>().wrapcolor;

                    //tip for packageB
                    ordercenter.Tipp(numberA);

                    //sound
                    gepack.Play();

                    Debug.Log("Get PackageA");
                }              
            }
            if(houseA != null && houseB == null)
            {
                if (collision.transform.gameObject.GetComponent<SignupOrder>().packagetype == "recipient")
                {
                    houseB = collision.transform.gameObject;
                    numberB = houseB.GetComponent<SignupOrder>().packagecode;
                    Debug.Log("Find PackageB");
                }

                CheckPackage();
            }
        }
    }


    bool CheckPackage()
    {
        if(numberA == numberB)
        {
            //paticle
            ordercenter.FinishOrder(houseB);

            houseB.GetComponent<Collider2D>().enabled = false;
            houseB.GetComponent<FadeEffect>().FadeOUT();

            Vector3 starpos = houseB.transform.position;
            starpos.z = -5f;
            particlestar.transform.position = starpos;
            particlestar.GetComponent<ParticleSystem>().Play();

            houseA = null;
            houseB = null;

            transform.Find("package").gameObject.SetActive(false);

            //sound
            star.Play();
            Debug.Log("Package Delivered");

            return true;
        }
        else
        {
            houseB = null;

            return false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
