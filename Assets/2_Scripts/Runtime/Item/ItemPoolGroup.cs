using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public class ItemPoolGroup
{
    [Title("Pool")]
    //[ShowInInspector, ReadOnly]
    private List<ItemPool> _mPoolList = new List<ItemPool>();
    [ShowInInspector, ReadOnly] 
    private Dictionary<string, ItemPool> _mPoolDict = new Dictionary<string, ItemPool>();

    #region Init

    public void Init(List<ItemData> itemDataList, Action onComplete)
    {
        int current = 0;
        int target = itemDataList.Count;
        
        _mPoolList = new List<ItemPool>(target);
        
        foreach (ItemData itemData in itemDataList)
        {
            ItemPool itemPool = new ItemPool(itemData, () =>
            {
                current += 1;

                if (current < target)
                {
                    return;
                }
                       
                if (!CheckCollection())
                    return;

                if (!InitPoolDict())
                    return;
                
                onComplete?.Invoke();
            });
            
            _mPoolList.Add(itemPool);
        }
    }
    
    #endregion

    #region CheckCollection

    private bool CheckCollection()
    {
        // 직렬화 된 경우 Null 이 된채로 있을 가능성 존재
        
        if (_mPoolList.Any(p => p == null))
        {
#if UNITY_EDITOR
            Debug.LogError("Pool 안에 Null 존재");
#endif
            return false;
        }
        
        // 동일한 codeName 을 가지고 있는 상태라면 
        // 그룹의 개수는 1개를 초과할 것이다.
        
        bool isOverlap = _mPoolList
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
    
    #endregion

    #region InitPoolDict

    private bool InitPoolDict()
    {
        // 딕셔너리 초기화
        _mPoolDict = new Dictionary<string, ItemPool>();
        
        // List 안에 데이터 기반으로 딕셔너리 생성
        foreach (ItemPool itemPool in _mPoolList)
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
    
    #endregion

    #region Spawn

    public void Spawn(string codeName, out Item item)
    {
        if (!_mPoolDict.ContainsKey(codeName))
        {
            CLog.Log("Pool 에서 아이템 획득 실패");
            item = null;
            return;
        }

        _mPoolDict[codeName].Pool.Get(out item);
    }

    #endregion

}
