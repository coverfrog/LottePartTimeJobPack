using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public static partial class Utils
{
    public static class Logs
    {
        [Conditional("UNITY_EDITOR")]
        public static void Log(object o)
        {
            Debug.Log(o);    
        }
        [Conditional("UNITY_EDITOR")]
        public static void LogWarning(object o)
        {
            Debug.LogWarning(o);    
        }
        
        [Conditional("UNITY_EDITOR")]
        public static void LogError(object o)
        {
            Debug.LogError(o);    
        }
    }
}