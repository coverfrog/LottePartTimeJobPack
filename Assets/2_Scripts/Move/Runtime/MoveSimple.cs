using UnityEngine;

[CreateAssetMenu(fileName = "Move Simple", menuName = "Cf/Move/Simple")]
public class MoveSimple : MoveBase
{
    public override void MoveBegin(MoveData data)
    {
        Rigidbody rigidBody = data.rigidBody;
        Vector3 dir = new Vector3(data.dir.x, 0, data.dir.y).normalized;
        
        rigidBody.linearVelocity = dir * data.moveSpeed * Time.deltaTime;
        rigidBody.rotation = Quaternion.LookRotation(dir);
    }

    public override void Moving(MoveData data)
    {
        Rigidbody rigidBody = data.rigidBody;
        Vector3 dir = new Vector3(data.dir.x, 0, data.dir.y).normalized;
        
        rigidBody.linearVelocity = dir * data.moveSpeed;;
        rigidBody.rotation = Quaternion.Slerp(rigidBody.rotation, Quaternion.LookRotation(dir), data.rotSpeed * Time.deltaTime);
    }

    public override void MoveEnd(MoveData data)
    {
        Rigidbody rigidBody = data.rigidBody;

        rigidBody.linearVelocity = Vector3.zero;
    }
}
