using System;
using UnityEngine;

[Serializable]
public class OrderData
{
    [SerializeField] private uint mCreatedIdx;
    [SerializeField] private string mItemCodeName;

    public string ItemCodeName => mItemCodeName;
    
    public OrderData(uint createdIdx, string itemCodeName)
    {
        mCreatedIdx = createdIdx;
        mItemCodeName = itemCodeName;
    }
}
