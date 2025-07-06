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
    [Title("Value")] 
    [SerializeField] protected string mCodeName;
    [SerializeField] protected T0 mPrefab;

    [Title("Option")] 
    [SerializeField] protected PoolOption<T0> mOption = new PoolOption<T0>();

    public string CodeName => mCodeName;

    public T0 Prefab => mPrefab;
    
    public PoolOption<T0> Option => mOption;
    
    public IObjectPool<T0> Pool { get; private set; }
    
    public virtual void Init()
    {
        var collectionCheck = mOption.IsCollectionCheck;
        var defaultCapacity = mOption.DefaultCapacity;
        var maxSize = mOption.MaxSize;

        Pool = mOption.PoolType == PoolType.ObjectPool
            ? new ObjectPool<T0>(OnCreate, OnGet, OnRelease, OnDestroy, collectionCheck, defaultCapacity, maxSize)
            : new LinkedPool<T0>(OnCreate, OnGet, OnRelease, OnDestroy, collectionCheck, maxSize);
    }

    protected abstract T0 OnCreate();

    protected abstract void OnGet(T0 obj);
    
    protected abstract void OnRelease(T0 obj);

    protected abstract void OnDestroy(T0 obj);

}
