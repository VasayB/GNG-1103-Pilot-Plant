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

        english["quiz.title1"] = "Question1";
        french["quiz.title1"] = "Question1";

        english["quiz.question1"] = "What would immediately be used if your clothing caught fire or if a large chemical spill had occurred on your clothing?";
        french["quiz.question1"] = "Que devriez-vous utiliser immédiatement si vos vêtements prenaient en feu ou s’il y avait un grand déversement de produits chimiques sur vos vêtements?";

        english["quiz.q1.correct"] = "Safety shower";
        french["quiz.q1.correct"] = "\n\n\n\n\n\n     Une douche de sécurité";

        english["quiz.q1.wrong"] =
         "Fire extinguisher\nEye wash station\nFire blanket";
        french["quiz.q1.wrong"] =
        "\n\n\n\n\n     Un extincteur d’incendie\n\n     Une douche oculaire\n     Une couverture anti-feu";


        english["quiz.title2"] = "Question2";
        french["quiz.title2"] = "Question2";

        english["quiz.question2"] = "What should be worn in a laboratory at all times to decrease the likelihood of an eye injury?";
        french["quiz.question2"] = "Que devriez-vous porter en tout temps afin de diminuer les risques d’une blessure aux yeux?";

        english["quiz.q2.correct"] = "Safety goggles";
        french["quiz.q2.correct"] = "\n\n\n\n\n\n\n\n     Des lunettes de sécurité";

        english["quiz.q2.wrong"] =
        "Face shield\nRespiration mask\nFace mask";
        french["quiz.q2.wrong"] =
        "\n\n\n\n\n     Un écran facial\n     Un masque respiratoire\n     Un masque facial";

        english["quiz.title3"] = "Question3";
        french["quiz.title3"] = "Question3";

        english["quiz.question3"] = "Which of the following is NOT appropriate personal protective equipment (PPE)?";
        french["quiz.question3"] = "Lequel de ces objets n’est PAS approprié en tant qu’équipement de protection individuelle (EPI)?";

        english["quiz.q3.correct"] = "Open-toed sandals";
        french["quiz.q3.correct"] = "\n\n\n\n\n\n     Des sandales à bout ouvert";

        english["quiz.q3.wrong"] =
        "Safety goggles\nLab coat\nNitrile gloves";
        french["quiz.q3.wrong"] =
        "\n\n\n\n\n     Des lunettes de sécurité\n\n     Un sarrau\n     Des gants en nitrile";

        english["quiz.title4"] = "Question4";
        french["quiz.title4"] = "Question4"; 

        english["quiz.question4"] = "What is the correct action if you break a glass beaker in the lab?";
        french["quiz.question4"] = "Que devriez-vous faire si vous cassez un bécher en verre dans un laboratoire?";

        english["quiz.q4.correct"] =
        "Sweep it up with a brush and dustpan";
        french["quiz.q4.correct"] =
        "\n\n\n\n\n\n\n      Ramasser les éclats de verre avec un balai et      un porte-poussière";

        english["quiz.q4.wrong"] =
        "Pick up the shards with your hands\nKick it aside\nLeave it on the floor";
        french["quiz.q4.wrong"] =
        "\n\n\n\n      Ramasser les éclats de verre avec vos mains\n\n      Mettre les éclats de verre de côté en leur      donnant un coup de pied\n\n\n      Laisser les éclats de verre sur le plancher";

        english["quiz.title5"] = "Question5";
        french["quiz.title5"] = "Question5"; 

        english["quiz.question5"] = "When should you remove your gloves?";
        french["quiz.question5"] = "À quel moment devriez-vous enlever vos gants?";

        english["quiz.q5.correct"] =
        "When leaving the lab or touching clean surfaces";
        french["quiz.q5.correct"] =
        "\n\n\n\n\n\n\n\nLorsque vous quittez le laboratoire ou lorsque vous touchez des surfaces propres";

        english["quiz.q5.wrong"] =
        "To use your phone\n.    When grabbing clean glassware\nNever";
        french["quiz.q5.wrong"] =
        "\n\n\n\n     Afin d’utiliser son téléphone\n\n     Lorsque vous manipulez de la verrerie propre\n     En aucun cas";
    
        english["quiz.button"] = "NextQuestion";
        french["quiz.button"] = "Suivant";

        english["quiz.finishbutton"] = "Finish";
        french["quiz.finishbutton"] = "Terminer";
    
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
