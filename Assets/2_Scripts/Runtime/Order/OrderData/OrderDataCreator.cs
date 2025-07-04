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
    
    public List<OrderData> Create()
    {
        List<OrderData> result = new List<OrderData>((int)mCreateCount);

        for (uint createdIdx = 0; createdIdx < mLaneCount; ++createdIdx)
        {
            uint laneIdx = (uint)Random.Range(0, mLaneCount);
            
            OrderData orderData = new OrderData(createdIdx, laneIdx);

            result.Add(orderData);
        }

        return result;
    }
}
