using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Object = UnityEngine.Object;

public class ItemHandler : MonoBehaviour
{
    [Title("Actor")] 
    [SerializeField] private ItemDataDb mItemDataDb;
    [SerializeField] private ItemPoolGroup mItemPoolGroup;
    
    public void OnStart(Object sender)
    {
        mItemDataDb.Init(OnItemDataLoadComplete);
    }

    private void OnItemDataLoadComplete(List<ItemData> itemDataList)
    {
        mItemPoolGroup.Init(itemDataList);
    }

    public void OnPresent(OrderData orderData)
    {
        Debug.Log(orderData.ItemCodeName);
    }
}
