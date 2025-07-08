using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;
using Object = UnityEngine.Object;

[RequireComponent(typeof(InputHandler))]
public partial class InputHandler : MonoBehaviour
{
    [Title("References")]
    [SerializeField] private PlayerInput mPlayerInput;

    private InputMove _mInputMove;

    public delegate void MoveDelegate(Vector2 dir);

    public event MoveDelegate OnMoveBegin, OnMoving, OnMoveEnd;
    
    public void OnStart(Object sender)
    {
        _mInputMove = new InputMove(OnMoveBegin, OnMoving, OnMoveEnd);
    }

    private void Update()
    {
        _mInputMove?.OnUpdate(this);
    }

    public void OnMove(InputValue inputValue)
    {
        _mInputMove?.OnInput(this,inputValue.Get<Vector2>());
    }
}
