using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Cf/Item/Data", fileName = "Item Data")]
public class ItemData : ScriptableObject
{
    [SerializeField] private string mCodeName;
    [SerializeField] private Item mPrefab;

    public string CodeName => mCodeName;
    public Item Prefab => mPrefab;
}
