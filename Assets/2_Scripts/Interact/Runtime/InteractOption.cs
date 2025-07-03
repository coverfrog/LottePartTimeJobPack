using System;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public class InteractOption
{
    [Title("Flag")]
    [SerializeField] private bool mIsAuto;

    public bool IsAuto => mIsAuto;

    [Title("Type")]
    [SerializeField] private InteractType mInteractType;

    public InteractType InteractType => mInteractType;

    [Title("Value")] 
    [SerializeField] private int mCount = 1;
    [SerializeField] private string mStringValue;

    public int Count => mCount;
    public string StringValue => mStringValue;
}
