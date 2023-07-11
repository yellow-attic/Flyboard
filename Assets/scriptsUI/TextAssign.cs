using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextAssign : MonoBehaviour
{
    [SerializeField] string[] tutorialtext;
    [SerializeField] TypewriterEffect sendtext;

    [SerializeField] GameObject[] page;

    int textindex = 0;

    bool addedillu = true;
    bool ismousedown = false;

    [SerializeField] string skipscene;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !ismousedown)
        {
            if(textindex < tutorialtext.Length)
            {
                sendtext.GetText(tutorialtext[textindex]);
                textindex += 1;

                addedillu = false;
                ismousedown = true;
            }
            else
            {
                GameObject.FindWithTag("Game").GetComponent<SceneAssign>().NextScene(skipscene);
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
        if (!addedillu)
        {
            page[textindex - 1].SetActive(true);
            if (textindex > 1)
            {
                page[textindex - 2].SetActive(false);
            }

            addedillu = true;
        }

    }
}