using UnityEngine;


[CreateAssetMenu(fileName = "New Timeline Event", menuName = "FortBenAR/TimelineEvent")]
public class TimelineEvent : ScriptableObject
{
    public string PlaceName;
    public string Date;
    public PictureLibrary pictureLibrary;

    [TextArea(3, 5)]
    public string description = "Description";
}
