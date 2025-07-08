using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Pool;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

[Serializable]
public class ItemPool : PoolBase<Item>
{
    public bool IsItemLoaded { get; private set; }
    
    public ItemPool(ItemData itemData)
    {
        // value
        mCodeName = itemData.CodeName;
        
        // load
        Load(itemData);
    }

    private void Load(ItemData itemData)
    {
        // path check
        if (ReferenceEquals(itemData.PrefabPath, null))
        {
#if UNITY_EDITOR
            Debug.LogError("prefab path is null");
#endif
            return;
        }
        
        // icon path
        if (ReferenceEquals(itemData.IconPath, null))
        {
#if UNITY_EDITOR
            Debug.LogError("icon path is null");
#endif
            return;
        }
        
        // load
        Addressables.LoadAssetAsync<GameObject>(itemData.PrefabPath).Completed += (handle) =>
        {
            // item
            if (!handle.Result.TryGetComponent(out Item item))
            {
#if UNITY_EDITOR
                Debug.LogError("don't have item component");
#endif
                return;
            }

            mPrefab = item;
        };
    }
    
    protected override Item OnCreate()
    {
        return null;
    }

    protected override void OnGet(Item obj)
    {
       
    }

    protected override void OnRelease(Item obj)
    {
        
    }

    protected override void OnDestroy(Item obj)
    {
        
    }
}
