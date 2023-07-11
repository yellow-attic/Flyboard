using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ordercenter : MonoBehaviour
{
    [Header("ORDER INFRO")]
    [SerializeField] GameObject pfb_sender;
    [SerializeField] GameObject pfb_recipient;

    [SerializeField] Transform housenumber;
    [SerializeField] List<GameObject> orderspos;

    [SerializeField] float externposx = 1f;

    GameObject currentobj;
    bool gotorder = false;
    int packagenumber = 0;
    Color packagecolor;

    [Header("ORDER TIME")]
    [SerializeField] float waitreceived = 1f;

    gamecenter game;


    void Start()
    {
        for (int i = 0; i < housenumber.childCount; i++)
        {
            GameObject child = housenumber.GetChild(i).gameObject;
            orderspos.Add(child);
        }

        game = GameObject.FindWithTag("Game").GetComponent<gamecenter>();
    }

    void Update()
    {

    }

    public bool GetAdress()
    {
        if (orderspos.Count >= 22)
        {
            int index = Random.Range(0, orderspos.Count);
            Vector3 adress = orderspos[index].transform.position;
            currentobj = orderspos[index];

            orderspos.RemoveAt(index);

            if (!gotorder)
            {
                CreateSender(adress);
            }
            else
            {
                CreateRecipient(adress);
            }
            return true;
        }
        else
        {
            return false;
        }
    }


    //---------------------------------------------------create order
    private void CreateSender(Vector3 possender)
    {
        GameObject obj_sender = Instantiate(pfb_sender);

        obj_sender.transform.SetParent(transform);

        possender = new Vector3(possender.x + externposx, possender.y, -3f);
        obj_sender.transform.position = possender;
        obj_sender.transform.localScale = new Vector3(1, 1, 1);

        //create highlight
        currentobj.GetComponent<FadeEffect>().FadeIN();
        currentobj.GetComponent<Collider2D>().enabled = true;

        //package signup
        packagenumber += 1;

        obj_sender.AddComponent<SignupOrder>().packagecode = packagenumber;
        obj_sender.GetComponent<SignupOrder>().packagetype = "sender";

        currentobj.GetComponent<SignupOrder>().packagetype = "sender";
        currentobj.GetComponent<SignupOrder>().packagecode = packagenumber;
       
        packagecolor = obj_sender.AddComponent<PackageColor>().SetPackageColor();
        currentobj.GetComponent<SignupOrder>().wrapcolor = packagecolor;

        gotorder = true;
        StartCoroutine(WaitDestination());
    }

    IEnumerator WaitDestination()
    {
        yield return new WaitForSeconds(waitreceived);
        if (!GetAdress())
        {
            Debug.LogError("No Place For Recipitent!!!");
        }
    }

    private void CreateRecipient(Vector3 posrecipient)
    {
        GameObject obj_recipient = Instantiate(pfb_recipient);

        obj_recipient.transform.SetParent(transform);

        posrecipient = new Vector3(posrecipient.x - externposx, posrecipient.y, -2f);
        obj_recipient.transform.position = posrecipient;
        obj_recipient.transform.localScale = new Vector3(1, 1, 1);

        //create highlight
        currentobj.GetComponent<FadeEffect>().FadeIN();
        currentobj.GetComponent<Collider2D>().enabled = true;

        //package signup
        obj_recipient.AddComponent<SignupOrder>().packagecode = packagenumber;
        obj_recipient.GetComponent<SignupOrder>().packagetype = "recipient";

        currentobj.GetComponent<SignupOrder>().packagetype = "recipient";
        currentobj.GetComponent<SignupOrder>().packagecode = packagenumber;

        obj_recipient.transform.Find("color").GetComponent<SpriteRenderer>().color = packagecolor;

        gotorder = false;
    }

    //---------------------------------------------------tipp for order
    public void Tipp(int code)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponentInChildren<SignupOrder>().packagecode == code)
            {
                if (transform.GetChild(i).GetComponentInChildren<SignupOrder>().packagetype == "recipient")
                {
                    transform.GetChild(i).gameObject.AddComponent<SwayAnimation>();
                }
            }
        }
    }


    //---------------------------------------------------receiving order
    public void ReceivePackage(GameObject housesender)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponentInChildren<SignupOrder>().packagecode
                == housesender.GetComponentInChildren<SignupOrder>().packagecode)
            {
                if (transform.GetChild(i).GetComponentInChildren<SignupOrder>().packagetype == "sender")
                {
                    Destroy(transform.GetChild(i).gameObject);

                    orderspos.Add(housesender);
                }
            }
        }
    }

   public void FinishOrder(GameObject houserecipitent)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponentInChildren<SignupOrder>().packagecode
                == houserecipitent.GetComponentInChildren<SignupOrder>().packagecode)
            {
                Destroy(transform.GetChild(i).gameObject);

                orderspos.Add(houserecipitent);
            }
        }

        game.CountOrders();
    }
}
