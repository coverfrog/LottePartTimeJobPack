using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

#region SpawnerType

public enum SpawnerType
{
    Product
}

#endregion

public class SpawnerManager : MonoBehaviour
{
    [Title("Data")]
    [SerializeField, ListDrawerSettings(ShowIndexLabels = true)] 
    private List<SpawnerData> mSpawnerData;

    #region SpawnerDict

    private Dictionary<SpawnerType, Spawner> _mSpawnerDict;

    private Dictionary<SpawnerType, Spawner> SpawnerDict
    {
        get
        {
            if (_mSpawnerDict != null) 
                return _mSpawnerDict;

            _mSpawnerDict = new Dictionary<SpawnerType, Spawner>();

            int c = 0;
            int len = mSpawnerData.Count;
            
            foreach (SpawnerData spawnerData in mSpawnerData)
            {
                Spawner spawner = new Spawner(spawnerData, () =>
                {
                    ++c;
                    if (c < len) return;
#if UNITY_EDITOR
                    Debug.Log("Load Spawner Prefab End");
#endif
                });
                
                if (_mSpawnerDict.TryAdd(spawnerData.GetSpawnerType, spawner))
                {
                  
                }
            }
            
            return _mSpawnerDict;
        }
    }
    
    #endregion

    private void Start()
    {
        _ = SpawnerDict;
    }

    [Button]
    private void Load()
    {
        SpawnerDict[SpawnerType.Product].Pool.Get();
    }
}
