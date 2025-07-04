using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMainMenu : SceneHandler
{
    [Title("References")]
    [SerializeField] private UIMainMenu mUIMainMenu;
    
    #region Start

    /// <summary>
    /// Start
    /// </summary>
    protected override void Start()
    {
        // base
        base.Start();
        
        // on start
        mUIMainMenu.OnStart(this);
    }

    #endregion

    #region Load Next Scene, Co Load Next Scene

    public void LoadNextScene(SceneField sceneField)
    {
        StartCoroutine(CoLoadNextScene(sceneField));
    }
    
    private static IEnumerator CoLoadNextScene(SceneField sceneField)
    {
        // null 확인
        if (!sceneField.HasValue)
        {
#if UNITY_EDITOR
            Debug.LogError("Next Scene Is Null");
#endif
            yield break;
        }
        
        // 로딩
        SceneManager.LoadScene(sceneField.SceneName);
    }

    #endregion
}
