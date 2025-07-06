using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class OrderDataCreator
{
    [Title("Option")]
    [SerializeField] private uint mCreateCount = 4;
    [SerializeField] private uint mLaneCount = 4;

    private Action<List<OrderData>> _mOnCreate;
    
    public void Init(Action<List<OrderData>> onCreate)
    {
        _mOnCreate = onCreate;
    }
    
    public List<OrderData> Create()
    {
        List<OrderData> result = new List<OrderData>((int)mCreateCount);

        for (uint createdIdx = 0; createdIdx < mLaneCount; ++createdIdx)
        {
            // todo : 이 부분은 아이템 부분 완성되면 바꿀 것 
            uint itemIdx = (uint)Random.Range(0, 5);
            
            OrderData orderData = new OrderData(createdIdx, itemIdx);

            result.Add(orderData);
        }

        _mOnCreate?.Invoke(result);
        
        return result;
    }
}
