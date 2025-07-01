using UnityEngine;

public abstract class MoveBase : ScriptableObject
{
    public abstract void MoveBegin(MoveData data);

    public abstract void Moving(MoveData data);

    public abstract void MoveEnd(MoveData data);
}
