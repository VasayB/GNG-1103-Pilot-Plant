using UnityEngine;

public class UIPanelController : MonoBehaviour
{
    public GameObject panel;

    public void ShowPanel()
    {
        panel.SetActive(true);
    }

    public void HidePanel()
    {
        panel.SetActive(false);
    }
}
