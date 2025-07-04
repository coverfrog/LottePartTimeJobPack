using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTitle : SceneHandler
{
    [Title("Option")] 
    [SerializeField] private SceneField mNextScene;
    [SerializeField] private float mWaitSec = 1.0f;
        
    #region Start

    /// <summary>
    /// Start
    /// </summary>
    protected override void Start()
    {
        base.Start();

        StartCoroutine(CoLoadNextScene());
    }

    #endregion

    #region Co Load Next Scene

    /// <summary>
    /// {n} 초 동안 대기 후 다음 Scene 호출
    /// </summary>
    /// <returns></returns>
    private IEnumerator CoLoadNextScene()
    {
        // Null 확인
        if (!mNextScene.HasValue)
        {
#if UNITY_EDITOR
            Debug.LogError("Next Scene Is Null");
#endif
            yield break;
        }
        
        // 대기
        yield return StaticYield.Sec(mWaitSec);
        
        // 로딩
        SceneManager.LoadScene(mNextScene.SceneName);
    }

    #endregion
}
