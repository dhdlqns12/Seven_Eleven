using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private AudioSource sfxSource;

    [Header("Audio Mixer")]
    [SerializeField] private AudioMixer audioMixer;

    [Header("BGM Clips")]
    [SerializeField] private AudioClip[] bgmClips;

    [Header("SFX Clips")]
    [SerializeField] private AudioClip[] sfxClips;

    private float currentMasterVolume;
    private float currentBGMVolume;
    private float currentSFXVolume;

    private void Start()
    {
        LoadAudioSetting();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnsceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnsceneLoaded;
    }

    private void OnsceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayBGM(scene.buildIndex);
        LoadAudioSetting();
    }

    #region 볼륨 설정
    public void SetMasterVolume(float volume)
    {
        currentMasterVolume = volume;

        if (volume == 0)
        {
            audioMixer.SetFloat("MasterVolume", -80f);
        }
        else
        {
            audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
        }

        PlayerPrefs.SetFloat("MasterVolume", volume);
    }

    public void SetBGMVolume(float volume)
    {
        currentBGMVolume = volume;

        if (volume == 0)
        {
            audioMixer.SetFloat("BGMVolume", -80f);
        }
        else
        {
            audioMixer.SetFloat("BGMVolume", Mathf.Log10(volume) * 20);
        }

        PlayerPrefs.SetFloat("BGMVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        currentSFXVolume = volume;

        if (volume == 0)
        {
            audioMixer.SetFloat("SFXVolume", -80f);
        }
        else
        {
            audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
        }

        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    private void LoadAudioSetting()
    {
        float master = PlayerPrefs.GetFloat("MasterVolume", 1f);
        float bgm = PlayerPrefs.GetFloat("BGMVolume", 1f);
        float sfx = PlayerPrefs.GetFloat("SFXVolume", 1f);

        VolumeMixerSetting("MasterVolume", master);
        VolumeMixerSetting("BGMVolume", bgm);
        VolumeMixerSetting("SFXVolume", sfx);
    }

    private void VolumeMixerSetting(string paramName, float volume)
    {
        float db;

        if (volume == 0)
        {
            db = -80f;
        }
        else
        {
            db = Mathf.Log10(volume) * 20;
        }

        audioMixer.SetFloat(paramName, db);
    }

    public float GetMasterVolume() => PlayerPrefs.GetFloat("MasterVolume", 1f);
    public float GetBGMVolume() => PlayerPrefs.GetFloat("BGMVolume", 1f);
    public float GetSFXVolume() => PlayerPrefs.GetFloat("SFXVolume", 1f);
    #endregion

    #region BGM 관리
    public void PlayBGM(int index)
    {
        if (bgmClips.Length == 0 || index >= bgmClips.Length)
        {
            return;
        }

        if (bgmClips[index] == null)
        {
            return;
        }

        if (bgmSource.clip == bgmClips[index] && bgmSource.isPlaying)
        {
            return;
        }

        bgmSource.clip = bgmClips[index];
        bgmSource.loop = true;
        bgmSource.Play();
    }
    #endregion

    #region SFX 관리
    public void PlaySfx(AudioClip clip)
    {
        if (clip != null && sfxSource != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }
    #endregion

    #region 뮤트 기능
    public void SetBGMMute(bool mute)
    {
        AudioListener.volume = mute ? 1 : 0;
    }
    #endregion
}
