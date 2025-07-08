using Sirenix.OdinInspector;
using UnityEngine;

public class MoveHelper : MonoBehaviour
{
    [Title("Option")]
    [SerializeField] private float mSpeedCurrent = 3.0f;
    [SerializeField] private MoveActor mMoveActor;

    #region Get

    public float SpeedCurrent => mSpeedCurrent;

    #endregion
    
    [Title("References")]
    [SerializeField] private Rigidbody mRigidBody;
    [SerializeField] private Animator mAnimator;

    #region Get

    public Rigidbody RigidBody => mRigidBody;

    public Animator Animator => mAnimator;

    #endregion
    
    public void OnStart(Object sender)
    {
        
    }

    public void OnInputMoveBegin(Vector2 dir)
    {
        mMoveActor?.MoveBegin(this, dir);
    }

    public void OnInputMoving(Vector2 dir)
    {
        mMoveActor?.Moving(this, dir);
    }

    public void OnInputMoveEnd(Vector2 dir)
    {
        mMoveActor?.MoveEnd(this, dir);
    }
}
