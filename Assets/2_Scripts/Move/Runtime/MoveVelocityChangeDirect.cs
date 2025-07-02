using UnityEngine;

[CreateAssetMenu(fileName = "Move Velocity Change Direct", menuName = "Cf/Move/Velocity Change/Direct")]
public class MoveVelocityChangeDirect : MoveBase
{
    public override void MoveBegin(Move move)
    {
        
    }

    public override void Moving(Move move)
    {
        Rigidbody rigidBody = move.RigidBody;
        
        Vector3 dir = new Vector3(move.Data.dir.x, 0, move.Data.dir.y).normalized;
        if (move.Option.IsLocal)
        {
            dir = rigidBody.transform.TransformDirection(dir);
        }
        
        rigidBody.linearVelocity = dir * move.Data.moveSpeed;;
        rigidBody.rotation = Quaternion.Slerp(rigidBody.rotation, Quaternion.LookRotation(dir), move.Data.rotSpeed * Time.deltaTime);
    }

    public override void MoveEnd(Move move)
    {
        Rigidbody rigidBody = move.RigidBody;

        rigidBody.linearVelocity = Vector3.zero;
    }
}
