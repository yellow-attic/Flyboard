using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarmGame : MonoBehaviour
{
    [SerializeField] Skate skate;
    [SerializeField] OrderSpeed ordertime;

    public void warmup()
    {
        skate.enabled = true;
        ordertime.enabled = true;
        GameObject.FindWithTag("Game").GetComponent<gamecenter>().readytolaunch = true;
    }
}
