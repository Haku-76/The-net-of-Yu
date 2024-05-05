using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public Slider BGM_Slider;
    public Slider SE_Slider;

    [Space(10)]
    [SerializeField] AudioSource bgmAudioSource;
    [SerializeField] AudioSource seAudioSource;

    [Space(10)]
    [SerializeField] List<BGMSoundData> bgmSoundDatas;
    [SerializeField] List<SESoundData> seSoundDatas;

    [Space(10)]
    public float bgmMasterVolume;
    public float seMasterVolume;

    public static SoundManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        BGM_Slider.value = 0.5f;
        SE_Slider.value = 0.5f;
        PlayBGM(BGMSoundData.BGM.Title);
    }

    public void Update()
    {
        if(SceneManager.GetActiveScene().name == "Start")
        {
            bgmMasterVolume = BGM_Slider.value;
            seMasterVolume = SE_Slider.value;
            bgmAudioSource.volume = bgmMasterVolume;
            seAudioSource.volume = seMasterVolume;
        }
    }

    public void PlayBGM(BGMSoundData.BGM bgm)
    {
        BGMSoundData data = bgmSoundDatas.Find(data => data.bgm == bgm);
        bgmAudioSource.clip = data.audioClip;
        bgmAudioSource.volume = bgmMasterVolume;
        bgmAudioSource.loop = true;
        bgmAudioSource.Play();
    }

    public void StopBGM()
    {
        bgmAudioSource.Stop();
    }

    public void VolumChangeBGM(float newVolume)
    {
        bgmAudioSource.volume = newVolume;
    }

    public void PlaySE(SESoundData.SE se)
    {
        SESoundData data = seSoundDatas.Find(data => data.se == se);
        seAudioSource.volume = seMasterVolume;
        seAudioSource.PlayOneShot(data.audioClip);
    }

}

[System.Serializable]
public class BGMSoundData
{
    public enum BGM
    {
        Title,
        HomePage
    }

    public BGM bgm;
    public AudioClip audioClip;
    [Range(0, 1)]
    public float volume = 1;
}

[System.Serializable]
public class SESoundData
{
    public enum SE
    {
        Book,
        Button,
        Net,
        Sold,
        FinishedFishing,
        Damage,
        Hoge,
    }

    public SE se;
    public AudioClip audioClip;
    [Range(0, 1)]
    public float volume = 1;
}