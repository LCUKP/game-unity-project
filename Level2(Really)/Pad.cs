using UnityEngine;

public class Pad : MonoBehaviour, Interactable2
{
    [SerializeField] private bool _prompt;
    [SerializeField] private int NunPad;
    bool Interactable2.InteractionPrompt => _prompt;
    int Interactable2.NunPad => NunPad;

    bool Interactable2.Interect2(Interaction2 interactor)
    {
        return false;
    }
}
