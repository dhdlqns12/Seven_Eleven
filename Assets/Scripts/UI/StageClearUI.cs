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

    #region 버튼 메서드
    private void RestartButton()
    {
        ManagerRoot.SceneController.RestartScene();
    }

    private void GoToStageSelectButton()
    {
        ManagerRoot.SceneController.LoadStageSelectScene();
    }
    #endregion
}
