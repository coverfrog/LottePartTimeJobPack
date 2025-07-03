using System;
using Sirenix.OdinInspector;
using UnityEngine;

public enum CamType
{
    Main,
    UI
}

[Serializable]
public class CamOption
{
    [Title("Type")]
    [SerializeField] private CamType mCamType;

    public CamType CamType => mCamType;
    
    [Title("Follow")]
    [SerializeField] private float mFollowDistance = 3.0f;
    [SerializeField] private float mFollowHeight = 3.0f;
    [SerializeField] private float mFollowSmooth = 5.0f;

    public float FollowDistance => mFollowDistance;
    public float FollowHeight => mFollowHeight;
    public float FollowSmooth => mFollowSmooth;
}
