using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AnswerScript : MonoBehaviour
{
    public QuizManager quizManager;
    public bool isCorrect = false;
    public void Answer()
    {
        if (isCorrect)
        {
            quizManager.correct();
            AudioManager.Instance.PlaySound("Correct");
                      
        }
        else
        {
            quizManager.incorrect();
            AudioManager.Instance.PlaySound("Incorrect");

        }
    }
}
