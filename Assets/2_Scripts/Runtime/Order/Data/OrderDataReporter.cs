using System;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public class OrderDataReporter
{
    [ShowInInspector, ReadOnly] private OrderData _mOrderData;
    
    private Action<OrderData> _mOnCorrect;
    private Action<OrderData, string> _mOnWrong;

    public void Init(Action<OrderData> onCorrect, Action<OrderData, string> onWrong)
    {
        _mOnCorrect = onCorrect;
        _mOnWrong = onWrong;
    }
    
    public void OnPresent(OrderData orderData)
    {
        _mOrderData = orderData;
    }
    
    public void Report(string itemCodeName)
    {
        // todo : 상품 맞는지 여부
        bool isCorrect = itemCodeName == _mOrderData.ItemCodeName;
        if (isCorrect)
        {
            _mOnCorrect?.Invoke(_mOrderData);
        }

        else
        {
            _mOnWrong?.Invoke(_mOrderData, itemCodeName);
        }
    }
}
