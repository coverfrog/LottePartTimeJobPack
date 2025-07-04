using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public class OrderDataPresenter
{
    [Title("Option")]
    [SerializeField] private uint mInitIndex;

    private uint _mIndex;
    
    private List<OrderData> _mOrderDataList;
    private Action<OrderData> _mOnPresent;
    
    public void Init(List<OrderData> orderDataList, Action<OrderData> onPresent)
    {
        _mIndex = mInitIndex;
        
        _mOrderDataList = orderDataList;
        _mOnPresent = onPresent;
    }
    
    public bool Present()
    {
        if (_mIndex >= _mOrderDataList.Count)
        {
#if UNITY_EDITOR
            Debug.LogError("Index Range Over");
#endif
            return false;
        }
        
        OrderData orderData = _mOrderDataList[(int)_mIndex];
        
        _mOnPresent?.Invoke(orderData);

        return true;
    }
}
