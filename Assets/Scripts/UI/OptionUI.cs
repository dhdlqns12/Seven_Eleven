using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionUI : UIBase
{
    [Header("옵션창")]
    [SerializeField] private Button optionExitButton;
    [SerializeField] private Button settingSaveButton;

    [Header("사운드 세팅")]
    [SerializeField] private Slider masterVolumeSlider;
    [SerializeField] private TextMeshProUGUI masterVolumeSliderText;
    [SerializeField] private Slider bgmVolumeSlider;
    [SerializeField] private TextMeshProUGUI bgmVolumeSliderText;
    [SerializeField] private Slider sfxVolumeSlider;
    [SerializeField] private TextMeshProUGUI sfxVolumeSliderText;

    [Header("해상도 세팅")]
    [SerializeField] private TMP_Dropdown screenDropdown;

    [Header("키보드 세팅")]
    [SerializeField] private Button keySettingButton;

    [Header("효과음")]
    [SerializeField] private AudioClip clickbtn;

    protected override void SetupUI()
    {

    }

    protected override void OnShow()
    {
        InitializeResolutionDropdown();

        if (ManagerRoot.AudioManager != null)
        {
            masterVolumeSlider.SetValueWithoutNotify(ManagerRoot.AudioManager.GetMasterVolume() * 100f);
            bgmVolumeSlider.SetValueWithoutNotify(ManagerRoot.AudioManager.GetBGMVolume() * 100f);
            sfxVolumeSlider.SetValueWithoutNotify(ManagerRoot.AudioManager.GetSFXVolume() * 100f);

            masterVolumeSliderText.text = Mathf.RoundToInt(masterVolumeSlider.value) + "%";
            bgmVolumeSliderText.text = Mathf.RoundToInt(bgmVolumeSlider.value) + "%";
            sfxVolumeSliderText.text = Mathf.RoundToInt(sfxVolumeSlider.value) + "%";
        }
    }

    #region 이벤트 구독/해제
    protected override void SubscribeEvents()
    {
        optionExitButton?.onClick.AddListener(OptionExitButton);
        settingSaveButton?.onClick.AddListener(SettingSaveButton);
        keySettingButton?.onClick.AddListener(KeySettingButton);

        masterVolumeSlider?.onValueChanged.AddListener(MasterVolumeSlider);
        bgmVolumeSlider?.onValueChanged.AddListener(BGMVolumeSlider);
        sfxVolumeSlider?.onValueChanged.AddListener(SFXVolumeSlider);

        screenDropdown?.onValueChanged.AddListener(ScreenDropdown);
    }

    protected override void UnsubscribeEvents()
    {
        optionExitButton?.onClick.RemoveAllListeners();
        settingSaveButton?.onClick.RemoveAllListeners();
        keySettingButton?.onClick.RemoveAllListeners();

        masterVolumeSlider?.onValueChanged.RemoveAllListeners();
        bgmVolumeSlider?.onValueChanged.RemoveAllListeners();
        sfxVolumeSlider?.onValueChanged.RemoveAllListeners();

        screenDropdown?.onValueChanged.RemoveAllListeners();
    }
    #endregion

    #region 버튼 메서드
    private void OptionExitButton()
    {
        ManagerRoot.AudioManager.PlaySfx(clickbtn);
        ManagerRoot.UIManager.ClosePanel<OptionUI>();
    }

    private void SettingSaveButton()
    {
        ManagerRoot.AudioManager.PlaySfx(clickbtn);
        PlayerPrefs.Save();
    }

    private void KeySettingButton()
    {
        ManagerRoot.AudioManager.PlaySfx(clickbtn);
        ManagerRoot.UIManager.ShowPanel<KeySettingUI>();
    }
    #endregion

    #region 슬라이더 메서드
    private void MasterVolumeSlider(float value)
    {
        ManagerRoot.AudioManager.SetMasterVolume(value / 100f);
        masterVolumeSliderText.text = Mathf.RoundToInt(value) + "%";
    }

    private void BGMVolumeSlider(float value)
    {
        ManagerRoot.AudioManager.SetBGMVolume(value / 100f);
        bgmVolumeSliderText.text = Mathf.RoundToInt(value) + "%";
    }

    private void SFXVolumeSlider(float value)
    {
        ManagerRoot.AudioManager.SetSFXVolume(value / 100f);
        sfxVolumeSliderText.text = Mathf.RoundToInt(value) + "%";
    }
    #endregion

    #region 드롭다운 메서드
    private void ScreenDropdown(int index)
    {
        //효과음 재생
        //인덱스로 해상도 가져오기
        //게임매니저에 SetResolution() 호출
    }

    private void InitializeResolutionDropdown()
    {
        //해상도 리스트 정의
        //드롭다운에 옵션 클리어/추가
        //게임매니저 GetCurrentResolutionIndex()로 현재 선택
    }
    #endregion

}