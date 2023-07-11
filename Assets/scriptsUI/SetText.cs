using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetText : MonoBehaviour
{
    void Awake()
    {
        GetComponent<TextMeshPro>().text = "Well Done! " +
            "\nThrough your persistence and diligence, you have completed\n\n" +
            Datasaving.Instance.calculateDeliverySum().ToString() +
            "\n\ndeliveries today";
    }

}
