using System;
using UnityEngine;

[Serializable]
public class CamOption
{
    [SerializeField] private float mFollowDistance = 3.0f;
    [SerializeField] private float mFollowHeight = 3.0f;
    [SerializeField] private float mFollowSmooth = 5.0f;

    public float FollowDistance => mFollowDistance;
    public float FollowHeight => mFollowHeight;
    public float FollowSmooth => mFollowSmooth;
}
