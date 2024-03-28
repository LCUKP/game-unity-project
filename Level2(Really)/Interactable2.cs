using UnityEngine;

public interface Interactable2
{
    [HideInInspector] public bool InteractionPrompt { get; }
    [HideInInspector] public int NunPad { get; }
    [HideInInspector] public bool Interect2(Interaction2 interactor);
}

