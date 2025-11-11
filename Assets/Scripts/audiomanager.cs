using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("--------Audio Source--------")]
    [SerializeField] private AudioSource musicSource;

    [Header("--------Audio Clip--------")]
    public AudioClip background;

    private static AudioManager instance;

    void Awake()
    {
        // Ensure only one AudioManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // ✅ Keeps it alive between scenes
        }
        else
        {
            Destroy(gameObject); // Prevent duplicates
            return;
        }

        // Optional: Start playing music automatically
        if (musicSource != null && background != null)
        {
            musicSource.clip = background;
            musicSource.loop = true; // ✅ Loops the background music
            musicSource.Play();
        }
    }
}
