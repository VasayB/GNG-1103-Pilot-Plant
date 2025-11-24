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

        english["quiz.q1.correct"] = "\n\n\n\n\n\n     Safety shower";
        french["quiz.q1.correct"] = "\n\n\n\n\n\n     Une douche de sécurité";

        english["quiz.q1.wrong"] =
         "\n\n\n\n\n     Fire extinguisher\n\n     Eye wash station\n     Fire blanket";
        french["quiz.q1.wrong"] =
        "\n\n\n\n\n     Un extincteur d’incendie\n\n     Une douche oculaire\n     Une couverture anti-feu";


        english["quiz.title2"] = "Question2";
        french["quiz.title2"] = "Question2";

        english["quiz.question2"] = "What should be worn in a laboratory at all times to decrease the likelihood of an eye injury?";
        french["quiz.question2"] = "Que devriez-vous porter en tout temps afin de diminuer les risques d’une blessure aux yeux?";

        english["quiz.q2.correct"] = "\n\n\n\n\n\n\n\n     Safety goggles";
        french["quiz.q2.correct"] = "\n\n\n\n\n\n\n\n     Des lunettes de sécurité";

        english["quiz.q2.wrong"] =
        "\n\n\n\n\n     Face shield\n     Respiration mask\n     Face mask";
        french["quiz.q2.wrong"] =
        "\n\n\n\n\n     Un écran facial\n     Un masque respiratoire\n     Un masque facial";

        english["quiz.title3"] = "Question3";
        french["quiz.title3"] = "Question3";

        english["quiz.question3"] = "Which of the following is NOT appropriate personal protective equipment (PPE)?";
        french["quiz.question3"] = "Lequel de ces objets n’est PAS approprié en tant qu’équipement de protection individuelle (EPI)?";

        english["quiz.q3.correct"] = "\n\n\n\n\n\n     Open-toed sandals";
        french["quiz.q3.correct"] = "\n\n\n\n\n\n     Des sandales à bout ouvert";

        english["quiz.q3.wrong"] =
        "\n\n\n\n\n     Safety goggles\n\n     Lab coat\n     Nitrile gloves";
        french["quiz.q3.wrong"] =
        "\n\n\n\n\n     Des lunettes de sécurité\n\n     Un sarrau\n     Des gants en nitrile";

        english["quiz.title4"] = "Question4";
        french["quiz.title4"] = "Question4"; 

        english["quiz.question4"] = "What is the correct action if you break a glass beaker in the lab?";
        french["quiz.question4"] = "Que devriez-vous faire si vous cassez un bécher en verre dans un laboratoire?";

        english["quiz.q4.correct"] =
        "\n\n\n\n\n\n\n\n\n      Sweep it up with a brush and dustpan";
        french["quiz.q4.correct"] =
        "\n\n\n\n\n\n\n      Ramasser les éclats de verre avec un balai et      un porte-poussière";

        english["quiz.q4.wrong"] =
        "\n\n\n\n      Pick up the shards with your hands\n\n     Kick it aside\n\n     Leave it on the floor";
        french["quiz.q4.wrong"] =
        "\n\n\n\n      Ramasser les éclats de verre avec vos mains\n\n      Mettre les éclats de verre de côté en leur      donnant un coup de pied\n\n\n      Laisser les éclats de verre sur le plancher";

        english["quiz.title5"] = "Question5";
        french["quiz.title5"] = "Question5"; 

        english["quiz.question5"] = "When should you remove your gloves?";
        french["quiz.question5"] = "À quel moment devriez-vous enlever vos gants?";

        english["quiz.q5.correct"] =
        "\n\n\n\n\n\n\n\nWhen leaving the lab or touching clean surfaces";
        french["quiz.q5.correct"] =
        "\n\n\n\n\n\n\n\nLorsque vous quittez le laboratoire ou lorsque vous touchez des surfaces propres";

        english["quiz.q5.wrong"] =
        "\n\n\n\n     To use your phone\n\n     When grabbing clean glassware\n\n     Never";
        french["quiz.q5.wrong"] =
        "\n\n\n\n     Afin d’utiliser son téléphone\n\n     Lorsque vous manipulez de la verrerie propre\n     En aucun cas";
    
        english["quiz.button"] = "NextQuestion";
        french["quiz.button"] = "Suivant";



        english["quiz.finishbutton"] = "Finish";
        french["quiz.finishbutton"] = "Terminer";

        english["panel.resumebutton"] = "Resume";
        french["panel.resumebutton"] = "Reprendre";

        english["panel.restartbutton"] = "Restart";
        french["panel.restartbutton"] = "Redémarrer";

        english["panel.quitbutton"] = "Quit";
        french["panel.quitbutton"] = "Quitter";

        ///UI PANELS

        english["panel1.title"] = "Water filtration";
        french["panel1.title"] ="Filtration de l’eau";

        english["panel1.body"] = "Removes solids and impurities from the water before it enters the pilot plant system. Water flows through a series of filter cartridges, each designed to capture particles of different sizes. Helps protect pumps, sensors, and downstream equipment from clogging or damage caused by contaminants.";
        french["panel1.body"] ="Élimine les solides et les impuretés de l’eau avant qu’elle n’entre dans le système de l’usine pilote.L’eau circule à travers une série de cartouches filtrantes, chacune conçue pour capturer des particules de différentes tailles. Aide à protéger les pompes, les capteurs et l’équipement en aval contre l’obstruction ou les dommages causés par les contaminants.";

        english["panel2.title"] = "Chemical feed tank";
        french["panel2.title"] ="Réservoir d’alimentation chimique";

        english["panel2.body"] = "This tank stores a prepared chemical solution that will be added into a system in controlled amounts. A dosing pump draws liquid from the tank through the small tubing connected to the lid. The chemical is injected into the system to adjust pH, add reagents, or condition the mixture.";
        french["panel2.body"] ="Ce réservoir stocke une solution chimique préparée qui sera ajoutée dans un système en quantités contrôlées. Une pompe de dosage prélève le liquide du réservoir par le petit tube relié au couvercle. Le produit chimique est injecté dans le système pour ajuster le  pH, ajouter des réactifs ou conditionner le mélange.";

        english["panel3.title"] = "Process control training pane";
        french["panel3.title"] ="Panneau de formation au contrôle des procédés";

        english["panel3.body"] = "The panel simulates how industrial process controls work using gauges, switches, and flow indicators. The system demonstrates how changes in one part of a process affect the rest of the equipment. It is used to teach basic troubleshooting, such as detecting leaks, blockages, or incorrect valve settings.";
        french["panel3.body"] ="Le panneau simule le fonctionnement des systèmes de contrôle des procédés industriels à l’aide de manomètres, d’interrupteurs et d’indicateurs de débit. Le système démontre comment des changements dans une partie d’un procédé affectent le reste de l’équipement. Il est utilisé pour enseigner les bases du dépannage, comme la détection de fuites, de blocages ou de mauvais réglages de vannes.";

        english["panel4.title"] = "Process control training rig";
        french["panel4.title"] ="Banc de formation au contrôle des procédés";

        english["panel4.body"] = "This unit demonstrates how fluid flow is measured, controlled, and regulated in an industrial system. Students adjust valves, pumps, and sensors to observe changes in pressure, flow rate, and system response. The rig includes a digital control interface that shows real-time data and allows tuning of control parameters.";
        french["panel4.body"] ="Cette unité démontre comment l’écoulement d’un fluide est mesuré, contrôlé et régulé dans un système industriel. Les étudiants ajustent des vannes, des pompes et des capteurs pour observer les changements de pression, de débit et la réponse du système. Le banc comprend une interface de contrôle numérique qui affiche des données en temps réel et permet d’ajuster les paramètres de contrôle.";

        english["panel5.title"] = "Packed bed reactor";
        french["panel5.title"] ="Réacteur à lit fixe";

        english["panel5.body"] = "Fluids are pumped through the packed column to study pressure drop, flow patterns, and mass transfer behavior. Packing materials help increase contact between the fluid and solid surfaces, improving reaction or absorption efficiency. This setup allows students to analyze how different flow rates and packing types influence reactor performance.";
        french["panel5.body"] ="Les fluides sont pompés à travers la colonne remplie pour étudier la perte de charge, les régimes d’écoulement et le comportement de transfert de masse. Les matériaux de garnissage augmentent le contact entre le fluide et les surfaces solides, améliorant ainsi l’efficacité de la réaction ou de l’absorption. Ce montage permet aux étudiants d’analyser comment différents débits et types de garnissage influencent la performance du réacteur.";

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
