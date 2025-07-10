using UnityEngine;

public abstract class MoveActor : ScriptableObject
{
    public abstract void MoveBegin(MoveHelper moveHelper, Vector2 dir, float duration);

    public abstract void Moving(MoveHelper moveHelper, Vector2 dir, float duration);

    public abstract void MoveEnd(MoveHelper moveHelper, Vector2 dir, float duration);
}
