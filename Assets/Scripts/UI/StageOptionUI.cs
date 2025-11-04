using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageOptionUI : UIBase
{
    [Header("버튼")]
    [SerializeField] private Button optionButton;
    [SerializeField] private Button retryButton;
    [SerializeField] private Button homeButton;

    [Header("효과음")]
    [SerializeField] private AudioClip clickbtn;

    protected override void SetupUI()
    {
        
    }

    #region 이벤트 구독/해제
    protected override void SubscribeEvents()
    {
        optionButton?.onClick.AddListener(OptionButton);
        retryButton?.onClick.AddListener(RetryButton);
        homeButton?.onClick.AddListener(HomeButton);
    }

    protected override void UnsubscribeEvents()
    {
        optionButton?.onClick.RemoveAllListeners();
        retryButton?.onClick.RemoveAllListeners();
        homeButton?.onClick.RemoveAllListeners();
    }
    #endregion

    #region 버튼 메서드
    private void OptionButton()
    {
        ManagerRoot.AudioManager.PlaySfx(clickbtn);
        Time.timeScale = 0;
        ManagerRoot.UIManager.ShowPanel<OptionUI>();
    }

    private void RetryButton()
    {
        ManagerRoot.SceneController.RestartScene();
        ManagerRoot.AudioManager.PlaySfx(clickbtn);
    }

    private void HomeButton()
    {
        if (ManagerRoot.UIManager.IsShowing<OptionUI>())
        {
            ManagerRoot.UIManager.ClosePanel<OptionUI>();
        }
        ManagerRoot.SceneController.LoadStageSelectScene();
        ManagerRoot.AudioManager.PlaySfx(clickbtn);
    }
    #endregion
}
