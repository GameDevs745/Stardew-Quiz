using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    public Button[] answerButtons;
    public QuizManager quizManager;
    private Image answer;
    [SerializeField] Image image;
    private void Start() {
        // Add event listeners to each answer button
        foreach (Button button in answerButtons) {
            button.onClick.AddListener(() => HandleAnswerButtonClick(button));
            
        }
    }

    private void HandleAnswerButtonClick(Button button) {
        answer = button.GetComponent<Image>();
        AnswerScript ansScript = button.GetComponent<AnswerScript>();
        bool isTrue= ansScript.isCorrect;

        if (isTrue== true) {
            StartCoroutine(ColorRight());
            quizManager.correct();
            AudioManager.Instance.PlaySound("Correct");
        } else {
            StartCoroutine(ColorWrong());
            quizManager.incorrect();
            AudioManager.Instance.PlaySound("Incorrect");
            
        }

        // Disable all answer buttons to prevent clicking again
        foreach (Button otherButton in answerButtons) {
            otherButton.interactable = false;
        }
    }

    IEnumerator ColorWrong()
    {  
        for (int j = 0; j < 2; j++)
        {
            answer.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            answer.color = image.color;
            yield return new WaitForSeconds(0.1f);
        }
    }
    IEnumerator ColorRight()
    {  
        for (int j = 0; j < 2; j++)
        {
            answer.color = Color.green;
            yield return new WaitForSeconds(0.1f);
            answer.color = image.color;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
