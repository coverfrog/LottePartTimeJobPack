using System;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public class OrderDataReporter
{
    [Title("Debug")]
    [SerializeField, Tooltip(OrderDataToolTip)] private OrderData mOrderData;

    private const string OrderDataToolTip = "Debug 하기 편하게 하기 위해 Inspector 에서도 보이게 설정";
    
    public void OnPresent(OrderData orderData)
    {
        mOrderData = orderData;
    }
    
    public void Report(uint inputIdx)
    {
        bool isMatchLane = inputIdx == mOrderData.LaneIdx;
        
        Debug.Log($"isMatchLane : {isMatchLane}");
    }
}
