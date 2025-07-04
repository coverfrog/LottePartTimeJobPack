using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Object = UnityEngine.Object;

public class OrderHandler : MonoBehaviour
{
    [Title("Actor")]
    [SerializeField] private OrderDataCreator mCreator = new OrderDataCreator();
    [SerializeField] private OrderDataPresenter mPresenter = new OrderDataPresenter();
    [SerializeField] private OrderDataReporter mReporter = new OrderDataReporter();

    
    public event Action OnCreateAction;
    public event Action<OrderData> OnPresentAction;
    public event Action<OrderData> OnReportCorrectAction;
    public event Action<OrderData, uint> OnReportWrongAction; 
    
    
    #region OnGameStart

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    public void OnGameStart(Object sender)
    {
        // 생성자 초기화, 생성
        mCreator.Init(OnCreate);
        mCreator.Create();
    }

    #endregion

    #region OnCreate

    private void OnCreate(List<OrderData> orderDataList)
    {
        // 제시자 초기화, 제시
        mPresenter.Init(orderDataList, OnPresent);
        mPresenter.Present();
        
        // 답변자 초기화
        mReporter.Init(OnReportCorrect, OnReportWrong);
        
        // 액션
        OnCreateAction?.Invoke();
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

    #region OnReportCorrect

    private void OnReportCorrect(OrderData orderData)
    {
#if UNITY_EDITOR && true
        Debug.Log("정답");        
#endif
        
        OnReportCorrectAction?.Invoke(orderData);
    }

    #endregion

    #region OnReportWrong

    private void OnReportWrong(OrderData orderData, uint itemIdx)
    {
#if UNITY_EDITOR && true
        Debug.Log("오답");        
#endif
        
        OnReportWrongAction?.Invoke(orderData, itemIdx);
    }

    #endregion
}
