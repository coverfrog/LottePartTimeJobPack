using System;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public class InteractDetectOption
{
    [Title("Ray")] 
    [SerializeField] private LayerMask mRayLayer;
    [SerializeField] private float mRayDistance = 1.0f;
    [SerializeField] private float mRayHeight = 1.0f;
    
    public LayerMask RayLayer => mRayLayer;
    public float RayDistance => mRayDistance;
    public float RayHeight => mRayHeight;
}
