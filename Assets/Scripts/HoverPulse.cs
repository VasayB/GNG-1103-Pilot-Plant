using UnityEngine;
using UnityEngine.EventSystems;

public class HoverPulse : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Vector3 originalScale;
    public float scaleFactor = 1.05f;
    public float speed = 10f;
    bool hovered;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        Vector3 target = hovered ? originalScale * scaleFactor : originalScale;
        transform.localScale = Vector3.Lerp(transform.localScale, target, Time.deltaTime * speed);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hovered = false;
    }
}
