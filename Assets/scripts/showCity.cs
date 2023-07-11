using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showCity : MonoBehaviour
{
    [SerializeField] float posxlimit = -4.43f;
    [SerializeField] float speed = 5f;

    Vector3 targetpos;
    bool finishtour = false;

    void Start()
    {
        targetpos = new Vector3(posxlimit, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (!finishtour)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetpos, speed * Time.deltaTime);


            if(transform.position == targetpos)
            {
                GetComponent<Citytour>().enabled = true;
                finishtour = true;
            }
        }
    }
}
