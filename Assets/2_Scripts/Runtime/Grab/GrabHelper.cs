using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class GrabHelper : MonoBehaviour
{
    [Title("Option")] 
    [SerializeField] private float mDetectDistance = 1.0f;
    [SerializeField] private uint mDetectCount = 20;
    [SerializeField] private LayerMask mDetectLayer = ~0;

    #region Get

    public float DetectDistance => mDetectDistance;
    public int DetectCount => (int)mDetectCount;
    public LayerMask DetectLayer => mDetectLayer;

    #endregion
    
    [Title("Actor")]
    [SerializeField] private GrabDetectActor mDetectActor;

    [Title("References")]
    [SerializeField] private Transform mGrabbedParent;

    #region Get

    public Transform GrabbedParent => mGrabbedParent;

    #endregion
    
    private GrabObject _mGrabObject;
    
    private bool _mIsDetect;
    private bool _mIsGrab;

    #region Delegate

    public delegate void DetectDelegate(List<GrabObject> grabObjectList);

    public delegate void GrabDelegate(GrabObject grabObject);
    
    #endregion

    #region Event

    public event DetectDelegate OnActDetect;

    public event DetectDelegate OnActDetecting;

    public event DetectDelegate OnActUnDetect;

    public event GrabDelegate OnActGrab;

    public event GrabDelegate OnActGrabbing;

    public event GrabDelegate OnActUnGrab;

    #endregion
    
    #region OnInputGrabBegin

    public void OnInputGrabBegin(bool isPress, float duration)
    {
        if (!_mIsDetect) 
            return;
        
        if (_mIsGrab) 
            return;

        _mIsGrab = true;
        _mGrabObject.Grab(this);

        OnUnDetect(null);
        
        OnActGrab?.Invoke(_mGrabObject);
    }
    
    #endregion

    #region OnInputGrabbing
    
    public void OnInputGrabbing(bool isPress, float duration)
    {
        if (!_mIsDetect) 
            return;
        
        if (!_mIsGrab) 
            return;
        
        OnActGrabbing?.Invoke(_mGrabObject);
    }

    #endregion
    
    #region OnInputGrabEnd
    
    public void OnInputGrabEnd(bool isPress, float duration)
    {
        if (!_mIsGrab)
            return;
        
        if (!_mGrabObject)
            return;
        
        _mIsGrab = false;
        _mGrabObject.UnGrab(this);
        
        OnActUnGrab?.Invoke(_mGrabObject);
    }

    #endregion

    #region OnDetect

    private void OnDetect(List<GrabObject> grabObjectList)
    {
        if (grabObjectList == null)
            return;
        
        if (grabObjectList.Count == 0)
            return;
        
        if (_mIsGrab)
            return;

        _mGrabObject = grabObjectList[0];
        
        OnActDetect?.Invoke(grabObjectList);
    }

    #endregion

    #region OnDetecting

    private void OnDetecting(List<GrabObject> grabObjectList)
    {
        if (grabObjectList == null)
            return;
        
        if (grabObjectList.Count == 0)
            return;
        
        if (_mIsGrab)
            return;
        
        _mGrabObject = grabObjectList[0];
        
        OnActDetecting?.Invoke(grabObjectList);
    }

    #endregion
    
    #region OnUnDetect

    private void OnUnDetect(List<GrabObject> grabObjectList)
    {
        _mGrabObject = null;
        
        OnActUnDetect?.Invoke(grabObjectList);
    }

    #endregion
    
    #region Update

    public void Update()
    {
        Update_Detect();
    }

    private void Update_Detect()
    {
        if (mDetectActor.Detect(this, out List<GrabObject> grabObjectList))
        {
            if (_mIsDetect)
            {
                OnDetecting(grabObjectList);
            }

            else
            {
                _mIsDetect = true;

                OnDetect(grabObjectList);
            }
        }

        else
        {
            if (!_mIsDetect)
            {
                return;
            }

            _mIsDetect = false;

            OnUnDetect(grabObjectList);
        }
    }

    #endregion

}
