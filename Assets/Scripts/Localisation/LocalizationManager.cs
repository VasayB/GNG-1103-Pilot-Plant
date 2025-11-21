using System;
using System.Collections.Generic;
using UnityEngine;

public enum Language { EN, FR }

public class LocalizationManager : MonoBehaviour
{
    public static LocalizationManager Instance { get; private set; }

    public Language currentLanguage = Language.EN;
    public event Action OnLanguageChanged;

    Dictionary<string,string> english = new Dictionary<string,string>();
    Dictionary<string,string> french = new Dictionary<string,string>();

    const string PREF = "lang";

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadTexts();
        ForceDefaultLanguage();   // <-- always use EN at startup
    }

    void LoadTexts()
    {
        english["home.title"] = "Welcome to uOttawa's Chemical Pilot Plant Tour";
        french["home.title"]  = "Bienvenue à la visite de l’usine pilote de chimie de l’Université d’Ottawa";

        english["home.start"] = "Start Tour";
        french["home.start"]  = "Commencer la visite";

        english["home.volume"] = "Volume";
        french["home.volume"]  = "Volume";

        english["home.adjust"] = "Adjust Volume";
        french["home.adjust"]  = "Ajuster le volume";

        english["home.quit"] = "Quit";
        french["home.quit"]  = "Quitter";
    }

    /// <summary>
    /// Always starts Unity in EN, ignoring PlayerPrefs.
    /// </summary>
    void ForceDefaultLanguage()
    {
        currentLanguage = Language.EN;  
        PlayerPrefs.SetString(PREF, "EN");  
        PlayerPrefs.Save();
    }

    public void SetLanguage(Language lang)
    {
        Debug.Log("Setting language to: " + lang);

        currentLanguage = lang;
        PlayerPrefs.SetString(PREF, lang == Language.FR ? "FR" : "EN");
        PlayerPrefs.Save();

        OnLanguageChanged?.Invoke(); 
    }

    public string Get(string key)
    {
        if (currentLanguage == Language.FR && french.ContainsKey(key)) return french[key];
        if (english.ContainsKey(key)) return english[key];
        return "MISSING: " + key;
    }
}
