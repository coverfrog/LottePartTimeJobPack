using Sirenix.OdinInspector;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [Title("References")]
    [SerializeField] private MoveHelper mMoveHelper;

    public MoveHelper Move => mMoveHelper;
    
    public void OnStart(Object sender)
    {
        mMoveHelper?.OnStart(sender);
    }
}
