using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Pool;

public enum PoolType
{
    ObjectPool,
    LinkedPool
}

[Serializable]
public abstract class PoolBase<T0> where T0 : class
{
    [Title("Option")]
    [SerializeField] protected PoolType mPoolType;
    [SerializeField] protected bool mIsCollectionCheck;
    [SerializeField] protected uint mDefaultCapacity = 10;
    [SerializeField] protected uint mMaxSize = 10000;
    
    public IObjectPool<T0> Pool { get; private set; }

    public virtual void Init(params object[] args)
    {
        int defaultCapacity = (int)mDefaultCapacity;
        int maxSize = (int)mMaxSize;

        Pool = mPoolType == PoolType.ObjectPool
            ? new ObjectPool<T0>(OnCreate, OnGet, OnRelease, OnDestroy, mIsCollectionCheck, defaultCapacity, maxSize)
            : new LinkedPool<T0>(OnCreate, OnGet, OnRelease, OnDestroy, mIsCollectionCheck, maxSize);
    }

    protected abstract T0 OnCreate();

    protected abstract void OnGet(T0 obj);
    
    protected abstract void OnRelease(T0 obj);

    protected abstract void OnDestroy(T0 obj);

}
