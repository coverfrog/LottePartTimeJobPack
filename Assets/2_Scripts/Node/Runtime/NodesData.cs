using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Node 전체를 저장할 클래스
/// </summary>
[Serializable]
public class NodesData
{
    [SerializeField] private List<NodeData> nodes;

    public IReadOnlyList<NodeData> Nodes => nodes;
}
