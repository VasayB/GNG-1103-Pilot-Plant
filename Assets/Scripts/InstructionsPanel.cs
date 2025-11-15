using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PanelManager : MonoBehaviour
{
    public GameObject panel;      // Your panel (inactive at start)
    public Button closeButton;    // Your close button (inactive at start)
    public float delay = 3f;      // Delay before showing

    private void Start()
    {
        // Ensure both panel and button start hidden
        panel.SetActive(false);
        closeButton.gameObject.SetActive(false);

        // Assign close button action
        closeButton.onClick.AddListener(ClosePanel);

        // Start coroutine to show both after delay
        StartCoroutine(ShowPanelAndButton());
    }

    private IEnumerator ShowPanelAndButton()
    {
        yield return new WaitForSeconds(delay);

        // Activate panel and button
        panel.SetActive(true);
        closeButton.gameObject.SetActive(true);
    }

    private void ClosePanel()
    {
        // Hide both when button clicked
        panel.SetActive(false);
        closeButton.gameObject.SetActive(false);
    }
}
