using System;
using UnityEngine;

[Serializable]
public class OrderData
{
    [SerializeField] private uint mCreatedIdx;
    [SerializeField] private uint mItemIdx;

    public uint ItemIdx => mItemIdx;
    
    public OrderData(uint createdIdx, uint itemIdx)
    {
        mCreatedIdx = createdIdx;
        mItemIdx = itemIdx;
    }
}
