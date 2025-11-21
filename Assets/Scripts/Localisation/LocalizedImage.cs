using UnityEngine;
using UnityEngine.UI;

public class LocalizedImage : MonoBehaviour
{
    public Sprite englishSprite;
    public Sprite frenchSprite;

    Image img;

    void Awake()
    {
        img = GetComponent<Image>();
    }

    void OnEnable()
    {
        // Listen for language updates
        LocalizationManager.Instance.OnLanguageChanged += UpdateImage;
        UpdateImage();
    }

    void OnDisable()
    {
        if (LocalizationManager.Instance != null)
            LocalizationManager.Instance.OnLanguageChanged -= UpdateImage;
    }

    void UpdateImage()
    {
        if (LocalizationManager.Instance.currentLanguage == Language.FR)
            img.sprite = frenchSprite;
        else
            img.sprite = englishSprite;
    }
}
