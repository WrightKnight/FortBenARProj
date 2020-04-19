using UnityEngine;


[CreateAssetMenu(fileName = "New Picture Library", menuName = "FortBenAR/PicLibrary")]
public class PictureLibrary : ScriptableObject
{
    public Sprite[] images;
    
    [TextArea(3, 5)]
    public string[] description;
}
