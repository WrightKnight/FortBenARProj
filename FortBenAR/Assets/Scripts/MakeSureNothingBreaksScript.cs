using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeSureNothingBreaksScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("ActiveTour", "");
        PlayerPrefs.SetString("Objective", "");
        PlayerPrefs.SetString("Scene", "");
        PlayerPrefs.SetInt("Page", 0);
    }
}
