using Sirenix.OdinInspector;
using UnityEngine;

public class DataHandler : GlobalHandler
{

    
    private GlobalManager _mGlobalManager;

    [ShowInInspector, ReadOnly]
    public PackGameData PackGame { get; private set; }


    public override void Setup(GlobalManager globalManager)
    {
        _mGlobalManager = globalManager;
        
        PackGame = new PackGameData();
    }
}
