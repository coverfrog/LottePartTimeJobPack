using UnityEngine;

public class GrabObject : MonoBehaviour
{
    public float Distance { get; private set; }

    private Transform _mOriginParent;
    
    #region OnDetect

    public void OnDetect(float distance)
    {
        Distance = distance;
    }
    
    #endregion


    #region Grab

    public void Grab(GrabHelper grabHelper)
    {
        // 부모 있으면 저장
        if (transform.parent)
        {
            _mOriginParent = transform.parent;
        }
        
        // 그랩 포인트로 이동
        if (grabHelper.GrabbedParent)
        {
            transform.SetParent(grabHelper.GrabbedParent);
        }
    }

    #endregion

    #region Grabbing

    public void Grabbing(GrabHelper grabHelper)
    {
        
    }
    
    #endregion

    #region UnGrab

    public void UnGrab(GrabHelper grabHelper)
    {
        // 저장된 부모가 있으면 이동
        if (_mOriginParent)
        {
            transform.SetParent(_mOriginParent);
        }
    }

    #endregion
}
