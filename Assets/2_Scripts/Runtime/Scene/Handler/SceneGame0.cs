using System;
using Sirenix.OdinInspector;
using UnityEngine;

public class SceneGame0 : SceneGame
{
    [Title("References")]
    [SerializeField] private OrderHandler mOrderHandler;
    [SerializeField] private ItemHandler mItemHandler;
    
    #region Start

    protected override void Start()
    {
        // base
        base.Start();
        
        // 이벤트 연결
        mOrderHandler.OnPresentAction += mItemHandler.OnPresent;
        
        // 하위 컴포넌트 호출
        mOrderHandler.OnStart(this);
        mItemHandler.OnStart(this);
    }

    #endregion

    #region OnDestroy

    private void OnDestroy()
    {
        // 이벤트 해제
        mOrderHandler.OnPresentAction -= mItemHandler.OnPresent;
    }

    #endregion
}