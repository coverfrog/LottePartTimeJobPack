using UnityEngine;

[CreateAssetMenu(fileName = "Cam Follow With Rotate", menuName = "Cf/Cam/Follow With Rotate")]
public class CamFollowWithRotate : CamBase
{
    public override void OnLateUpdate(Cam cam)
    {
        CamOption camOption = cam.Option;

        float yAngle = cam.Target.eulerAngles.y - 90f;
        yAngle *= Mathf.Deg2Rad;
        
        float xOffset = Mathf.Cos(yAngle) * camOption.FollowDistance * -1;
        float zOffset = Mathf.Sin(yAngle) * camOption.FollowDistance;

        Vector3 next = cam.Target.position + new Vector3(
            xOffset,
            camOption.FollowHeight,
            zOffset);
        
        Vector3 position = Vector3.Lerp(
            cam.transform.position, 
            next, 
            Time.deltaTime * cam.Option.FollowSmooth);

        cam.transform.position = position;
        cam.transform.LookAt(cam.Target);
    }
}
