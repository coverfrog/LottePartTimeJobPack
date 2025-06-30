using System;
using System.Collections.Generic;
using System.IO;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Pool;
using UnityEngine.ResourceManagement.AsyncOperations;
using Object = UnityEngine.Object;

#region SpawnPoolType

public enum SpawnPoolType
{
    Stack,
    LinkedList
}

#endregion

[Serializable]
public class Spawner
{
    [Title("Prefab")]
    [SerializeField] private SpawnBehaviour mPrefab;

    [Title("Type")] 
    [SerializeField] private SpawnerData mSpawnerData;

    #region Init

    public Spawner(SpawnerData spawnerData, Action onLoadEnd)
    {
        // Paste
        mSpawnerData = spawnerData;

        // Load Prefab
        mSpawnerData.GetAssetReference.LoadAssetAsync<GameObject>().Completed += handle =>
        {
            if (handle.Status != AsyncOperationStatus.Succeeded)
            {
                Debug.Assert(false, "Prefab Load Fail");
                return;
            }

            mPrefab = handle.Result.GetComponent<SpawnBehaviour>();
            
            onLoadEnd?.Invoke();
        };
    }

    #endregion
    
    #region Pool

    private IObjectPool<SpawnBehaviour> _mPool;

    public IObjectPool<SpawnBehaviour> Pool
    {
        get
        {
            if (_mPool != null) 
                return _mPool;

            SpawnPoolType spawnPoolType = mSpawnerData.GetSpawnPoolType;
            bool isCollectionCheck = mSpawnerData.GetIsCollectionCheck;
            int defaultCapacity = mSpawnerData.GetDefaultCapacity;
            int maxSize = mSpawnerData.GetMaxSize;
            
            _mPool = spawnPoolType switch
            {
                SpawnPoolType.Stack => new ObjectPool<SpawnBehaviour>(CreateItem, OnGet, OnRelease, OnDelete, isCollectionCheck, defaultCapacity, maxSize),
                SpawnPoolType.LinkedList => new LinkedPool<SpawnBehaviour>(CreateItem, OnGet, OnRelease, OnDelete, isCollectionCheck, maxSize),
                _ => null
            };

            return _mPool;
        }
    }

    private SpawnBehaviour CreateItem()
    {
        return Object.Instantiate(mPrefab);
    }

    private static void OnGet(SpawnBehaviour spawnBehaviour)
    {
        spawnBehaviour.gameObject.SetActive(true);
    }

    private static void OnRelease(SpawnBehaviour spawnBehaviour)
    {
        spawnBehaviour.gameObject.SetActive(false);
    }

    private static void OnDelete(SpawnBehaviour spawnBehaviour)
    {
        Object.Destroy(spawnBehaviour.gameObject);
    }

    #endregion
}
