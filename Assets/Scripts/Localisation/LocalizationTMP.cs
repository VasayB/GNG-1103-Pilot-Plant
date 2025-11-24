using UnityEngine;
using TMPro;
using System.Collections;

[RequireComponent(typeof(TMP_Text))]
public class LocalizedTMP : MonoBehaviour
{
    public string key;
    TMP_Text textField;

    void Awake()
    {
        textField = GetComponent<TMP_Text>();
    }

    void OnEnable()
    {
        StartCoroutine(DelayedRegister());
    }

    IEnumerator DelayedRegister()
    {
        // Wait until LocalizationManager.Instance exists
        while (LocalizationManager.Instance == null)
            yield return null;

        LocalizationManager.Instance.OnLanguageChanged += UpdateText;
        UpdateText();
    }

    void OnDisable()
    {
        if (LocalizationManager.Instance != null)
            LocalizationManager.Instance.OnLanguageChanged -= UpdateText;
    }

    void UpdateText()
    {
        if (textField != null && LocalizationManager.Instance != null)
            textField.text = LocalizationManager.Instance.Get(key);
    }
}
