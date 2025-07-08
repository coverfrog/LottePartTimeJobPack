using System;
using System.Collections.Generic;
using System.Linq;
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
    
    public List<OrderData> Create(List<ItemData> itemDataList)
    {
        // todo : 전체 중에서 Order 아이템만 분리
        List<ItemData> target = itemDataList.Where(d => d.IsOrderItem).ToList();
        List<OrderData> result = new List<OrderData>((int)mCreateCount);

        for (uint createdIdx = 0; createdIdx < mLaneCount; ++createdIdx)
        {
            int idx = Random.Range(0, target.Count);

            ItemData itemData = target[idx];
            
            OrderData orderData = new OrderData(createdIdx, itemData.CodeName);

            result.Add(orderData);
        }

        _mOnCreate?.Invoke(result);
        
        return result;
    }
}
