using UnityEngine;

public partial class InputHandler
{

    
    public class InputGrab
    {
        private readonly GrabDelegate _mOnGrabBegin;
        private readonly GrabDelegate _mOnGrabbing;
        private readonly GrabDelegate _mOnGrabEnd;
        
        private bool _mIsGrab;

        private float _mDuration;
        
        public InputGrab(
            GrabDelegate onGrabBegin,
            GrabDelegate onGrabbing,
            GrabDelegate onGrabEnd)
        {
            _mOnGrabBegin = onGrabBegin;
            _mOnGrabbing = onGrabbing;
            _mOnGrabEnd = onGrabEnd;
        }

        public void OnUpdate(InputHandler handler)
        {
            if (!_mIsGrab) return;

            _mDuration += Time.deltaTime;
            _mOnGrabbing?.Invoke(true, _mDuration);
        }

        public void OnInput(InputHandler handler, bool isPress)
        {
            _mDuration = 0.0f;

            if (isPress)
            {
                if (_mIsGrab)
                {
                    return;
                }

                _mIsGrab = true;
                _mOnGrabBegin?.Invoke(true, _mDuration);
            }

            else
            {
                _mIsGrab = false;
                _mOnGrabEnd?.Invoke(false, _mDuration);
            }
        }
    }
}
