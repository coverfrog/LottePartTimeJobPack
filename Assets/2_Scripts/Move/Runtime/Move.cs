using System;
using Sirenix.OdinInspector;
using UnityEngine;

public class Move : MonoBehaviour
{
    [Title("Option")]
    [SerializeField] private MoveBase mMoveFunc;
    [SerializeField] private MoveOption mMoveOption;
    
    [Title("References")]
    [SerializeField] private Rigidbody mRigidBody;
    [SerializeField] private Animator mAnimator;

    private void Start()
    {
        if (mMoveOption.IsInput)
        {
            GlobalManager.Instance.Input.OnMoveBegin += OnMoveBegin;
            GlobalManager.Instance.Input.OnMoving += OnMoving;
            GlobalManager.Instance.Input.OnMoveEnd += OnMoveEnd;
        }
    }

    private void OnDestroy()
    {
        if (mMoveOption.IsInput && GlobalManager.Instance != null)
        {
            GlobalManager.Instance.Input.OnMoveBegin -= OnMoveBegin;
            GlobalManager.Instance.Input.OnMoving -= OnMoving;
            GlobalManager.Instance.Input.OnMoveEnd -= OnMoveEnd;
        }
    }

    private void OnMoveBegin(Vector2 dir)
    {
        if (mMoveOption.IsUseAnimator)
        {
            mAnimator.SetBool(mMoveOption.KeyNormal, true);
        }
        
        mMoveFunc.MoveBegin(new MoveData()
        {
            rigidBody = mRigidBody,
            dir = dir,
            moveSpeed = mMoveOption.MoveSpeedCurrent,
            rotSpeed = mMoveOption.RotSpeedCurrent
        });
    }

    private void OnMoving(Vector2 dir)
    {
        if (mMoveOption.IsUseAnimator)
        {
            mAnimator.SetBool(mMoveOption.KeyNormal, true);
        }
        
        mMoveFunc.Moving(new MoveData()
        {
            rigidBody = mRigidBody,
            dir = dir,
            moveSpeed = mMoveOption.MoveSpeedCurrent,
            rotSpeed = mMoveOption.RotSpeedCurrent
        });
    }

    private void OnMoveEnd(Vector2 dir)
    {
        if (mMoveOption.IsUseAnimator)
        {
            mAnimator.SetBool(mMoveOption.KeyNormal, false);
        }
        
        mMoveFunc.MoveEnd(new MoveData()
        {
            rigidBody = mRigidBody,
            dir = Vector2.zero,
            moveSpeed = 0,
            rotSpeed = 0
        });   
    }
}
