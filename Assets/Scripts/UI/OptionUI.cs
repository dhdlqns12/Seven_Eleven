using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionUI : UIBase
{
    [Header("옵션창")]
    [SerializeField] private Button optionExitButton;

    [Header("사운드 세팅")]
    [SerializeField] private Slider masterVolumeSlider;
    [SerializeField] private TextMeshProUGUI masterVolumeSliderText;
    [SerializeField] private Slider bgmVolumeSlider;
    [SerializeField] private TextMeshProUGUI bgmVolumeSliderText;
    [SerializeField] private Slider sfxVolumeSlider;
    [SerializeField] private TextMeshProUGUI sfxVolumeSliderText;

    [Header("해상도 세팅")]
    [SerializeField] private TMP_Dropdown screenDropdown;

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

        masterVolumeSlider?.onValueChanged.AddListener(MasterVolumeSlider);
        bgmVolumeSlider?.onValueChanged.AddListener(BGMVolumeSlider);
        sfxVolumeSlider?.onValueChanged.AddListener(SFXVolumeSlider);

        screenDropdown?.onValueChanged.AddListener(ScreenDropdown);
    }

    protected override void UnsubscribeEvents()
    {
        optionExitButton?.onClick.RemoveAllListeners();

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
    private List<Resolution> resolutions = new List<Resolution>();

    private void ScreenDropdown(int index)
    {
        ManagerRoot.AudioManager.PlaySfx(clickbtn);

        //인덱스로 해상도 가져오기
        Resolution selectedResolution = resolutions[index];

        //게임매니저에 SetResolution() 호출
        ManagerRoot.GameManager.SetResolution(selectedResolution.width, selectedResolution.height, FullScreenMode.Windowed);
    }

    private void InitializeResolutionDropdown()
    {
        resolutions.Clear();
        HashSet<string> addedResolutions = new HashSet<string>();

        //해상도 리스트 정의
        foreach (Resolution item in Screen.resolutions)
        {
            if((item.width * 9 == item.height * 16) && item.width >= 1280)
            {
                string resolutionKey = item.width + "x" + item.height;

                if (!addedResolutions.Contains(resolutionKey))
                {
                    resolutions.Add(item);
                    addedResolutions.Add(resolutionKey);
                } 
            }
        }

        //드롭다운에 옵션 클리어/추가
        List<string> options = new List<string>();
        foreach(Resolution item in resolutions)
        {
            options.Add(item.width + " x " + item.height);
        }

        screenDropdown.ClearOptions();
        screenDropdown.AddOptions(options);

        //GetCurrentResolutionIndex()로 현재 해상도 선택
        int currentIndex = GetCurrentResolutionIndex();
        screenDropdown.SetValueWithoutNotify(currentIndex);
    }

    public int GetCurrentResolutionIndex()
    {
        //현재 해상도와 일치하는 인덱스 반환

        int currentWidth = Screen.width;
        int currentHeight = Screen.height;
        
        for(int i = 0; i < resolutions.Count; i++)
        {
            if(resolutions[i].width == currentWidth && resolutions[i].height == currentHeight)
            {
                return i;
            }
        }

        return 0;
    }
    #endregion

}