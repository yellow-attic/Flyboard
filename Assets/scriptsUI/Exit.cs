using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Exit : MonoBehaviour, IPointerUpHandler
{
    Button button;

    private void Start()
    {
        button = GetComponent<Button>();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Application.Quit();
    }
}
