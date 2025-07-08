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
        
        public InputMove(
            MoveDelegate onMoveBegin,
            MoveDelegate onMoving,
            MoveDelegate onMoveEnd)
        {
            _mOnMoveBegin = onMoveBegin;
            _mOnMoving = onMoving;
            _mOnMoveEnd = onMoveEnd;
        }
        
        public void OnInput(InputHandler handler, Vector2 dir)
        {
            _mCurrentDir = dir;
            
            if (dir.sqrMagnitude > 0)
            {
                if (_mIsMove)
                {
                    return;
                }

                _mIsMove = true;
                _mOnMoveBegin?.Invoke(dir);
            }

            else
            {
                _mIsMove = false;
                _mOnMoveEnd?.Invoke(Vector2.zero);
            }
        }

        public void OnUpdate(InputHandler handler)
        {
            if (!_mIsMove)
            {
                return;
            }
            
            _mOnMoving?.Invoke(_mCurrentDir);
        }
    }
}
