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

    void Start()
    {
        // Setup AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;

        if (progressSlider != null)
        {
            progressSlider.minValue = 0;
            progressSlider.maxValue = questions.Length;
            progressSlider.value = 0;
        }

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

        // Play sounds
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
    }

    public void NextQuestion()
    {
        currentIndex++;
        if (currentIndex < questions.Length)
            LoadQuestion(currentIndex);
        else
            Debug.Log("Quiz Finished!");    
    }

    public void ResetQuestion()
    {
        foreach(var t in answerTexts)
            t.color = Color.white;

        answered = false;    
    }
}

     