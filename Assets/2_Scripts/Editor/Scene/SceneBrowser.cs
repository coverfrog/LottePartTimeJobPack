#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBrowser : EditorWindow
{
    private static bool _mIsRefresh;
    
    [MenuItem("Cf/Scene/Browser")]
    public static void Open()
    {
        _ = GetWindow<SceneBrowser>();
        
    }

    private void OnGUI()
    {
        ShowOption();
        GUILayout.Label("");
        ShowPathList();
    }

    private static void ShowOption()
    {
        // head

        GUIStyle headStyle = new GUIStyle(GUI.skin.label)
        {
            fontSize = 20,
            fontStyle = FontStyle.Bold,
            padding = new RectOffset(0,0,0,0),
            margin = new RectOffset(3,0,0,0),
        };
        
        GUILayout.Label("Option", headStyle);
        
        // option
        GUIStyle style = new GUIStyle(GUI.skin.button)
        {
            fixedHeight = 30,
        };

        _mIsRefresh = GUILayout.Toggle(_mIsRefresh, "Refresh", style);
    }

    private static void ShowPathList()
    {
        // todo : get relative path list
        List<string> relativePathList = GetRelativePathList();
        
        // todo : show 
        GetShowPathList(relativePathList);
    }

    private static List<string> GetRelativePathList()
    {
        List<SceneAsset> sceneAssetList = new List<SceneAsset>();
        
        FindAssets.Find(ref sceneAssetList);

        string relativePath = "";
        
        List<string> relativePathList = new List<string>(sceneAssetList.Count);
       
        foreach (SceneAsset sceneAsset in sceneAssetList)
        {
            FindAssets.RelativePath(sceneAsset, false, ref relativePath);

            if (relativePath.StartsWith("Packages"))
                continue;
            
            relativePathList.Add(relativePath);
        }

        return relativePathList;
    }

    private static void GetShowPathList(List<string> relativePathList)
    {
        const float fixedHeight = 30;
        
        // head

        GUIStyle headStyle = new GUIStyle(GUI.skin.label)
        {
            fontSize = 20,
            fontStyle = FontStyle.Bold,
            padding = new RectOffset(0,0,0,0),
            margin = new RectOffset(3,0,0,0),
        };
        
        GUILayout.Label("Scene List", headStyle);
        
        // repeat
        for (var i = 0; i < relativePathList.Count; i++)
        {
            string scenePath = relativePathList[i];

            GUIStyle idxStyle = new GUIStyle(GUI.skin.label)
            {
                fixedHeight = fixedHeight,
            };

            GUIStyle btnStyle = new GUIStyle(GUI.skin.button)
            {
                fixedHeight = fixedHeight,
                alignment = TextAnchor.MiddleLeft
            };

            try
            {
                EditorGUILayout.BeginHorizontal();
                
                EditorGUILayout.LabelField(
                    i.ToString(), 
                    idxStyle, 
                    GUILayout.ExpandWidth(false),
                    GUILayout.Width(25));
                
                if (GUILayout.Button(
                        scenePath, 
                        btnStyle, 
                        GUILayout.ExpandWidth(true)))
                {
                    string path = Path.Combine("Assets", scenePath);
                    
                    EditorSceneManager.OpenScene(path);
                }
            }
            catch (Exception e)
            {
                throw;
            }

            finally
            {
                EditorGUILayout.EndHorizontal();   
            }
        }
    }
}

#endif