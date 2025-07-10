using UnityEngine;

[CreateAssetMenu(fileName = "Direct Change Position", menuName = "Cf/Move/Direct Change Position")]
public class MoveDirectChangePosition : MoveActor
{
    public override void MoveBegin(MoveHelper moveHelper, Vector2 dir, float duration)
    {
        Move(moveHelper, dir, duration);
    }

    public override void Moving(MoveHelper moveHelper, Vector2 dir, float duration)
    {
        Move(moveHelper, dir, duration);
    }

    public override void MoveEnd(MoveHelper moveHelper, Vector2 dir, float duration)
    {
        
    }
    
    //
    
    private static void Move(MoveHelper moveHelper, Vector2 dir, float duration)
    {
        if (!moveHelper.RigidBody)
            return;
        
        moveHelper.RigidBody.MovePosition(
            moveHelper.RigidBody.position + 
            new Vector3(dir.x ,0, dir.y) * (Time.deltaTime * moveHelper.MoveSpeedCurrent));
    }
}
