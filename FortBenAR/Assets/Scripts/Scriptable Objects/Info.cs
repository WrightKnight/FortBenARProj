using UnityEngine;


[CreateAssetMenu(fileName = "New Info Object", menuName = "FortBenAR/Info")]
public class Info : ScriptableObject
{
    public string PlaceName;
    public PictureLibrary pictureLibrary;

    [TextArea(3, 5)]
    public string description = "Description";
}
