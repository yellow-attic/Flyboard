using UnityEngine;

public class Skate : MonoBehaviour
{

    [SerializeField] float boundary = 2.0f; // 挡板移动范围


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // 挡板移动
        float mousePosX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;

        // 限制挡板移动范围
        mousePosX = Mathf.Clamp(mousePosX, -boundary, boundary);
        Vector3 pos = new Vector3(mousePosX, transform.position.y, transform.position.z);
        transform.position = pos;
    }
}
