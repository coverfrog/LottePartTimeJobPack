using UnityEngine;
using UnityEngine.InputSystem;

public partial class InputHandler
{
    // Delegate
    public delegate void InteractDetectDelegate(bool isInteract);
    
    // Action
    public event InteractDetectDelegate OnInteractDetectOn, OnInteractDetectOff;
    
    // Input ( Player Input )
    public void OnInteract(InputValue inputValue)
    {
        if (inputValue.Get<float>() > 0.5f)
        {
            OnInteractDetectOn?.Invoke(true);
        }

        else
        {
            OnInteractDetectOff?.Invoke(false);
        }
    }
}
