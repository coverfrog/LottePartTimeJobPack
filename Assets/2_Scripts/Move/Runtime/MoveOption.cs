using System;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public class MoveOption
{
    [Title("Flag")]
    [SerializeField] private bool mIsInput = true;
    [SerializeField] private bool mIsUseAnimator = true;

    public bool IsInput => mIsInput;
    public bool IsUseAnimator => mIsUseAnimator;
    
    [Title("Speed")] 
    [SerializeField] private float mMoveSpeedCurrent = 3.0f;
    [SerializeField] private float mRotSpeedCurrent = 8.0f;

    public float MoveSpeedCurrent => mMoveSpeedCurrent;
    public float RotSpeedCurrent => mRotSpeedCurrent;

    [Title("Animator")]
    [SerializeField] private string mKeyNormal = "IsMove";

    public string KeyNormal => mKeyNormal;
}
