using System;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public class InteractData
{
    [Title("Flag")]
    [SerializeField] private bool mIsCanInteract = true;
    [SerializeField] private bool mIsInteracting = false;

    public bool IsCanInteract => mIsCanInteract;
    public bool IsInteracting => mIsInteracting;

    public void SetIsCanInteract(Interact interact, bool value) => mIsCanInteract = value;

    public void SetIsInteracting(Interact interact, bool value) => mIsInteracting = value;
    
}
