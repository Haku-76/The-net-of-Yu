using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private CinemachineVirtualCamera virtualCamera;
    private CinemachineBasicMultiChannelPerlin noiseProfile;
    [SerializeField]
    private float duration=0.3f;
    [SerializeField]
    private float amplitude=2f;
    [SerializeField]
    private float frequency=1f;

    void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        noiseProfile = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    /// <summary>
    /// ÕðÆÁ
    /// </summary>
    /// <param name="duration">Ê±³¤</param>
    /// <param name="amplitude">·ù¶È</param>
    /// <param name="frequency">ÆµÂÊ</param>
    public void CameraShaking()
    {
        if (noiseProfile != null)
        {
            noiseProfile.m_AmplitudeGain = amplitude;
            noiseProfile.m_FrequencyGain = frequency;
            Invoke(nameof(StopShaking), duration);
        }
    }

    /// <summary>
    /// Í£Ö¹ÕðÆÁ
    /// </summary>
    private void StopShaking()
    {
        if (noiseProfile != null)
        {
            noiseProfile.m_AmplitudeGain = 0f;
            noiseProfile.m_FrequencyGain = 0f;
        }
    }
}
