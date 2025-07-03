using UnityEngine;

[CreateAssetMenu(fileName = "Interact Give", menuName = "Cf/Interact/Give")]
public class InteractGive : InteractBase
{
    public override void InteractTab(Interact interact, InteractDetect detect)
    {
        Debug.Log("전달");
    }

    public override void InteractHoldBegin(Interact interact, InteractDetect detect)
    {
        
    }

    public override void InteractHolding(Interact interact, InteractDetect detect)
    {
        
    }

    public override void InteractHoldEnd(Interact interact, InteractDetect detect)
    {
        
    }
}
