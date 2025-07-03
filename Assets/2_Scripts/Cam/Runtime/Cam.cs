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
    [SerializeField] private Camera mCamera;
    [SerializeField] private Transform mTarget;

    public Camera Camera => mCamera;
    public Transform Target => mTarget;

    private void Start()
    {
        GlobalManager.Instance.Cam.Sub(this);
    }

    private void OnDestroy()
    {
        if (GlobalManager.Instance)
        {
            GlobalManager.Instance.Cam.UnSub(this);
        }
    }

    private void LateUpdate()
    {
        mCamFunc?.OnLateUpdate(this);
    }
}
