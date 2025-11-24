using UnityEngine;
using UnityEngine.SceneManagement;

public class SideMenuController : MonoBehaviour
{
    public RectTransform panel; // link to SideMenuPanel
    private bool isOpen = false;

    private Vector2 hiddenPos = new Vector2(-300, 0);
    private Vector2 visiblePos = new Vector2(150, 0);

    private float speed = 10f;

    void Update()
    {
        // Slide animation
        if (isOpen)
        {
            panel.anchoredPosition = Vector2.Lerp(panel.anchoredPosition, visiblePos, Time.unscaledDeltaTime * speed);
        }
        else
        {
            panel.anchoredPosition = Vector2.Lerp(panel.anchoredPosition, hiddenPos, Time.unscaledDeltaTime * speed);
        }
    }

    public void ToggleMenu()
    {
        isOpen = !isOpen;
        Time.timeScale = isOpen ? 0 : 1; // pause/resume
    }

    public void Resume()
    {
        isOpen = false;
        Time.timeScale = 1;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu"); 
    }

    public void Quit()
    {
        Application.Quit();
    }
}
