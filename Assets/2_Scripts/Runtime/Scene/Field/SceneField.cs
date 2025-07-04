using System;
using UnityEngine;
using Object = UnityEngine.Object;

/// <summary>
/// Operator 를 넣긴 했지만 직접 참조하는게 편할 수도 있으므로 Get 넣어둠
/// </summary>
[Serializable]
public class SceneField
{
    [SerializeField] private Object mSceneAsset;
    [SerializeField] private string mSceneName;

    public bool HasValue => !string.IsNullOrEmpty(mSceneName);
    
    public string SceneName => mSceneName;
}
