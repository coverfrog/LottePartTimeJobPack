using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AddressableAssets;

[Serializable]
public class SpawnerData
{
    [Title("Text")] 
    [SerializeField] private SpawnerType mSpawnerType;
    [SerializeField] private AssetReference mAssetReference;

    public SpawnerType GetSpawnerType => mSpawnerType;
    public AssetReference GetAssetReference => mAssetReference;
    
    [Title("Pool")]
    [SerializeField] private SpawnPoolType mSpawnPoolType;
    [SerializeField] private bool mIsCollectionCheck = true;
    [SerializeField] private int mDefaultCapacity = 10;
    [SerializeField] private int mMaxSize = 10000;

    public SpawnPoolType GetSpawnPoolType => mSpawnPoolType;
    public bool GetIsCollectionCheck => mIsCollectionCheck;
    public int GetDefaultCapacity => mDefaultCapacity;
    public int GetMaxSize => mMaxSize;
}
