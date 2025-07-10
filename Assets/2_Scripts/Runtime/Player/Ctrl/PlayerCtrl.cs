using System;
using Sirenix.OdinInspector;
using UnityEngine;
using Object = UnityEngine.Object;

public class PlayerCtrl : MonoBehaviour
{
    [Title("References")]
    [SerializeField] private MoveHelper mMoveHelper;
    [SerializeField] private GrabHelper mGrabHelper;

    public void OnStart(Object sender)
    {
        mMoveHelper?.OnStart(sender);
    }

    public void SubInputEvent(InputHandler handler)
    {
        #region Move

        if (mMoveHelper)
        {
            handler.OnMoveBegin += mMoveHelper.OnInputMoveBegin;
            handler.OnMoving += mMoveHelper.OnInputMoving;
            handler.OnMoveEnd += mMoveHelper.OnInputMoveEnd;
        }

        #endregion

        #region Grab

        if (mGrabHelper)
        {
            handler.OnGrabBegin += mGrabHelper.OnInputGrabBegin;
            handler.OnGrabbing += mGrabHelper.OnInputGrabbing;
            handler.OnGrabEnd += mGrabHelper.OnInputGrabEnd;
        }

        #endregion

    }

    public void UnSubInputEvent(InputHandler handler)
    {
        #region Move

        if (mMoveHelper)
        {
            handler.OnMoveBegin -= mMoveHelper.OnInputMoveBegin;
            handler.OnMoving -= mMoveHelper.OnInputMoving;
            handler.OnMoveEnd -= mMoveHelper.OnInputMoveEnd;
        }

        #endregion

        #region Grab

        if (mGrabHelper)
        {
            handler.OnGrabBegin -= mGrabHelper.OnInputGrabBegin;
            handler.OnGrabbing -= mGrabHelper.OnInputGrabbing;
            handler.OnGrabEnd -= mGrabHelper.OnInputGrabEnd;
        }

        #endregion

    }
}
