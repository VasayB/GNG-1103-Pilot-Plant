using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("--------Audio Source--------")]
    [SerializeField] private AudioSource musicSource;

    [Header("--------Audio Clip--------")]
    public AudioClip background;

    public static AudioManager Instance { get; private set; }

    void Awake()
    {
        // Ensure only one AudioManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keeps music playing between scenes
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        if (musicSource != null && background != null)
        {
            musicSource.clip = background;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    // 🎚 Change volume
    public void SetVolume(float volume)
    {
        if (musicSource != null)
            musicSource.volume = volume;
    }

    // Optional getter
    public float GetVolume()
    {
        return musicSource != null ? musicSource.volume : 0f;
    }
}
