using UnityEngine;

public class UIHandler : GlobalHandler
{
    private GlobalManager _mGlobalManager;

    public override void Setup(GlobalManager globalManager)
    {
        _mGlobalManager = globalManager;
    }
}
