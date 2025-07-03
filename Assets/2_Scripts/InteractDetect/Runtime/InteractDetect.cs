using System;
using Sirenix.OdinInspector;
using UnityEngine;

public class InteractDetect : MonoBehaviour
{
    [Title("Option")]
    [SerializeField] private InteractDetectOption mInteractDetectOption;

    [Title("References")]
    [SerializeField] private Transform mRayTransform;

    private Interact _mInteractCurrent;
    
    private void Start()
    {
        GlobalManager.Instance.Input.OnInteractDetectOn += OnInteractDetectOn;
        GlobalManager.Instance.Input.OnInteractDetectOff += OnInteractDetectOff;
    }

    private void OnInteractDetectOn(bool isInteract)
    {
        if (!_mInteractCurrent)
            return;
       
        // 자동이면 배제
        if (_mInteractCurrent.Option.IsAuto)
            return;
        
        _mInteractCurrent.OnDetect(this);
    }
    
    private void OnInteractDetectOff(bool isInteract)
    {
        if (!_mInteractCurrent)
            return;
    }

    private void Update()
    {
        Update_Ray();
        Update_UI();
    }

    private void Update_Ray()
    {
        float yAngle = mRayTransform.eulerAngles.y - 90f;
        yAngle *= Mathf.Deg2Rad;
        
        float x = Mathf.Cos(yAngle);
        float z = Mathf.Sin(yAngle) * -1;

        Vector3 dir = new Vector3(x, 0, z);
        
        Debug.DrawRay(
            mRayTransform.position + new Vector3(0, mInteractDetectOption.RayHeight, 0), 
            dir * mInteractDetectOption.RayDistance);

        if (!Physics.Raycast(mRayTransform.position, dir, out RaycastHit hit, mInteractDetectOption.RayDistance))
        {
            _mInteractCurrent = null;
            return;
        }
        
        if (!hit.collider.gameObject.TryGetComponent(out _mInteractCurrent))
        {
            _mInteractCurrent = null;
            return;
        }
        
        if (!_mInteractCurrent.Option.IsAuto)
        {
            return;
        }
            
        _mInteractCurrent.OnDetect(this);
    }

    private void Update_UI()
    {
        if (_mInteractCurrent)
        {
            
        }

        else
        {
            
        }
    }
}
