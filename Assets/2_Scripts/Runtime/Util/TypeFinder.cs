#if UNITY_EDITOR
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;

public static class TypeFinder 
{
    [Conditional("UNITY_EDITOR")]
    public static void Find<T>(ref List<T> source) where T : Object
    {
        List<T> result = new List<T>();
        
        string filter = $"t:{typeof(T).Name}";
        string[] guids = AssetDatabase.FindAssets(filter);

        foreach (var guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            T asset = AssetDatabase.LoadAssetAtPath<T>(path);

            if (asset == null) continue;
                
            result.Add(asset);
        }

        source = result;
    }
}

#endif