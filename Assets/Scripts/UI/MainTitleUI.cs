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
    [SerializeField] private Button soundOnButton;
    [SerializeField] private Button soundOffButton;
    [SerializeField] private Image soundOnOffButtonImage;
    [SerializeField] private Sprite soundOnSprite;
    [SerializeField] private Sprite soundOffSprite;

    [Header("효과음")]
    [SerializeField] private AudioClip clickbtn;

    protected override void SetupUI()
    {
        soundOffButton.gameObject.SetActive(false);
        soundOnButton.gameObject.SetActive(true);
    }

    #region 이벤트 구독/해제
    protected override void SubscribeEvents()
    {
        startButton?.onClick.AddListener(GameStartButton);
        optionButton?.onClick.AddListener(OptionButton);
        //achievementButton?.onClick.AddListener(AchievementButton);
        //customizingButton?.onClick.AddListener(CustomizingButton);
        exitButton?.onClick.AddListener(ExitButton);
        //soundOnOffButton?.onClick.AddListener(SoundOnOffButton);
        soundOnButton?.onClick.AddListener(SoundOnButton);
        soundOffButton?.onClick.AddListener(SoundOffButton);
    }

    protected override void UnsubscribeEvents()
    {
        startButton?.onClick.RemoveAllListeners();
        optionButton?.onClick.RemoveAllListeners();
        //achievementButton?.onClick.RemoveAllListeners();
        //customizingButton?.onClick.RemoveAllListeners();
        exitButton?.onClick.RemoveAllListeners();
        //soundOnOffButton?.onClick.RemoveAllListeners();
        soundOnButton?.onClick.RemoveAllListeners();
        soundOffButton?.onClick.RemoveAllListeners();
    }
    #endregion

    #region 버튼 메서드
    private void GameStartButton()
    {
        ManagerRoot.AudioManager.PlaySfx(clickbtn);
        ManagerRoot.SceneController.LoadStageSelectScene();
    }

    private void OptionButton()
    {
        ManagerRoot.AudioManager.PlaySfx(clickbtn);
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
        ManagerRoot.AudioManager.PlaySfx(clickbtn);
        Application.Quit();
    }

    private void SoundOnButton()
    {
        ManagerRoot.AudioManager.PlaySfx(clickbtn);
        ManagerRoot.AudioManager.SetBGMMute(false);

        soundOnButton.gameObject.SetActive(false);
        soundOffButton.gameObject.SetActive(true);
    }

    private void SoundOffButton()
    {
        ManagerRoot.AudioManager.PlaySfx(clickbtn);
        ManagerRoot.AudioManager.SetBGMMute(true);

        soundOffButton.gameObject.SetActive(false);
        soundOnButton.gameObject.SetActive(true);
    }
    #endregion
}
