using UnityEngine;
using TMPro;

public class NumCar : MonoBehaviour, Interactable3
{
    [SerializeField] private int _prompt;
    int Interactable3.InteractionPrompt => _prompt;
    [SerializeField] private TextMeshProUGUI Text;
    // private Interaction3 _Interaction = new Interaction3() ;
    public static string[,] Answers = {
            {"is","am","are"},
            {"is","am","are"},
            {"is","am","are"},
            {"is","am","are"},
            {"is","am","are"},
            {"is","am","are"},
            {"is","am","are"},
            {"am","is","are"},
            {"are","am","am"},
            {"is","am","are"},
            {"ALL","TOO","WELL"},
    };

    private void Update() 
    {
        // Debug.Log(Interaction3.CountAnswers);
        if(_prompt == 1)
        {
            Text.text = Answers[Interaction3.ArrayIndex,0];
        }
        else if(_prompt == 2)
        {
            Text.text = Answers[Interaction3.ArrayIndex,1];
        }
        else if(_prompt == 3)
        {
            Text.text = Answers[Interaction3.ArrayIndex,2];
        }
    }

    bool Interactable3.Interect3(Interaction3 interactor)
    {
        return false;
    }
}
