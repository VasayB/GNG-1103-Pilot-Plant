using UnityEngine;

public class FloatingArrow : MonoBehaviour
{
    public float amplitude = 0.1f;  // how high it moves up/down
    public float speed = 2f;        // how fast it moves

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        float offset = Mathf.Sin(Time.time * speed) * amplitude;
        transform.localPosition = startPos + new Vector3(0f, offset, 0f);
    }
}
