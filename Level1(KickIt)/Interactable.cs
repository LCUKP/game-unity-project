using UnityEngine;

public interface Interactable
{
    [HideInInspector] public char InteractionPrompt { get; }
    [HideInInspector] public bool Interect(Interaction interactor);
}

