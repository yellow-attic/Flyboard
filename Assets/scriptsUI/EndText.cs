using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndText : MonoBehaviour
{
    [SerializeField] string[] endword;
    [SerializeField] TypewriterEffect sendtext;

    [SerializeField] GameObject[] box;

    int textindex = 0;

    bool addedillu = true;
    bool ismousedown = false;

    [SerializeField] string scene;


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !ismousedown)
        {
            if (textindex < endword.Length)
            {
                sendtext.GetText(endword[textindex]);
                textindex += 1;

                addedillu = false;
                ismousedown = true;
            }
            else
            {
                GameObject.FindWithTag("Game").GetComponent<SceneAssign>().NextScene(scene);
                Debug.Log("nextscene");
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            ismousedown = false;
        }

        AddIllustration();
    }

    void AddIllustration()
    {
        if (textindex < 3)
        {
            if (!addedillu)
            {
                box[textindex - 1].SetActive(true);
                if (textindex > 1)
                {
                    box[textindex - 2].SetActive(false);
                }
                addedillu = true;
            }

        }

    }
}
