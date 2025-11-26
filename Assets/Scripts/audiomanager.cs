using UnityEngine;

/// <summary>
/// A singleton AudioManager that persists across scenes and automatically plays background music.
/// Also allows playing one-shot sound effects.
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("Background Music")]
    public AudioClip backgroundMusic;
    [Range(0f, 1f)]
    public float musicVolume = 1f;

    private AudioSource musicSource;

    void Awake()
    {
        // If another instance exists, destroy this one
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        // Setup AudioSource
        musicSource = GetComponent<AudioSource>();
        musicSource.playOnAwake = false;
        musicSource.loop = true;
        musicSource.volume = musicVolume;

        // Play background music if assigned
        if (backgroundMusic != null && !musicSource.isPlaying)
        {
            musicSource.clip = backgroundMusic;
            musicSource.Play();
        }
    }

    /// <summary>
    /// Change the background music volume at runtime.
    /// </summary>
    public void SetVolume(float volume)
    {
        musicVolume = Mathf.Clamp01(volume);
        if (musicSource != null)
            musicSource.volume = musicVolume;
    }

    /// <summary>
    /// Returns the current music volume.
    /// </summary>
    public float GetVolume()
    {
        return musicSource != null ? musicSource.volume : 0f;
    }

    /// <summary>
    /// Play a short one-shot sound effect (e.g., quiz correct/wrong).
    /// </summary>
    public void PlaySFX(AudioClip clip, float volume = 1f)
    {
        if (clip == null) return;
        musicSource.PlayOneShot(clip, Mathf.Clamp01(volume));
    }
}
