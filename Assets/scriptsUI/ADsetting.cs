using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ADsetting : MonoBehaviour
{
    [SerializeField] private string[] adtext;


    void Start()
    {
        int index = Random.Range(0, adtext.Length);
        GetComponent<TextMeshProUGUI>().text = adtext[index];
    }

}
