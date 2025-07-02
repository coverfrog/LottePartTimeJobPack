using UnityEngine;

[CreateAssetMenu(fileName = "Cam Follow With Out Rotate", menuName = "Cf/Cam/Follow With Out Rotate")]
public class CamFollowWithOutRotate : CamBase
{
    public override void OnLateUpdate(Cam cam)
    {
        CamOption camOption = cam.Option;

        cam.transform.position = cam.Target.position +
                                 Vector3.back * camOption.FollowDistance +
                                 Vector3.up * camOption.FollowHeight;
    }
}
