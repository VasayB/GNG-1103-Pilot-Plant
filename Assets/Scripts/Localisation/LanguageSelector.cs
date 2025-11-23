using UnityEngine;

public class LanguageSelector : MonoBehaviour
{
    public GameObject languagePanel;   // Your LanguagePanel inside MainMenu
    public GameObject homeMenuPanel;   // The rest of your main menu UI

    public void SelectEnglish()
    {
        LocalizationManager.Instance.SetLanguage(Language.EN);
        ShowHomeScreen();
    }

    public void SelectFrench()
    {
        Debug.Log("FR clicked");
        LocalizationManager.Instance.SetLanguage(Language.FR);
        ShowHomeScreen();
    }

    private void ShowHomeScreen()
    {
        languagePanel.SetActive(false); 
        homeMenuPanel.SetActive(true);
    }
}
