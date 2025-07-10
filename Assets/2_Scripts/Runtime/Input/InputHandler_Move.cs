using System;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class InputHandler 
{
    public class InputMove
    {
        private readonly MoveDelegate _mOnMoveBegin;
        private readonly MoveDelegate _mOnMoving;
        private readonly MoveDelegate _mOnMoveEnd;

        private bool _mIsMove;

        private Vector2 _mCurrentDir;
        private float _mDuration;
        
        public InputMove(
            MoveDelegate onMoveBegin,
            MoveDelegate onMoving,
            MoveDelegate onMoveEnd)
        {
            _mOnMoveBegin = onMoveBegin;
            _mOnMoving = onMoving;
            _mOnMoveEnd = onMoveEnd;
        }
        
        public void OnUpdate(InputHandler handler)
        {
            if (!_mIsMove)
            {
                return;
            }

            _mDuration += Time.deltaTime;
            _mOnMoving?.Invoke(_mCurrentDir, _mDuration);
        }
        
        public void OnInput(InputHandler handler, Vector2 dir)
        {
            _mCurrentDir = dir;
            _mDuration = 0.0f;
            
            if (dir.sqrMagnitude > 0)
            {
                if (_mIsMove)
                {
                    return;
                }

                _mIsMove = true;
                _mOnMoveBegin?.Invoke(dir, _mDuration);
            }

            else
            {
                _mIsMove = false;
                _mOnMoveEnd?.Invoke(Vector2.zero, _mDuration);
            }
        }
    }
}
