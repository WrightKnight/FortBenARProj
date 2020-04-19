using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TourManager : MonoBehaviour
{
    public Tour[] TourLibrary;

    public string activeTourName;
    public Tour activeTour;
    public int page = 0;
    public TourEvent activeEvent;

    public GameObject forwardButton;
    public GameObject backButton;
    public Text text;

    public GameObject[] Answers;
    public Text[] AnswerText;

    public void Start()
    {


        if (PlayerPrefs.GetInt("Page") > 0)
        {
            page = PlayerPrefs.GetInt("Page");
        } else
        {
            page = 0;
        }
            

        activeTourName = PlayerPrefs.GetString("ActiveTour");

        foreach (Tour i in TourLibrary)
        {
            if (i.name == activeTourName)
            {
                activeTour = i;
            }
        }

        updateUI();

    }

    public void updateUI()
    {
        activeEvent = activeTour.tourEvents[page];
        text.text = activeEvent.description;
        if (page > 0)
        {
            backButton.SetActive(true);
        }
        else
        {
            page = 0;
            backButton.SetActive(false);
        }

        if (activeEvent.Location != null)
        {
            PlayerPrefs.SetString("Objective", activeEvent.Location.name);
        } else
        {
            PlayerPrefs.SetString("Objective", "");
        }

        if (activeEvent.IsQuestion == true)
        {
            Debug.Log("It detected a question.");
            isAQuestion();
        } else
        {
            foreach (GameObject i in Answers)
            {
                i.SetActive(false);
                forwardButton.SetActive(true);
            }
        }
    }

    public void AnsweredQuestion()
    {
        forwardButton.SetActive(true);
        foreach (GameObject i in Answers)
        {
            i.SetActive(false);
        }
    }

    public void isAQuestion()
    {
        forwardButton.SetActive(false);
        if (activeEvent.AnswerA != "")
        {
            Answers[0].SetActive(true);
            Answers[0].GetComponent<AnswerTheQuestion>().question = activeEvent;
            AnswerText[0].text = activeEvent.AnswerA;
            if (activeEvent.AIsCorrect)
            {
                Answers[0].GetComponent<AnswerTheQuestion>().IsCorrect = true;
            }
            else
            {
                Answers[0].GetComponent<AnswerTheQuestion>().IsCorrect = false;
            }
        }

        if (activeEvent.AnswerB != "")
        {
            Answers[1].SetActive(true);
            Answers[1].GetComponent<AnswerTheQuestion>().question = activeEvent;
            AnswerText[1].text = activeEvent.AnswerB;
            if (activeEvent.BIsCorrect)
            {
                Answers[1].GetComponent<AnswerTheQuestion>().IsCorrect = true;
            }
            else
            {
                Answers[1].GetComponent<AnswerTheQuestion>().IsCorrect = false;
            }
        }

        if (activeEvent.AnswerC != "")
        {
            Answers[2].SetActive(true);
            Answers[2].GetComponent<AnswerTheQuestion>().question = activeEvent;
            AnswerText[2].text = activeEvent.AnswerC;
            if (activeEvent.CIsCorrect)
            {
                Answers[2].GetComponent<AnswerTheQuestion>().IsCorrect = true;
            }
            else
            {
                Answers[2].GetComponent<AnswerTheQuestion>().IsCorrect = false;
            }
        }

        if (activeEvent.AnswerD != "")
        {
            Answers[3].SetActive(true);
            Answers[3].GetComponent<AnswerTheQuestion>().question = activeEvent;
            AnswerText[3].text = activeEvent.AnswerD;
            if (activeEvent.DIsCorrect)
            {
                Answers[3].GetComponent<AnswerTheQuestion>().IsCorrect = true;
            }
            else
            {
                Answers[3].GetComponent<AnswerTheQuestion>().IsCorrect = false;
            }
        }
    }

    public void goForward()
    {
        if (activeEvent.isTheEnd == false)
        {
            page = page + 1;
            PlayerPrefs.SetInt("Page", page);
            updateUI();
        }
        else
        {
            EndTour();
        }
    }

    public void goBack()
    {
        page = page - 1;
        PlayerPrefs.SetInt("Page", page);
        updateUI();
    }

    public void EndTour()
    {
        PlayerPrefs.SetString("ActiveTour", "");
        PlayerPrefs.SetString("Objective", "");
        PlayerPrefs.SetInt("Page", 0);
        SceneManager.LoadScene("TourStart");
    }
}
