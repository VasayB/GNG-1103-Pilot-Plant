using UnityEngine;
using TMPro;
using System.Collections;

[RequireComponent(typeof(TMP_Text))]
public class LocalizedTMP : MonoBehaviour
{
    public string key;
    private TMP_Text textField;

    void Awake()
    {
        textField = GetComponent<TMP_Text>();

        // Register immediately if manager exists
        if (LocalizationManager.Instance != null)
        {
            LocalizationManager.Instance.OnLanguageChanged += UpdateText;
            UpdateText();
        }
        else
        {
            // Wait for manager to exist
            StartCoroutine(DelayedRegister());
        }
    }

    IEnumerator DelayedRegister()
    {
        while (LocalizationManager.Instance == null)
            yield return null;

        LocalizationManager.Instance.OnLanguageChanged += UpdateText;
        UpdateText();
    }

    void OnDestroy()
    {
        if (LocalizationManager.Instance != null)
            LocalizationManager.Instance.OnLanguageChanged -= UpdateText;
    }

    public void UpdateText()
    {
        if (textField != null && LocalizationManager.Instance != null)
            textField.text = LocalizationManager.Instance.Get(key);
    }
}
