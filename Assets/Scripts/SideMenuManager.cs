using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    public GameObject menuPrefab;

    GameObject menuInstance;
    Animator menuAnimator;
    bool menuOpen = false;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // DON'T show menu in Main Menu
        if (scene.name == "MainMenu")
        {
            if (menuInstance != null)
                menuInstance.SetActive(false);

            return;
        }

        // Load menu if not already created
        if (menuInstance == null)
        {
            menuInstance = Instantiate(menuPrefab);
            menuAnimator = menuInstance.GetComponentInChildren<Animator>(true);
            DontDestroyOnLoad(menuInstance);
        }

        menuInstance.SetActive(true);

        // Always start as closed
        CloseMenu();
    }

    public void ToggleMenu()
    {
        if (menuOpen) CloseMenu();
        else OpenMenu();
    }

    void OpenMenu()
    {
        menuOpen = true;
        menuAnimator.Play("MenuSlideIn");
    }

    void CloseMenu()
    {
        menuOpen = false;
        menuAnimator.Play("MenuSlideOut");
    }
}
