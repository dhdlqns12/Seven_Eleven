using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageFailUI : UIBase
{
    [Header("UI")]
    [SerializeField] private Button restart_Btn;
    [SerializeField] private Button goToStageSelect_Btn;

    [Header("효과음")]
    [SerializeField] private AudioClip clickbtn;

    protected override void SetupUI()
    {
    }

    #region 이벤트 구독/해제
    protected override void SubscribeEvents()
    {
        restart_Btn?.onClick.AddListener(RestartButton);
        goToStageSelect_Btn?.onClick.AddListener(GoToStageSelectButton);
    }

    protected override void UnsubscribeEvents()
    {
        restart_Btn?.onClick.RemoveAllListeners();
        goToStageSelect_Btn?.onClick.RemoveAllListeners();
    }
    #endregion

    #region 열고 닫을 때 작동하는 메서드
    protected override void OnShow()
    {
        Time.timeScale = 0f;
    }

    protected override void OnClose()
    {
        Time.timeScale = 1f;
    }
    #endregion

    #region 버튼 메서드
    private void RestartButton()
    {
        Close();
        ManagerRoot.SceneController.RestartScene();
        ManagerRoot.AudioManager.PlaySfx(clickbtn);
    }

    private void GoToStageSelectButton()
    {
        Close();
        ManagerRoot.SceneController.LoadStageSelectScene();
        ManagerRoot.AudioManager.PlaySfx(clickbtn);
    }
    #endregion
}
