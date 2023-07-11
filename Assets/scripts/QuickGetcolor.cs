using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickGetcolor : MonoBehaviour
{
    [SerializeField] SpriteRenderer targetsprite;
 
    void Start()
    {
        GetComponent<SpriteRenderer>().color = targetsprite.color;
    }

}
