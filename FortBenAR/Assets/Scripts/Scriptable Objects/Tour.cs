using UnityEngine;


[CreateAssetMenu(fileName = "New Tour", menuName = "FortBenAR/Tour")]
public class Tour : ScriptableObject
{
    public string TourName;

    [TextArea(3, 5)]
    public string description = "Description";

    public TourEvent[] tourEvents;
}