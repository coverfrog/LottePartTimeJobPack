using System;
using Sirenix.OdinInspector;
using UnityEngine;



public class Interact : MonoBehaviour
{
    [Title("Option")]
    [SerializeField] private InteractBase mInteractFunc;
    [SerializeField] private InteractOption mInteractOption;

    public InteractOption Option => mInteractOption;
    
    [Title("Data")]
    [SerializeField] private InteractData mInteractData;

    public void OnDetect(InteractDetect detect)
    {
        // 현재 상호작용 안되거나 , 홀딩 타입이 실행 중인 경우
        if (!mInteractData.IsCanInteract || mInteractData.IsInteracting) 
            return;

        // 상호작용 시작
        OnInteractBegin(detect);
    }

    #region OnInteractBegin

    private void OnInteractBegin(InteractDetect detect)
    {
        // 우선 어느 유형이든 연속 터치는 방지할 필요가 존재
        
        // 유형에 따라서 변경
        switch (mInteractOption.InteractType)
        {
            case InteractType.Tab:
                OnInteractBegin_Tab(detect);
                break;
            case InteractType.Hold:
                OnInteractBegin_Hold(detect);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    
    private void OnInteractBegin_Tab(InteractDetect detect)
    {
        // 탭의 경우 조건에 따라서 
        mInteractFunc?.InteractTab(this, detect);
    }

    private void OnInteractBegin_Hold(InteractDetect detect)
    {
        mInteractFunc?.InteractHoldBegin(this, detect);
    }

    #endregion


    private void OnInteracting()
    {
        
    }

    private void OnInteractEnd()
    {
        
    }
}
