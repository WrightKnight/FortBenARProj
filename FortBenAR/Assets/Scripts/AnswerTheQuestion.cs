using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerTheQuestion : MonoBehaviour
{
    public TourManager manager;
    public TourEvent question;
    public bool IsCorrect;

    public Text text;

    public void OnAnswer()
    {
        if (IsCorrect == true)
        {
            text.text = question.IsCorrectText;
        }
        else
        {
            text.text = question.IsIncorrectText;
        }

        manager.AnsweredQuestion();
    }
}
