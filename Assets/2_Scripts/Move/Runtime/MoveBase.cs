using UnityEngine;

public abstract class MoveBase : ScriptableObject
{
    public abstract void MoveBegin(Move move);

    public abstract void Moving(Move move);

    public abstract void MoveEnd(Move move);
}
