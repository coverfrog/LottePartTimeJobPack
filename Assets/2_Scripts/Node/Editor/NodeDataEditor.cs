#if UNITY_EDITOR

using System;
using UnityEngine;
using UnityEditor;

/// <summary>
/// Node Data 를 생성하고 지정된 형식에 맞게
/// 파일을 생성하는 클래스
///
/// 다만 샌드박스 모드를 고려해서
/// 실제 변환하는 작업은 Sys 에서 진행
/// </summary>
public class NodeDataEditor : EditorWindow
{
    private static AudioClip _mSelectClip;
    private static FFTWindow _mFFTWindow;
    private static int _mSampleCount = SampleMinCount;

    // GetSpectrumData 함수의 제한 범위 최소
    private const int SampleMinCount = 64;
    
    // GetSpectrumData 함수의 제한 범위 최대
    private const int SampleMaxCount = 8192;
    
    [MenuItem("_Cf_/Node Editor")]
    private static void Init()
    {
        _ = GetWindow<NodeDataEditor>();
    }

    private void OnGUI()
    {
        _mSelectClip = (AudioClip)EditorGUILayout.ObjectField("AudioClip", _mSelectClip, typeof(AudioClip), false);
        _mFFTWindow = (FFTWindow)EditorGUILayout.EnumPopup("FFTWindow", _mFFTWindow);
        _mSampleCount = EditorGUILayout.IntSlider("Samples", _mSampleCount, SampleMinCount, SampleMaxCount);
        
        EditorGUILayout.Space();
        
        if (GUILayout.Button("Convert"))
        {
            if (!_mSelectClip) 
                return;
            
            float[] samples = NodeSys.ConvertAudioToNode(_mSelectClip, _mFFTWindow, _mSampleCount);
        }
    }
}

#endif