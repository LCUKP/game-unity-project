using UnityEngine;

public interface Interactable3
{
    [HideInInspector] public int InteractionPrompt { get; }
    [HideInInspector] public bool Interect3(Interaction3 interactor);
}

