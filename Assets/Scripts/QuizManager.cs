using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class QuestionPanel
{
    public GameObject panel;
    public TMP_Text[] answerTexts;
    public int correctAnswerIndex;
}

public class QuizManager : MonoBehaviour
{
    [Header("Questions")]
    public QuestionPanel[] questions;   
    private int currentIndex = 0;       

    private TMP_Text[] answerTexts;     
    private int correctAnswerIndex;     
    private bool answered = false;      

    [Header("Progress")]
    public Slider progressSlider;       
    private int score = 0;

    [Header("Audio")]
    public AudioClip correctSound;
    public AudioClip wrongSound;
    private AudioSource audioSource;

    [Header("UI")]
    public TMP_Text finalScoreText; // assign in Inspector

    void Start()
    {
        // Setup AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.volume = 1f;

        // Setup slider
        if (progressSlider != null)
        {
            progressSlider.minValue = 0;
            progressSlider.maxValue = questions.Length;
            progressSlider.value = 0;
        }

        // Hide final score initially
        if (finalScoreText != null)
            finalScoreText.gameObject.SetActive(false);

        LoadQuestion(0);
    }

    public void LoadQuestion(int index)
    {
        foreach(var q in questions)
            q.panel.SetActive(false);
        
        questions[index].panel.SetActive(true);
        
        answerTexts = questions[index].answerTexts;
        correctAnswerIndex = questions[index].correctAnswerIndex;
        
        ResetQuestion();    
    }

    public void OnAnswerSelected(int index)
{
    if (answered) return;

    for(int i = 0; i < answerTexts.Length; i++)
    {
        if (i == correctAnswerIndex)
            answerTexts[i].color = Color.green;
        else if (i == index)
            answerTexts[i].color = Color.red;
        else
            answerTexts[i].color = Color.white;        
    }

    // Play sounds and update score
    if (index == correctAnswerIndex)
    {
        score++;
        if(progressSlider != null)
            progressSlider.value = score;

        if (correctSound != null)
            audioSource.PlayOneShot(correctSound);
    }
    else
    {
        if (wrongSound != null)
            audioSource.PlayOneShot(wrongSound);
    }

    answered = true;


    // ************ ADD THIS BLOCK ************
    // If this is the last question, show final score now
    if (currentIndex == questions.Length - 1)
    {
        float percentage = ((float)score / questions.Length) * 100f;

        if (finalScoreText != null)
        {
            finalScoreText.text = 
                "Your Score: " + score + "/" + questions.Length +
                " (" + percentage.ToString("F1") + "%)";

            finalScoreText.gameObject.SetActive(true);
        }
    }
}

    public void NextQuestion()
    {
        currentIndex++;
        if (currentIndex < questions.Length)
        {
            LoadQuestion(currentIndex);
        }
        else
        {
            // Hide all question panels
            foreach(var q in questions)
                q.panel.SetActive(false);

            // Calculate percentage
            float percentage = ((float)score / questions.Length) * 100f;

            // Show final score
            if (finalScoreText != null)
            {
                finalScoreText.text = "Score: " + score + "/" + questions.Length
                                      + " (" + percentage.ToString("F1") + "%)";
                finalScoreText.gameObject.SetActive(true);
            }

            Debug.Log("Quiz Finished! Score: " + score + "/" + questions.Length);
        }    
    }

    public void ResetQuestion()
    {
        foreach(var t in answerTexts)
            t.color = Color.white;

        answered = false;    
    }
}
