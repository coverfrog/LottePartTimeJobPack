using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class UIGrab : MonoBehaviour
{
    #region OnStart

    public void OnStart(Object sender)
    {
        OnGrabUnDetect(null);
    }

    #endregion

    #region EventSub

    public void EventSub(GrabHelper grabHelper)
    {
        if (!grabHelper) return;
        
        grabHelper.OnActDetect += OnGrabDetect;
        grabHelper.OnActDetecting += OnGrabDetecting;
        grabHelper.OnActUnDetect += OnGrabUnDetect;
    }

    #endregion

    #region EventUnSub

    public void EventUnSub(GrabHelper grabHelper)
    {
        if (!grabHelper) return;
        
        grabHelper.OnActDetect -= OnGrabDetect;
        grabHelper.OnActDetecting -= OnGrabDetecting;
        grabHelper.OnActUnDetect -= OnGrabUnDetect;
    }
    
    #endregion
    
    #region OnGrabDetect

    private void OnGrabDetect(List<GrabObject> grabobjectlist)
    {
        gameObject.SetActive(true);
    }

    #endregion

    #region OnGrabDetecting

    private void OnGrabDetecting(List<GrabObject> grabobjectlist)
    {
        
    }

    #endregion

    #region OnGrabUnDetect

    private void OnGrabUnDetect(List<GrabObject> grabobjectlist)
    {
        gameObject.SetActive(false);
    }

    #endregion
    

}
