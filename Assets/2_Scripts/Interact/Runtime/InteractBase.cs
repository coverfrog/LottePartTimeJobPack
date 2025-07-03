using UnityEngine;

public abstract class InteractBase : ScriptableObject
{
    // 탭 용도
    public abstract void InteractTab(Interact interact, InteractDetect detect);
    
    // 홀딩 용도 ( 홀드는 나중에 구현 , 우선 탭 먼저 )
    public abstract void InteractHoldBegin(Interact interact, InteractDetect detect);
    
    public abstract void InteractHolding(Interact interact, InteractDetect detect);
    
    public abstract void InteractHoldEnd(Interact interact, InteractDetect detect);
}
