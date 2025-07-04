using System;
using UnityEngine;

[Serializable]
public class OrderData
{
    [SerializeField] private uint mCreatedIdx;
    [SerializeField] private uint mLaneIdx;

    public uint LaneIdx => mLaneIdx;
    
    public OrderData(uint createdIdx, uint laneIdx)
    {
        mCreatedIdx = createdIdx;
        mLaneIdx = laneIdx;
    }
}
