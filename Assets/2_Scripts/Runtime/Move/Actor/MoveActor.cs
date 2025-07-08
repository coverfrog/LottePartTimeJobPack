using UnityEngine;

public abstract class MoveActor : ScriptableObject
{
    public abstract void MoveBegin(MoveHelper moveHelper, Vector2 dir);

    public abstract void Moving(MoveHelper moveHelper, Vector2 dir);

    public abstract void MoveEnd(MoveHelper moveHelper, Vector2 dir);
}
