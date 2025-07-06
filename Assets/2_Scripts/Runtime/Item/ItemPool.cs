using System;
using UnityEngine;
using UnityEngine.Pool;

[Serializable]
public class ItemPool : PoolBase<Item>
{
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
