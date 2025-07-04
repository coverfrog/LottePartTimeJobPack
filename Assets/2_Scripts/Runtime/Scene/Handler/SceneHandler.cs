using System;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Scene 내부의 Loop 를 전부 관리
/// </summary>
public abstract class SceneHandler : MonoBehaviour
{
    #region Start

    /// <summary>
    /// 
    /// </summary>
    protected virtual void Start()
    {
#if UNITY_EDITOR
        Debug.Log($"Scene Start At `{SceneManager.GetActiveScene().name}`");
#endif
    }
    
    #endregion
}
