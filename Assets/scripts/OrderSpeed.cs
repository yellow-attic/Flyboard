using System.Collections;
using UnityEngine;


public class OrderSpeed : MonoBehaviour
{
    [SerializeField] float startDelay = 1.0f; // 初始延迟
    [SerializeField] float initialSpeed = 1.0f; // 初始速度
    [SerializeField] float speedIncrease = 0.1f; // 速度增加值
    [SerializeField] float maxSpeed = 10.0f; // 最大速度

    Ordercenter ordercenter;

    [Header("Sound")]
    [SerializeField] AudioSource ordersound;


    void Start()
    {
        ordercenter = GetComponent<Ordercenter>();

        StartCoroutine(PrintAWithIncreasingSpeed());
    }

    IEnumerator PrintAWithIncreasingSpeed()
    {
        yield return new WaitForSeconds(startDelay);

        float currentSpeed = initialSpeed;

        while (true)
        {
            if (ordercenter.GetAdress())
            {
                //sound
                ordersound.Play();

                Debug.Log("New Order!");
            }
            else
            {
                Debug.Log("Order is FUll");
            }

            currentSpeed += speedIncrease * Time.deltaTime;

            if (currentSpeed >= maxSpeed)
            {
                currentSpeed = maxSpeed;
            }

            yield return new WaitForSeconds(1.0f / currentSpeed);
        }
    }

}