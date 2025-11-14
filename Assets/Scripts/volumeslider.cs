using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;

    void Start()
    {
        if (AudioManager.Instance != null)
        {
            // Initialize slider to current volume
            slider.value = AudioManager.Instance.GetVolume();

            // Update AudioManager volume when slider moves
            slider.onValueChanged.AddListener(AudioManager.Instance.SetVolume);
        }
    }
}
