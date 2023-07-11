using UnityEngine;

public class SwayAnimation : MonoBehaviour
{
    [SerializeField] float swayAmount = 15f;
    [SerializeField] float swaySpeed = 8f;

    private float currentTime;

    void Update()
    {
        currentTime += Time.deltaTime * swaySpeed;
        float swayZ = Mathf.Sin(currentTime) * swayAmount;
        transform.localRotation = Quaternion.Euler(0, 0, swayZ);
    }
}


