using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waitmusic : MonoBehaviour
{
    [SerializeField] float waittimer;
    void Start()
    {
        StartCoroutine(PlayMusic());
    }

    IEnumerator PlayMusic()
    {
        yield return new WaitForSeconds(waittimer);   // 等待
        GetComponent<AudioSource>().Play();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
