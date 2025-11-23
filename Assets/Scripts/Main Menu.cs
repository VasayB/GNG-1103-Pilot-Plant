using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("--------Panels--------")]
    [SerializeField] private GameObject optionsPanel;

    // 🎮 Start Tour → must do quiz first
    public void StartTour()
    {
        Debug.Log("Start Tour clicked → loading Quiz scene...");
        SceneManager.LoadScene("Quiz");   // Your quiz scene
    }

    // 🚪 Quit Game
    public void Quit()
    {
        Application.Quit();
        Debug.Log("The Player has Quit the game");
    }

    // ⚙️ Open Options Menu
    public void OpenOptions()
    {
        if (optionsPanel != null)
            optionsPanel.SetActive(true);
    }

    // ❌ Close Options Menu
    public void CloseOptions()
    {
        if (optionsPanel != null)
            optionsPanel.SetActive(false);
    }
}
