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

    public event Action<List<ItemData>> OnPoolLoadComplete;
    
    public void OnStart(Object sender)
    {
        mItemDataDb.Init(OnItemDataLoadComplete);
    }
    
    private void OnItemDataLoadComplete(List<ItemData> itemDataList)
    {
        CLog.Log("아이템 데이터 로딩 완료");
        
        mItemPoolGroup.Init(itemDataList, OnItemPoolLoadComplete);
    }

    private void OnItemPoolLoadComplete()
    {
        CLog.Log("아이템 Pool 로딩 완료");
        
        OnPoolLoadComplete?.Invoke(mItemDataDb.ItemDataList);
    }
    
    public void OnPresent(OrderData orderData)
    {
        mItemPoolGroup.Spawn(orderData.ItemCodeName, out Item item);
    }
}
