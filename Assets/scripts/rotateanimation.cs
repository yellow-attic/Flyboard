using UnityEngine;


public class rotateanimation : MonoBehaviour
{

    [SerializeField] private  float rotationSpeed = 30f; // the speed of the rotation in degrees per second

    void Update()
    {
        // Rotate the sprite around the Z-axis
        transform.Rotate(Vector3.back * rotationSpeed);
    }
}