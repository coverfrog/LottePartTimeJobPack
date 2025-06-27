using UnityEngine;
using System;

/// <summary>
/// Node 1개에 대한 정보 
/// </summary>
[Serializable]
public class NodeData
{
    [SerializeField] private double time;
    [SerializeField] private int lane;

    public double Time => time;
    public int Lane => lane;
}
