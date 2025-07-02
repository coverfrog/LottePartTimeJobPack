using UnityEngine;

public class CamHandler : GlobalHandler
{
    private GlobalManager _mGlobalManager;
    
    public override void Setup(GlobalManager globalManager)
    {
        _mGlobalManager = globalManager;
    }
}
