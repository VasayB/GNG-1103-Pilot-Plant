using UnityEngine;

public class UIFloat : MonoBehaviour
{
    public float floatAmplitude = 5f; // how much it moves
    public float floatSpeed = 5f;     // speed of bobbing

    Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        float y = Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
        transform.localPosition = startPos + new Vector3(0, y, 0);
    }
}
