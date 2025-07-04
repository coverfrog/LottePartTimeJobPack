using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [Title("Option")]
    [SerializeField] private SceneField mGameScene;

    [Title("References")]
    [SerializeField] private Button mStartButton;

    #region OnStart

    public void OnStart(SceneMainMenu sceneMainMenu)
    {
        #region start button init

        mStartButton.onClick.RemoveAllListeners();
        mStartButton.onClick.AddListener(() =>
        {
            sceneMainMenu.LoadNextScene(mGameScene);
        });
        
        #endregion

    }

    #endregion
}
