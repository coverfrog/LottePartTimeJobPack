using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class InputHandler : GlobalHandler
{
    [Title("References")]
    [SerializeField] private PlayerInput mPlayerInput;
    
    private GlobalManager _mGlobalManager;
 
    public override void Setup(GlobalManager globalManager)
    {
        _mGlobalManager = globalManager;
    }

    private void Update()
    {
        Update_Move();
    }
}
