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
