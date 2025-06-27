using System;
using UnityEngine;

/// <summary>
/// Node 에 대한 스폰 및 전반적인 모든 것을 처리
/// </summary>
public class NodeSys : MonoBehaviour
{
    #region 노트 시스템에 대한 여담

    /*
     *  노트 시스템은 수동, 자동 2가지 방식으로 가능
     *  수동으로 만드는게 좀 더 게임 자체는 재밌겠지만
     *  우선 물량 채우기 용으로 자동 버전도 만들기
     *
     *  샌드 박스모드처럼 실시간으로 사용 가능하게
     *  만드는 편이 좀 더 좋을것도 같음 
     * 
     *  수동
     *      키 찍어가면서 만들면 됨
     *  자동
     *      요 부분에서 푸리에 변환 사용
     *      주파수 최소, 최대 값을 구해서 그 분배를
     *      주는 형식으로 구현
     */

    #endregion

    #region 푸리에 변환

    // ReSharper disable Unity.PerformanceAnalysis
    /// <summary>
    /// 본래라면 Audio Source 를 고정적으로 쓰는게 좋겠지만
    /// Editor 에서도 지원 확장성을 위해 Object 를 생성햇다가
    /// 작업 끝나면 바로 삭제하는 방식으로 진행
    /// </summary>
    /// <param name="audioClip"></param>
    /// <param name="fftWindow"></param>
    /// <param name="sampleCount"></param>
    public static float[] ConvertAudioToNode(AudioClip audioClip, FFTWindow fftWindow, int sampleCount)
    {
        // 샘플의 범위는 64 ~ 8192가능
        // 유니티 자체의 제한 범위
        float[] samples = new float[sampleCount];
        
        GameObject obj = new GameObject("Get Audio Data", typeof(AudioSource));

        try
        {
            _ = obj.TryGetComponent(out AudioSource audioSource);

            audioSource.clip = audioClip;
            audioSource.GetSpectrumData(samples, audioClip.channels, fftWindow );
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }

        finally
        {
            DestroyImmediate(obj);
        }

        return samples;
    }

    #endregion
}
