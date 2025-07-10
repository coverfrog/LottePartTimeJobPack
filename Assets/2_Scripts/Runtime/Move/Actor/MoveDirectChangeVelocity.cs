using UnityEngine;

[CreateAssetMenu(fileName = "Direct Change Velocity", menuName = "Cf/Move/Direct Change Velocity")]
public class MoveDirectChangeVelocity : MoveActor
{
    public override void MoveBegin(MoveHelper moveHelper, Vector2 dir, float duration)
    {
        Move(moveHelper, dir, duration);
        Rotate(moveHelper, dir, duration);
    }

    public override void Moving(MoveHelper moveHelper, Vector2 dir, float duration)
    {
        Move(moveHelper, dir, duration);
        Rotate(moveHelper, dir, duration);
    }

    public override void MoveEnd(MoveHelper moveHelper, Vector2 dir, float duration)
    {
        if (moveHelper.RigidBody)
        {
            moveHelper.RigidBody.linearVelocity = Vector3.zero;
        }
    }

    //
    
    private static void Move(MoveHelper moveHelper, Vector2 dir, float duration)
    {
        if (!moveHelper.RigidBody) 
            return;
   
        moveHelper.RigidBody.linearVelocity = new Vector3(dir.x, 0, dir.y) * moveHelper.MoveSpeedCurrent;
    }
    
    private static void Rotate(MoveHelper moveHelper, Vector2 dir, float duration)
    {
        if (!moveHelper.RigidBody) 
            return;

        Quaternion target = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.y).normalized);
        
        moveHelper.transform.rotation =
            Quaternion.Slerp(
                moveHelper.transform.rotation, 
                target, 
                moveHelper.RotSpeedCurrent * Time.deltaTime);
    }
}
