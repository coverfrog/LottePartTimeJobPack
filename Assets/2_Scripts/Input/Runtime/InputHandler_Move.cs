using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// InputHandler_Move
/// </summary>
public partial class InputHandler
{
    // Delegate
    public delegate void MoveDelegate(Vector2 dir); 
    
    // Action
    public event MoveDelegate OnMoveBegin, OnMoving, OnMoveEnd;
    
    // Flag
    private bool _mIsMove;
    
    // Value
    private Vector2 _mMoveDir;
    
    // Input ( Update )
    // ReSharper disable Unity.PerformanceAnalysis
    private void Update_Move()
    {
        if (!_mIsMove) return;
        
        OnMoving?.Invoke(_mMoveDir);
    }
    
    // Input ( Player Input )
    public void OnMove(InputValue inputValue)
    {
        _mMoveDir = inputValue.Get<Vector2>().normalized;

        if (_mMoveDir.sqrMagnitude > 0)
        {
            if (_mIsMove) return;

            _mIsMove = true;
                
            OnMoveBegin?.Invoke(_mMoveDir);
        }

        else
        {
            if (!_mIsMove) return;
                
            _mIsMove = false;
                    
            OnMoveEnd?.Invoke(Vector2.zero);
        }
    }
}
