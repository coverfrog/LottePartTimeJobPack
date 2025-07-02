using UnityEngine;

public abstract class CamBase : ScriptableObject
{
    public abstract void OnLateUpdate(Cam cam);
}
