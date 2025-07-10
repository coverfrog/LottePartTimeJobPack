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

    [Title("References")]
    [SerializeField] private Transform mSpawnParent;

    // todo : 나중에 스폰 될 위치는 세부 조정 할 듯하여 우선 단일 소환
    
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
        // 아이템 획득
        mItemPoolGroup.Spawn(orderData.ItemCodeName, out Item item);
        
        item.transform.SetParent(mSpawnParent);
        item.transform.localPosition = Vector3.zero;
    }
}
