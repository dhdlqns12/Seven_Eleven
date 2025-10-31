using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainTitleUI : UIBase
{
    [Header("메인 타이틀 UI")]
    [SerializeField] private Button startButton;
    [SerializeField] private Button optionButton;
    //[SerializeField] private Button achievementButton;
    [SerializeField] private Button customizingButton;
    [SerializeField] private Button exitButton;

    [Header("뮤트 버튼")]
    [SerializeField] private Button soundOnOffButton;
    [SerializeField] private Image soundOnOffButtonImage;
    [SerializeField] private Sprite soundOnSprite;
    [SerializeField] private Sprite soundOffSprite;

    protected override void SetupUI()
    {

    }

    #region 이벤트 구독/해제
    protected override void SubscribeEvents()
    {
        startButton?.onClick.AddListener(GameStartButton);
        optionButton?.onClick.AddListener(OptionButton);
        //achievementButton?.onClick.AddListener(AchievementButton);
        //customizingButton?.onClick.AddListener(CustomizingButton);
        exitButton?.onClick.AddListener(ExitButton);
        soundOnOffButton?.onClick.AddListener(SoundOnOffButton);
    }

    protected override void UnsubscribeEvents()
    {
        startButton?.onClick.RemoveAllListeners();
        optionButton?.onClick.RemoveAllListeners();
        //achievementButton?.onClick.RemoveAllListeners();
        //customizingButton?.onClick.RemoveAllListeners();
        exitButton?.onClick.RemoveAllListeners();
        soundOnOffButton?.onClick.RemoveAllListeners();
    }
    #endregion

    #region 버튼 메서드
    private void GameStartButton()
    {
        ManagerRoot.TempSceneManager.LoadStageSelectScene();
    }

    private void OptionButton()
    {
        ManagerRoot.UIManager.ShowPanel<OptionUI>();
    }

    //private void AchievementButton()
    //{
    //    ManagerRoot.UIManager.ShowPanel<AchievementUI>();
    //}

    //private void CustomizingButton()
    //{
    //    ManagerRoot.UIManager.ShowPanel<CustomizingUI>();
    //}

    private void ExitButton()
    {
        Application.Quit();
    }

    private void SoundOnOffButton()
    {
        ManagerRoot.AudioManager.AudioMute();
        SoundOnOffButtonUIUpdate();
    }

    private void SoundOnOffButtonUIUpdate()
    {
        if(soundOnOffButtonImage != null)
        {
            if (ManagerRoot.AudioManager.IsMuted())
            {
                soundOnOffButtonImage.sprite = soundOnSprite;
            }
            else
            {
                soundOnOffButtonImage.sprite = soundOffSprite;
            }
        }
    }
    #endregion
}
