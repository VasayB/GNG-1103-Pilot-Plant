using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    public Camera mainCamera; // assign this in Inspector (optional)

    void LateUpdate()
    {
        if(mainCamera != null)
        {
            transform.LookAt(mainCamera.transform);
            transform.Rotate(0f, 180f, 0f); // flip front to camera
        }
    }
}
