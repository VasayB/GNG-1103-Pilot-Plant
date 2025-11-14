using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("--------Panels--------")]
    [SerializeField] private GameObject optionsPanel; // Drag your Options Panel here in the Inspector

    // 🎮 Load Scene
    public void Play()
    {
        Debug.Log("Play button clicked!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
        {
            optionsPanel.SetActive(true);
            Debug.Log("Options panel opened!");
        }
    }

    // ❌ Close Options Menu
    public void CloseOptions()
    {
        if (optionsPanel != null)
        {
            optionsPanel.SetActive(false);
            Debug.Log("Options panel closed!");
        }
    }
}
