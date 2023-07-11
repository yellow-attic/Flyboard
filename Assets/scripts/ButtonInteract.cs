using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonInteract : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    Button button;

    [SerializeField] Color normalColor;
    [SerializeField] Color highlightColor;

    [SerializeField] float scalesize;
    Vector3 orignalsize;


    private void Start()
    {
        //获取Button组件
        button = GetComponent<Button>();
        orignalsize = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //鼠标进入时高亮
        button.image.color = highlightColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //鼠标离开时恢复
        button.image.color = normalColor;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.localScale = new Vector3(scalesize, scalesize, scalesize);

        //buttonsound
        GameObject.FindWithTag("Sound").GetComponent<AudioSource>().Play();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localScale = orignalsize;
    }
}
