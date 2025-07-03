using UnityEngine;

[CreateAssetMenu(fileName = "Interact Item Add", menuName = "Cf/Interact/Item Add")]
public class InteractItemAdd : InteractBase
{
    public override void InteractTab(Interact interact, InteractDetect detect)
    {
        GlobalManager.Instance.Data.PackGame.ItemAdd(interact);
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
