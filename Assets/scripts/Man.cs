using UnityEngine;

public class Man : MonoBehaviour
{
    public float speed = 5f;  // 球的速度
    private Vector2 direction;  // 球的方向
    private Rigidbody2D rb;

    [Header("Sound")]
    [SerializeField] AudioSource jump;


    void Start()
    {
        // 初始化球的方向为右上方
        direction = new Vector2(1, 1).normalized;

        rb = GetComponent<Rigidbody2D>();
        // 给球一个初始速度
        rb.velocity = direction * speed;
    }

    void FixedUpdate()
    {
        // 碰到相机边界时反弹
        if (transform.position.y >= Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).y - GetComponent<CapsuleCollider2D>().bounds.size.y / 2)
        {
            Debug.Log("switch Y");
            direction.y *= -1;
            rb.velocity = direction * speed;
            
        }
        if (transform.position.x <= Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x + GetComponent<CapsuleCollider2D>().bounds.size.x / 2
            || transform.position.x >= Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).x - GetComponent<CapsuleCollider2D>().bounds.size.x / 2)
        {
            Debug.Log("switch X");
            direction.x *= -1;
            rb.velocity = direction * speed;
        }
        if (transform.position.y <= Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y + GetComponent<CapsuleCollider2D>().bounds.size.y / 2)
        {
            GameObject.FindWithTag("Game").GetComponent<gamecenter>().endGame();
            Debug.Log("gameover");
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 碰到挡板时反弹
        if (collision.gameObject.tag == "Skate")
        {
            direction.y *= -1;
            rb.velocity = direction * speed;

            //sound
            jump.Play();
        }
    }
}

