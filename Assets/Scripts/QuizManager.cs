using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using UnityEngine.EventSystems;

public class QuizManager : MonoBehaviour
{
    public GameObject[] hearts;
    private int life;
    public List<QuestionsAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;
    public GameObject GoPanel;
    public GameObject PausePanel;
    public GameObject SettingsPanel;
    public Text QuestionTxt;
    public Text ScoreTxt;
    public Text InGameScoreTxt;
    int totalQuestions = 0;
    public int score;
    public int ingamescore;
    [SerializeField] private float timeLimit;
    private float currentTime;
    private bool keepTiming = true;
    [SerializeField] private Text timerText;
    public Text TimerText { get => timerText; }
    private string categoryName;
    public GameObject nextBtn;
    public GameObject nextSprite;
    public int m;
    public GameObject[] Option;
    Color startingColor;  
    [SerializeField] Image image; 
    public Button[] answerButtons;
    public GameObject clickedButton;
    public int currentEnergy;
    [SerializeField] Text energyTextGO;
    [SerializeField] Text energyTextPO;





    public void Start()
    {
        startingColor = image.color;
        currentTime = timeLimit;
        life = hearts.Length;
        totalQuestions = QnA.Count;
        InGameScoreTxt.text = ingamescore + "/" + totalQuestions;
        GoPanel.SetActive(false);
        PausePanel.SetActive(false);
        answerButtons = GameObject.FindObjectsOfType<Button>();
        generateQuestion();


    }



    void Update()
    {
        if (keepTiming == true)
        {
            currentTime -= Time.deltaTime;
            SetTime(currentTime);
        }
        currentEnergy = PlayerPrefs.GetInt("currentEnergy");
        energyTextGO.text = currentEnergy.ToString() + "/50";
        energyTextPO.text = currentEnergy.ToString() + "/50";


    }
    void SetTime(float value)
    {
        TimeSpan time = TimeSpan.FromSeconds(currentTime);                       //set the time value
        TimerText.text = time.ToString("mm':'ss");   //convert time to Time format

        if (currentTime <= 0)
        {
            //Game Over
            AudioManager.Instance.StopSound("Music");
            AudioManager.Instance.PlaySound("Lose");
            GameOver();
        }
    }

    public void retry()
    { 
        if (PlayerPrefs.GetInt("currentEnergy") >= 10)
        {
            PlayerPrefs.SetInt("currentEnergy", currentEnergy - 10);
            AudioManager.Instance.PlaySound("Click");
            AudioManager.Instance.PlayMusic("Music");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
            AudioManager.Instance.PlaySound("Incorrect");
    }
    public void pause()
    {  
        PausePanel.SetActive(true);
        AudioManager.Instance.PlaySound("Click");
        AudioManager.Instance.StopSound("Music");
        keepTiming = false;


    }
    public void adreward()
    {
        if (PlayerPrefs.GetInt("currentEnergy") <= 40)
            PlayerPrefs.SetInt("currentEnergy", currentEnergy + 10);
        else
            AudioManager.Instance.PlaySound("Incorrect");

    }  
    public void resume()
    {
        PausePanel.SetActive(false);
        AudioManager.Instance.PlaySound("Click");
        AudioManager.Instance.PlaySound("Music");
        keepTiming = true;
    }
    public void nextScene()
    {
        if (PlayerPrefs.GetInt("currentEnergy") >= 10)
        {
            PlayerPrefs.SetInt("currentEnergy", currentEnergy - 10);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            AudioManager.Instance.PlaySound("Click");
            AudioManager.Instance.PlayMusic("Music");
        }
        else
            AudioManager.Instance.PlaySound("Incorrect");
    }

    public void inGameScore()
    {
        ingamescore++;
        InGameScoreTxt.text = ingamescore + "/" + totalQuestions;
    }

    void GameOver()
    {
        GoPanel.SetActive(true);
        keepTiming = false;
        AudioManager.Instance.StopSound("Music");
        ScoreTxt.text = "You got " + score + "/" + totalQuestions + " questions right!";

        categoryName = SceneManager.GetActiveScene().name;
        if (score == 10)
        {
            nextBtn.SetActive(true);
            nextSprite.SetActive(true);
            PlayerPrefs.SetInt(categoryName + "score", 1);
        }
        else
        {
            nextBtn.SetActive(false);
            nextSprite.SetActive(false);
        }
        if (score == 50)
        {
            PlayerPrefs.SetInt(categoryName + "score", 2);
        }
    }
    public void correct()
    {
        
        foreach (Button button in answerButtons)
        {
            button.interactable = false;
        }

        inGameScore();
        score += 1;
        QnA.RemoveAt(currentQuestion);
        Invoke("generateQuestion", 0.4f);
    }
    
    public void incorrect()
    {
        foreach (Button button in answerButtons)
        {
            button.interactable = false;
        }

        if (life >= 1)
        {
            life--;
            Destroy(hearts[life].gameObject);
            if (life < 1)
            {
                GameOver();
                AudioManager.Instance.PlaySound("Lose");
            }
        }
        inGameScore();
        QnA.RemoveAt(currentQuestion);
        if (life != 0)
        {
            Invoke("generateQuestion", 0.4f);
        }
        else
            generateQuestion();
    }

    void SetAnswers()
    { 
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];
            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
                m = i;
            }
        }
    }
    void generateQuestion()
    {
        if (QnA.Count > 0 )
        {  
            currentQuestion = Random.Range(0, QnA.Count);
            QuestionTxt.text = QnA[currentQuestion].Question;
            foreach (Button button in answerButtons)
            {
                button.interactable = true;
            }
            SetAnswers();
        }
        else
        {
            GameOver();
        }
    }
    
    
}