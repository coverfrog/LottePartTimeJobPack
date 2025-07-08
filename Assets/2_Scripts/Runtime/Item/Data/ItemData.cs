using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(menuName = "Cf/Item/Data", fileName = "Item Data")]
public class ItemData : ScriptableObject
{
    [Title("Text")]
    [SerializeField] private string mCodeName;
    
    public string CodeName => mCodeName;

    [Title("Path")] 
    [SerializeField, FilePath] private AssetReference mPrefabPath;
    [SerializeField, FilePath] private AssetReference mIconPath;

    public AssetReference PrefabPath => mPrefabPath;
    public AssetReference IconPath => mIconPath;
}
