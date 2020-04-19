using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TourChecker : MonoBehaviour
{
    public string ActiveTour;

    void Start()
    {
        ActiveTour = PlayerPrefs.GetString("ActiveTour");
        if (ActiveTour != "")
        {
            loadTourScreen();
        }
    }

    public void loadTourScreen()
    {
        SceneManager.LoadScene("TourScreen");
    }
}
