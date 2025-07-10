using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

public class MoveHelper : MonoBehaviour
{
    [Title("Option")]
    [SerializeField] private float mMoveSpeedCurrent = 3.0f;
    [SerializeField] private float mRotSpeedCurrent = 10.0f;

    #region Get

    public float MoveSpeedCurrent => mMoveSpeedCurrent;

    public float RotSpeedCurrent => mRotSpeedCurrent;
    
    #endregion

    [Title("Actor")]
    [SerializeField] private MoveActor mMoveActor;
    
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

    public void OnInputMoveBegin(Vector2 dir, float duration)
    {
        mMoveActor?.MoveBegin(this, dir, duration);
    }

    public void OnInputMoving(Vector2 dir, float duration)
    {
        mMoveActor?.Moving(this, dir, duration);
    }

    public void OnInputMoveEnd(Vector2 dir, float duration)
    {
        mMoveActor?.MoveEnd(this, dir, duration);
    }
}
