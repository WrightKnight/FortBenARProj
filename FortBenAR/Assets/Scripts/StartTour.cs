using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartTour : MonoBehaviour
{
    public Tour targetTour;
    public Text TourName;
    public Text TourDesc;

    public TourChecker tourThing;

    public void Start()
    {
        TourName.text = targetTour.TourName;
        TourDesc.text = targetTour.description;
    }

    public void ButtonClick()
    {
        PlayerPrefs.SetString("ActiveTour", targetTour.name);
        Invoke("Launch", 1);
    }

    void Launch()
    {
        tourThing.loadTourScreen();
    }

}
