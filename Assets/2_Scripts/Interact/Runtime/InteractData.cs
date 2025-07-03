using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public class InteractData
{
    [SerializeField] private List<Item> mItemAddList;

    public IReadOnlyList<Item> ItemAddList => mItemAddList;
}