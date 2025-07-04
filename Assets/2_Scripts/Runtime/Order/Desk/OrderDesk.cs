using System;
using UnityEngine;

public class OrderDesk : MonoBehaviour
{
    private OrderHandler _mOrderHandler;
    
    #region OnStart

    public void OnStart(OrderHandler orderHandler)
    {
        // value
        _mOrderHandler = orderHandler;
        
        // event
        orderHandler.OnPresentAction += OnPresent;
    }

    #endregion
    
    #region OnDestroy

    private void OnDestroy()
    {
        // event
        _mOrderHandler.OnPresentAction -= OnPresent;
    }

    #endregion

    #region OnPresent

    private void OnPresent(OrderData orderData)
    {
        Debug.Log("Present!");
    }

    #endregion


}
