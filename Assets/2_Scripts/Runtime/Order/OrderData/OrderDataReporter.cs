using System;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public class OrderDataReporter
{
    [ShowInInspector, ReadOnly] private OrderData _mOrderData;
    
    private Action<OrderData> _mOnCorrect;
    private Action<OrderData, uint> _mOnWrong;

    public void Init(Action<OrderData> onCorrect, Action<OrderData, uint> onWrong)
    {
        _mOnCorrect = onCorrect;
        _mOnWrong = onWrong;
    }
    
    public void OnPresent(OrderData orderData)
    {
        _mOrderData = orderData;
    }
    
    public void Report(uint laneIdx, uint productIdx)
    {
        // todo : 맞는 라인 일 때만 반영, 추후 변경 가능성 있음
        bool isMatchLane = laneIdx == _mOrderData.LaneIdx;
        if (!isMatchLane)
        {
            return;
        }

        // todo : 상품 맞는지 여부
        bool isCorrect = productIdx == _mOrderData.ItemIdx;
        if (isCorrect)
        {
            _mOnCorrect?.Invoke(_mOrderData);
        }

        else
        {
            _mOnWrong?.Invoke(_mOrderData, productIdx);
        }
    }
}
