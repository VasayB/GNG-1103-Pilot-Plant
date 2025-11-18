using UnityEngine;

public class SimpleCameraController : MonoBehaviour
{
    public float speed = 5f;
    public float lookSpeed = 3f;

    private float yaw = 0f;
    private float pitch = 0f;

    void Update()
    {
        // Mouse look ONLY when left mouse button is held
        if (Input.GetMouseButton(0)) // 0 = left mouse button
        {
            yaw += lookSpeed * Input.GetAxis("Mouse X");
            pitch -= lookSpeed * Input.GetAxis("Mouse Y");
            pitch = Mathf.Clamp(pitch, -90f, 90f);

            transform.eulerAngles = new Vector3(pitch, yaw, 0f);
        }

        // Movement (WASD + Q/E)
        float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float y = 0f;

        if (Input.GetKey(KeyCode.E)) y += speed * Time.deltaTime; // up
        if (Input.GetKey(KeyCode.Q)) y -= speed * Time.deltaTime; // down

        transform.Translate(new Vector3(x, y, z));
    }
}
