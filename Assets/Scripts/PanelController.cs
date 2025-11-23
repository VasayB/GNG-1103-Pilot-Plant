using UnityEngine;

public class PanelController : MonoBehaviour
{
    [Header("Assign your panel here")]
    public GameObject infoPanel;

    void Start()
    {
        // Ensure the panel is hidden at the start
        if (infoPanel != null)
        {
            infoPanel.SetActive(false);
        }
    }

    // Call this from Open button
    public void ShowPanel()
    {
        if (infoPanel != null)
        {
            infoPanel.SetActive(true);
        }
    }

    // Call this from Close button
    public void HidePanel()
    {
        if (infoPanel != null)
        {
            infoPanel.SetActive(false);
        }
    }
}
