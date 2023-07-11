using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class buttonFunction : MonoBehaviour, IPointerUpHandler
{
    Button button;

    [SerializeField] string nextscene;

    private void Start()
    {
        //获取Button组件
        button = GetComponent<Button>();
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        GameObject.FindWithTag("Game").GetComponent<SceneAssign>().NextScene(nextscene);
    }
}
