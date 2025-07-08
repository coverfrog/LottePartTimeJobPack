using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Sirenix.OdinInspector;
using UnityEngine;

/// <summary>
/// 원래는 Sql로 연동하고 싶었는데 생각해보니 포트폴리오에서 동작해야 해서 부적절
/// 따라서 ScriptableObject 로 Local 활용하는 방안으로 진행
/// </summary>
[Serializable]
public class ItemDataDb
{
    [Title("Option")] 
    [SerializeField] private List<ItemData> mItemDataList = new List<ItemData>();

    public void Init(Action<List<ItemData>> onLoadComplete)
    {
        // todo : 나중에는 db 연결 하자
        onLoadComplete?.Invoke(mItemDataList);
    }
}
