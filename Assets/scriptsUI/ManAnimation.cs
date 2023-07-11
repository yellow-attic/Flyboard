using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManAnimation : MonoBehaviour
{
    public float speed = 5f;  // 球的速度
    private Vector2 direction;  // 球的方向
    private Rigidbody2D rb;

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
        if (transform.position.y <= Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y + GetComponent<SpriteRenderer>().bounds.size.y / 2
            || transform.position.y >= Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).y - GetComponent<SpriteRenderer>().bounds.size.y / 2)
        {
            direction.y *= -1;
            rb.velocity = direction * speed;
        }
        if (transform.position.x <= Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x + GetComponent<SpriteRenderer>().bounds.size.x / 2
            || transform.position.x >= Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).x - GetComponent<SpriteRenderer>().bounds.size.x / 2)
        {
            direction.x *= -1;
            rb.velocity = direction * speed;
        }
    }   
}