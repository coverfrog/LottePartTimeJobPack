using System;
using Sirenix.OdinInspector;
using UnityEngine;

public class SceneGame0 : SceneGame
{
    [Title("References")]
    [SerializeField] private OrderHandler mOrderHandler;
    [SerializeField] private ItemHandler mItemHandler;
    [SerializeField] private InputHandler mInputHandler;

    [Title("References")] 
    [SerializeField] private PlayerCtrl mPlayerCtrl;

    [Title("References")] 
    [SerializeField] private UIGame0 mUIGame0;
    
    #region Start

    protected override void Start()
    {
        // base
        base.Start();
        
        /*
            이벤트 연결 시작
         */
        
        // 문제가 출제되는 시점 -> 아이템 핸들러에 전달 ( 스폰 )
        mOrderHandler.OnPresentAction += mItemHandler.OnPresent;

        // 아이템 Pool 생성 완료 시점
        mItemHandler.OnPoolLoadComplete += (itemDataList) =>
        {
            mOrderHandler.Create(itemDataList);
        };

        // Input 시스템 Move 연결
        mPlayerCtrl?.SubInputEvent(mInputHandler);
        
        // 하위 컴포넌트 호출
        mOrderHandler.OnStart(this);
        mItemHandler.OnStart(this);
        mInputHandler.OnStart(this);
        mUIGame0.OnStart(this);
    }

    #endregion

    #region OnDestroy

    private void OnDestroy()
    {
        /*
             이벤트 연결 해제 시작
        */
        
        mOrderHandler.OnPresentAction -= mItemHandler.OnPresent;
        
        // Input 시스템 Move 연결 해제
        mPlayerCtrl?.UnSubInputEvent(mInputHandler);
        
    }

    #endregion
}