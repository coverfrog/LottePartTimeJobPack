using System;
using Sirenix.OdinInspector;
using UnityEngine;
using Object = UnityEngine.Object;

public class ItemHandler : MonoBehaviour
{
    [Title("Actor")]
    [SerializeField] private ItemPool mItemPool;
    
    public void OnStart(Object sender)
    {
        // Pool 초기화
        mItemPool.Init();
    }

    public void OnPresent(OrderData orderData)
    {
        Debug.Log(orderData.ItemIdx);
    }
}
