using UnityEngine;

public class Citytour : MonoBehaviour
{
    [SerializeField] float speed = 5.0f; // 相机移动速度
    [SerializeField] float limit = 5.0f;

    private void Start()
    {
        transform.position = new Vector3(-limit, transform.position.y, transform.position.z);
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // 获取水平输入
        Vector3 newPosition = transform.position + new Vector3(horizontalInput * speed * Time.deltaTime, 0f, 0f);
        newPosition.x = Mathf.Clamp(newPosition.x, -limit, limit);

        transform.position = newPosition;
    }
}
