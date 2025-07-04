#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(SceneField))]
public class SceneFieldPropertyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // 변수 파싱
        SerializedProperty sceneAsset = property.FindPropertyRelative("mSceneAsset");
        SerializedProperty sceneName = property.FindPropertyRelative("mSceneName");

        // 할당 공간
        sceneAsset.objectReferenceValue =
            EditorGUI.ObjectField(position, label, sceneAsset.objectReferenceValue, typeof(SceneAsset), false);

        // 할당 되어 있지 않으면 Value 는 Null 로 항상 초기화
        if (!sceneAsset.objectReferenceValue)
        {
            if (sceneAsset.objectReferenceValue)
            {
                sceneAsset.objectReferenceValue = null;
            }

            if (!string.IsNullOrEmpty(sceneName.stringValue))
            {
                sceneName.stringValue = null;
            }
            
            return;
        }

        // 할당 되어 있으면 이름 가져오기
        sceneName.stringValue = sceneAsset.objectReferenceValue.name;
    }
}
#endif