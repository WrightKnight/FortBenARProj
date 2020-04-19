using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTourChecker : MonoBehaviour
{
    public string ActiveTour;
    public string CurrentObjective;

    public GameObject[] points;

    public Sprite objectiveMarker;
    public Sprite normalMarker;

    void Start()
    {
        ActiveTour = PlayerPrefs.GetString("ActiveTour");
        CurrentObjective = PlayerPrefs.GetString("Objective");

        if (ActiveTour != "")
        {
            foreach (GameObject i in points)
            {
                if (i.GetComponent<MapPointInfoSummon>().placeInfo.name == CurrentObjective)
                {
                    i.GetComponent<SpriteRenderer>().sprite = objectiveMarker;
                } else
                {
                    i.GetComponent<SpriteRenderer>().sprite = normalMarker;
                }
            }
        }
    }
}
