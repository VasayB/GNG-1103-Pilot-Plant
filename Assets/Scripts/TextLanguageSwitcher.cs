using UnityEngine;
using TMPro;

public class TextLanguageSwitcher : MonoBehaviour
{
    [System.Serializable]
    public class TextPair
    {
        public TMP_Text textObject;   // Drag the TMP text here
        [TextArea] public string englishText;
        [TextArea] public string frenchText;
    }

    public TextPair[] textPairs;

    public void SwitchToEnglish()
    {
        foreach (var pair in textPairs)
        {
            pair.textObject.text = pair.englishText;
        }
    }

    public void SwitchToFrench()
    {
        foreach (var pair in textPairs)
        {
            pair.textObject.text = pair.frenchText;
        }
    }
}
