using UnityEngine;

public class Word : MonoBehaviour, Interactable
{
    public char charactor;
    [SerializeField] private char _prompt;
    char Interactable.InteractionPrompt => _prompt;
    
    bool Interactable.Interect(Interaction interactor)
    {
        return false;
    }

    // Update is called once per frame

}
