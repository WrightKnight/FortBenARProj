using UnityEngine;


[CreateAssetMenu(fileName = "New Tour Event", menuName = "FortBenAR/TourEvent")]
public class TourEvent : ScriptableObject
{
    [TextArea(3, 5)]
    public string description = "Text";

    public Info Location;

    public bool IsQuestion;

    public string AnswerA;
    public bool AIsCorrect;

    public string AnswerB;
    public bool BIsCorrect;

    public string AnswerC;
    public bool CIsCorrect;

    public string AnswerD;
    public bool DIsCorrect;

    [TextArea(3, 5)]
    public string IsCorrectText = "That's Correct!";

    [TextArea(3, 5)]
    public string IsIncorrectText = "I'm afraid that's... not quite right.";

    public bool isTheEnd;
}
