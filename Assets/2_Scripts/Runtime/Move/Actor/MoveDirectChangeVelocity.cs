using UnityEngine;

[CreateAssetMenu(fileName = "Direct Change Velocity", menuName = "Cf/Move/Direct Change Velocity")]
public class MoveDirectChangeVelocity : MoveActor
{
    public override void MoveBegin(MoveHelper moveHelper, Vector2 dir, float duration)
    {
        if (moveHelper.RigidBody)
        {
            moveHelper.RigidBody.linearVelocity = new Vector3(dir.x, 0, dir.y) * moveHelper.SpeedCurrent;
        }
    }

    public override void Moving(MoveHelper moveHelper, Vector2 dir, float duration)
    {
        if (moveHelper.RigidBody)
        {
            moveHelper.RigidBody.linearVelocity = new Vector3(dir.x, 0, dir.y) * moveHelper.SpeedCurrent;
        }
    }

    public override void MoveEnd(MoveHelper moveHelper, Vector2 dir, float duration)
    {
        if (moveHelper.RigidBody)
        {
            moveHelper.RigidBody.linearVelocity = Vector3.zero;
        }
    }
}
