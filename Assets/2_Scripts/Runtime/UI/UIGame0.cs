using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;
using Object = UnityEngine.Object;

public class UIGame0 : MonoBehaviour
{
    [Title("References")]
    [SerializeField] private UIGrab mUIGrab;
 
    [Title("References")]
    [SerializeField] private GrabHelper mGrabHelper;

    #region OnStart

    public void OnStart(Object sender)
    {
        EventSub_Grab();
        
        mUIGrab.OnStart(this);
    }

    #endregion

    #region OnDestroy

    public void OnDestroy()
    {
        EventUnSub_Grab();
    }

    #endregion

    #region EventSub_Grab

    private void EventSub_Grab()
    {
        mUIGrab?.EventSub(mGrabHelper);
    }
    
    #endregion

    #region EventUnSub_Grab

    private void EventUnSub_Grab()
    {
        mUIGrab?.EventUnSub(mGrabHelper);
    }

    #endregion
}
