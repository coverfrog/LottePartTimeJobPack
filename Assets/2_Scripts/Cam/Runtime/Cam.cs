using System;
using Sirenix.OdinInspector;
using UnityEngine;

public class Cam : MonoBehaviour
{
    [Title("Option")] 
    [SerializeField] private CamBase mCamFunc;
    [SerializeField] private CamOption mCamOption;

    public CamOption Option => mCamOption;
    
    [Title("References")]
    [SerializeField] private Transform mTarget;

    public Transform Target => mTarget;
    
    private void LateUpdate()
    {
        mCamFunc?.OnLateUpdate(this);
    }
}
