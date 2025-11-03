using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class StageClearUI : UIBase
{
    [Header("UI")]
    [SerializeField] private Image[] stars;
    [SerializeField] private Button restart_Btn;
    [SerializeField] private Button goToStageSelect_Btn;
    [SerializeField] private Button nextStage_Btn;

    [Header("점수")]
    [SerializeField] private Sprite activeStar; // 활성화 된 별
    [SerializeField] private Sprite inActiveStar; // 비활성화 된 별

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
        nextStage_Btn?.onClick.AddListener(NextStageButton);
    }

    protected override void UnsubscribeEvents()
    {
        restart_Btn?.onClick.RemoveAllListeners();
        goToStageSelect_Btn?.onClick.RemoveAllListeners();
        nextStage_Btn?.onClick.RemoveAllListeners();
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

    private void NextStageButton()
    {
        Time.timeScale = 1f; 
        Close();

        string currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        string numberPart = currentScene.Replace("Stage", "").Replace(" ", "");

        if (int.TryParse(numberPart, out int currentStage))
        {
            int nextStage = currentStage + 1;

            if (nextStage <= 5)
            {
                ManagerRoot.SceneController.LoadStageScene(nextStage);
            }
            else
            {
                ManagerRoot.SceneController.LoadStageSelectScene();
            }
        }
        ManagerRoot.AudioManager.PlaySfx(clickbtn);
    }
    #endregion
}
