using System;
using UnityEngine;

[Serializable]
public class PoolOption<T0> where T0 : class
{
    [SerializeField] protected PoolType mPoolType;
    [SerializeField] protected bool mIsCollectionCheck;
    [SerializeField] protected uint mDefaultCapacity = 10;
    [SerializeField] protected uint mMaxSize = 10000;

    public PoolType PoolType => mPoolType;
    public bool IsCollectionCheck => mIsCollectionCheck;
    public int DefaultCapacity => (int)mDefaultCapacity;
    public int MaxSize => (int)mMaxSize;
}
