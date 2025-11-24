using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneFader : MonoBehaviour
{
    public static SceneFader Instance;
    public Image fadeImage;
    public float fadeDuration = 1f;

    void Awake()
    {
        // Singleton setup
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void OnEnable()
    {
        // Make sure we ALWAYS fade in when a new scene is loaded
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // When scene loads → run FadeIn again
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Reset to full black BEFORE fade-in starts
        fadeImage.color = new Color(0, 0, 0, 1f);

        StartCoroutine(FadeIn());
    }

    void Start()
    {
        // Also fade in on first scene load
        fadeImage.color = new Color(0, 0, 0, 1f);
        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeIn()
    {
        float t = fadeDuration;

        while (t > 0f)
        {
            t -= Time.deltaTime;

            float a = Mathf.Clamp01(t / fadeDuration);
            fadeImage.color = new Color(0, 0, 0, a);

            yield return null;
        }

        fadeImage.color = new Color(0, 0, 0, 0);
    }

    public IEnumerator FadeOut()
    {
        float t = 0f;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;

            float a = Mathf.Clamp01(t / fadeDuration);
            fadeImage.color = new Color(0, 0, 0, a);

            yield return null;
        }

        fadeImage.color = new Color(0, 0, 0, 1);
    }
}
