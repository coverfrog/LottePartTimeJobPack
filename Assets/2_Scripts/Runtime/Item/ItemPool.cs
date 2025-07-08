using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Object = UnityEngine.Object;

[Serializable]
public class ItemPool : PoolBase<Item>
{
    private const int LoadRequireCount = 1;

    private Action _mOnLoadComplete;

    private int _mLoadCount;
    
    public ItemPool(ItemData itemData, Action onLoadComplete) 
    {
        // action
        _mLoadCount = 0;
        _mOnLoadComplete = onLoadComplete;
        
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
                CLog.Log("아이템 컴포넌트가 존재하지 않습니다.");
                return;
            }

            mPrefab = item;

            OnLoadComplete();
        };
    }

    private void OnLoadComplete()
    {
        _mLoadCount += 1;

        if (_mLoadCount < LoadRequireCount)
        {
            return;
        }
        
        _mOnLoadComplete?.Invoke();
    }
    
    protected override Item OnCreate()
    {
        return Object.Instantiate(mPrefab);
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
