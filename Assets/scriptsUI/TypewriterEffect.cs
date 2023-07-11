using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{
    [SerializeField] float typingSpeed = 0.1f;    // 每个字符的显示间隔时间
    TextMeshPro textObject;  // 要显示的文本

    private string fullText = "";       // 完整文本
    private string currentText = "";    // 当前显示的文本

    [SerializeField] AudioSource talksound;

    private void Start()
    {
        textObject = GetComponent<TextMeshPro>();
        GetText(textObject.text);
    }

    public void GetText(string newtext)
    {
        fullText = newtext;                 // 获取完整文本
        textObject.text = "";               // 清空文本

        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        talksound.Play();

        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);    // 获取当前要显示的文本
            textObject.text = currentText;              // 显示文本
            yield return new WaitForSeconds(typingSpeed);   // 等待
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            textObject.text = fullText;
        }
    }
}
