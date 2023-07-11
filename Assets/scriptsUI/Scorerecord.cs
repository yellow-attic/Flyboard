using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Scorerecord : MonoBehaviour
{
    void Start()
    {
        int score = Datasaving.Instance.updateScore();
        GetComponent<TextMeshProUGUI>().text = score.ToString();
    }

}
