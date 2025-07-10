using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;
using Object = UnityEngine.Object;

[RequireComponent(typeof(PlayerInput))]
public partial class InputHandler : MonoBehaviour
{
    [Title("References")]
    [SerializeField] private PlayerInput mPlayerInput;

    private InputMove _mInputMove;
    private InputGrab _mInputGrab;

    public delegate void MoveDelegate(Vector2 dir, float duration);
    public delegate void GrabDelegate(bool isPress, float duration);

    public event MoveDelegate OnMoveBegin, OnMoving, OnMoveEnd;
    public event GrabDelegate OnGrabBegin, OnGrabbing, OnGrabEnd;
    
    public void OnStart(Object sender)
    {
        _mInputMove = new InputMove(OnMoveBegin, OnMoving, OnMoveEnd);
        _mInputGrab = new InputGrab(OnGrabBegin, OnGrabbing, OnGrabEnd);
    }

    private void Update()
    {
        _mInputMove?.OnUpdate(this);
        _mInputGrab?.OnUpdate(this);
    }

    public void OnMove(InputValue inputValue)
    {
        _mInputMove?.OnInput(this,inputValue.Get<Vector2>());
    }

    public void OnGrab(InputValue inputValue)
    {
        _mInputGrab?.OnInput(this, inputValue.Get<float>() > 0.5f);
    }
}
