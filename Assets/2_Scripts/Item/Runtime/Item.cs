using System;
using UnityEngine;

[Serializable]
public class Item 
{
    [SerializeField] private ItemData mItemData;
    [SerializeField] private uint mCount = 1;

    public ItemData Data => mItemData;
    public uint Count => mCount;

    public uint AddCount(uint add) => mCount += add;
}
