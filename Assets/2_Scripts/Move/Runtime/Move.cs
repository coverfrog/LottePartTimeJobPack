using System;
using Sirenix.OdinInspector;
using UnityEngine;

public class Move : MonoBehaviour
{
    [Title("Option")]
    [SerializeField] private MoveBase mMoveFunc;
    [SerializeField] private MoveOption mMoveOption;

    public MoveOption Option => mMoveOption;

    [Title("Data")] 
    [SerializeField] private MoveData mMoveData;

    public MoveData Data => mMoveData;
    
    [Title("References")]
    [SerializeField] private Rigidbody mRigidBody;
    [SerializeField] private Animator mAnimator;

    public Rigidbody RigidBody => mRigidBody;
    public Animator Animator => mAnimator;
    
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
        Data.dir = dir;
        
        if (mMoveOption.IsUseAnimator)
        {
            mAnimator.SetBool(mMoveOption.KeyNormal, true);
        }
        
        mMoveFunc.MoveBegin(this);
    }

    private void OnMoving(Vector2 dir)
    {
        Data.dir = dir;

        if (mMoveOption.IsUseAnimator)
        {
            mAnimator.SetBool(mMoveOption.KeyNormal, true);
        }
        
        mMoveFunc.Moving(this);
    }

    private void OnMoveEnd(Vector2 dir)
    {
        Data.dir = dir;

        if (mMoveOption.IsUseAnimator)
        {
            mAnimator.SetBool(mMoveOption.KeyNormal, false);
        }
        
        mMoveFunc.MoveEnd(this);   
    }
}
