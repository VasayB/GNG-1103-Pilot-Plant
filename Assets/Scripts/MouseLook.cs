using UnityEngine;
using UnityEngine.InputSystem;   // <- new Input System

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 0.1f;  // tweak in Inspector
    public float clampAngle = 85f;

    private float rotX;
    private float rotY;

    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotX = rot.x;
        rotY = rot.y;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Mouse.current == null) return;  // safety

        // Mouse delta from the new Input System (pixels/frame)
        Vector2 delta = Mouse.current.delta.ReadValue();

        rotY += delta.x * sensitivity;
        rotX -= delta.y * sensitivity;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        transform.rotation = Quaternion.Euler(rotX, rotY, 0f);
    }
}
