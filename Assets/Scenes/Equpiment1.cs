using UnityEngine;
using System.Collections;

public class MoveToTargetToggle : MonoBehaviour
{
    public Vector3 targetPosition = new Vector3(-10f, 3f, 20f);
    public float moveDuration = 1f;

    private Vector3 originalPosition;
    private bool isMoving = false;
    private bool isAtTarget = false;

    void Start()
    {
        originalPosition = transform.position; // store starting position
    }

    // Call this from XR Grab or XR Poke
    public void ToggleMove()
    {
        if (!isMoving)
        {
            if (isAtTarget)
                StartCoroutine(MoveOverTime(originalPosition));
            else
                StartCoroutine(MoveOverTime(targetPosition));

            isAtTarget = !isAtTarget;
        }
    }

    private IEnumerator MoveOverTime(Vector3 destination)
    {
        isMoving = true;

        Vector3 startPos = transform.position;
        float elapsed = 0f;

        while (elapsed < moveDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / moveDuration);
            t = Mathf.SmoothStep(0, 1, t);

            transform.position = Vector3.Lerp(startPos, destination, t);
            yield return null;
        }

        transform.position = destination;
        isMoving = false;
    }
}
