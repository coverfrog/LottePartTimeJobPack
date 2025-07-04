using System;
using UnityEngine;

[Serializable]
public class OrderData
{
    [SerializeField] private uint mCreatedIdx;
    [SerializeField] private uint mLaneIdx;
    [SerializeField] private uint mItemIdx;

    public uint LaneIdx => mLaneIdx;
    public uint ItemIdx => mItemIdx;
    
    public OrderData(uint createdIdx, uint laneIdx, uint itemIdx)
    {
        mCreatedIdx = createdIdx;
        mLaneIdx = laneIdx;
        mItemIdx = itemIdx;
    }
}
