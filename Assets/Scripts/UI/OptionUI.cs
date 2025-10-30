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
    [SerializeField] private TextMeshProUGUI masterVolumeSlider_Text;
    [SerializeField] private Slider bgmVolumeSlider;
    [SerializeField] private TextMeshProUGUI bgmVolumeSlider_Text;
    [SerializeField] private Slider sfxVolumeSlider;
    [SerializeField] private TextMeshProUGUI sfxVolumeSlider_Text;

    [Header("해상도 세팅")]
    [SerializeField] private Dropdown screenDropdown;

    [Header("키보드 세팅")]
    [SerializeField] private Button keySettingButton;

    protected override void SetupUI()
    {
        
    }

    #region 이벤트 구독/해제
    protected override void SubscribeEvents()
    {
        
    }

    protected override void UnsubscribeEvents()
    {
        
    }
    #endregion

    #region 버튼 메서드
    private void OptionExitButton()
    {
        ManagerRoot.UIManager.ClosePanel<OptionUI>();
    }

    private void SettingSaveButton()
    {

    }

    private void KeySettingButton()
    {
        //ManagerRoot.UIManager.ShowPanel<>();
    }
    #endregion

    #region 슬라이더
    private void MasterVolumeSlider(float value)
    {
        //ManagerRoot.AudioManager.SetMasterVolume(value);
    }

    private void MasterVolumSliderText()
    {

    }
    #endregion

}