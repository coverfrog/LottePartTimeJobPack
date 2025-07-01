using System;
using UnityEngine;

[Serializable]
public class MoveData
{
    public Rigidbody rigidBody;
    public Vector2 dir;
    public float moveSpeed;
    public float rotSpeed;
}
