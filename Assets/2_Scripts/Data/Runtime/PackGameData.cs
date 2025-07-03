using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public class PackGameData
{
    [ShowInInspector, ReadOnly]
    private Dictionary<string, Item> _mItemDict = new();

    public void ItemAdd(Interact interact)
    {
        foreach (Item item in interact.Data.ItemAddList)
        {
            if (_mItemDict.TryAdd(item.Data.CodeName, item))
            {
                Debug.Log("1");
                continue;
            }

            Debug.Log("2");
            
            _mItemDict[item.Data.CodeName].AddCount(item.Count);
        }
    }
}
