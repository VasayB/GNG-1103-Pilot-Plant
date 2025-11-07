using UnityEngine;

public class SimpleCameraRotate : MonoBehaviour
{
    public float rotationSpeed = 50f;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up, mouseX * rotationSpeed * Time.deltaTime);
    }
}