using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerBox : MonoBehaviour, Interactable5
{
    [SerializeField] private char _prompt;
    char Interactable5.InteractionPrompt => _prompt;

    public static char[,] AnswerTrueL5 = new char[12,1]
    {
    {'C'},
    {'C'},
    {'B'},
    {'B'},
    {'B'},
    {'A'},
    {'D'},
    {'A'},
    {'C'},
    {'A'},
    {'D'},
    {'B'},
    };


    bool Interactable5.Interaction5(Interaction5 interactor)
    {
        return true;
    }

}
