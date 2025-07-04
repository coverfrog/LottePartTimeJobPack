using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Object = UnityEngine.Object;

public class OrderHandler : MonoBehaviour
{
    [Title("Option")] 
    [SerializeField] private bool mIsDebugInput = true;
    
    [Title("Actor")]
    [SerializeField] private OrderDataCreator mCreator = new OrderDataCreator();
    [SerializeField] private OrderDataPresenter mPresenter = new OrderDataPresenter();
    [SerializeField] private OrderDataReporter mReporter = new OrderDataReporter();

    public event Action<OrderData> OnPresentAction; 
    
    #region On Game Start

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    public void OnGameStart(Object sender)
    {
        // 문제 생성
        List<OrderData> orderDataList = mCreator.Create();
        
        // 인덱스 초기화, 문제 제시
        mPresenter.Init(orderDataList, OnPresent);
        mPresenter.Present();
    }

    #endregion

    #region OnPresent

    /// <summary>
    /// 문제가 제출되는 시점
    /// </summary>
    /// <param name="orderData"></param>
    private void OnPresent(OrderData orderData)
    {
        // 제출자에게 정보 전달
        mReporter.OnPresent(orderData);
        
        // 이벤트 실행
        OnPresentAction?.Invoke(orderData);
    }

    #endregion
    
    #region Update

    private void Update()
    {
#if UNITY_EDITOR
        Update_DebugInput();
#endif
    }

    private void Update_DebugInput()
    {
        if (!mIsDebugInput)
        {
            return;
        }
        
        // 디버그 입력 ( 1 ~ 9 )
        for (int idx = (int)KeyCode.Alpha1; idx <= (int)KeyCode.Alpha9; ++idx)
        {
            if (!Input.GetKeyDown((KeyCode)idx))
            {
                continue;
            }

            int relativeIdx = idx - (int)KeyCode.Alpha1;
            
            mReporter.Report((uint)relativeIdx);
        }
    }
    
    #endregion
}
