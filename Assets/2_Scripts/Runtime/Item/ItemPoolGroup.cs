using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public class ItemPoolGroup
{
    [Title("Pool")]
    [SerializeField] private List<ItemPool> mPoolList = new List<ItemPool>();

    private Dictionary<string, ItemPool> _mPoolDict = new Dictionary<string, ItemPool>();
    private bool _mInit;
    
    public Dictionary<string, ItemPool> PoolDict
    {
        get
        {
            if (!_mInit)
            {
                Init();
            }

            return _mPoolDict;
        }
    }
    
    public void Init()
    {
        _mInit = false;
        
        if (!CheckCollection())
            return;

        if (!InitPoolDict())
            return;

        _mInit = true;
    }

    public void Init(List<ItemData> itemDataList)
    {
        _mInit = false;

        mPoolList = new List<ItemPool>();
        foreach (ItemData itemData in itemDataList)
        {
            ItemPool itemPool = new ItemPool(itemData);
            
            mPoolList.Add(itemPool);
        }
        
        Init();
    }

    private bool CheckCollection()
    {
        // 직렬화 된 경우 Null 이 된채로 있을 가능성 존재
        
        if (mPoolList.Any(p => p == null))
        {
#if UNITY_EDITOR
            Debug.LogError("Pool 안에 Null 존재");
#endif
            return false;
        }
        
        // 동일한 codeName 을 가지고 있는 상태라면 
        // 그룹의 개수는 1개를 초과할 것이다.
        
        bool isOverlap = mPoolList
            .GroupBy(p => p.CodeName)
            .Any(g => g.Count() > 1);

#if UNITY_EDITOR
        if (isOverlap)
        {
            Debug.LogError("Pool CodeName 중복");
        }
#endif
        
        return true;
    }

    private bool InitPoolDict()
    {
        // 딕셔너리 초기화
        _mPoolDict = new Dictionary<string, ItemPool>();
        
        // List 안에 데이터 기반으로 딕셔너리 생성
        foreach (ItemPool itemPool in mPoolList)
        {
            if (_mPoolDict.TryAdd(itemPool.CodeName, itemPool))
            {
                continue;
            }

#if UNITY_EDITOR
            Debug.LogError("Pool 중복 발생");
#endif
            
            return false;
        }

        return true;
    }
}
