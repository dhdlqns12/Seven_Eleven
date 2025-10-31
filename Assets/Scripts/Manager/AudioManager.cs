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
    [SerializeField] private AudioClip sfxClips;

    private bool isMuted = false;
    private float lastMasterVolume;

    private void Awake()
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
    }

    #region 볼륨 설정
    public void SetMasterVolume(float volume)
    {
        lastMasterVolume = volume;

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
        float mastervolume = PlayerPrefs.GetFloat("MasterVolume", 1f);
        float bgmVolume = PlayerPrefs.GetFloat("BGMVolume", 1f);
        float sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);

        lastMasterVolume = mastervolume;
        isMuted = PlayerPrefs.GetInt("Muted", 0) == 1;
        if (isMuted)
        {
            audioMixer.SetFloat("MasterVolume", -80f);
        }
        else
        {
            SetMasterVolume(mastervolume);
        }

        SetBGMVolume(bgmVolume);
        SetSFXVolume(sfxVolume);
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
