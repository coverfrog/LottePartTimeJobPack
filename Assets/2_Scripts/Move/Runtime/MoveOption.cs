using System;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public class MoveOption
{
    [Title("Flag")] 
    [SerializeField] private bool mIsLocal;
    [SerializeField] private bool mIsInput = true;
    [SerializeField] private bool mIsUseAnimator = true;

    public bool IsLocal => mIsLocal;
    public bool IsInput => mIsInput;
    public bool IsUseAnimator => mIsUseAnimator;
    

    [Title("Animator")]
    [SerializeField] private string mKeyNormal = "IsMove";

    public string KeyNormal => mKeyNormal;
}
