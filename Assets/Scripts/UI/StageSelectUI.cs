using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelectUI : UIBase
{
    [Header("UI")]
    [SerializeField] private Button goToMain_Btn;

    [Header("스테이지 선택 버튼")]
    [SerializeField] private Button[] stageSelect_Btn;

    [Header("버튼 이미지")]
    [SerializeField] private Sprite unlockedSprite;
    [SerializeField] private Sprite lockedSprite;

    protected override void SetupUI()
    {
    }

    #region 스테이지 버튼 업데이트
    protected override void OnShow()
    {
        UpdateStageButtons();
    }

    private void UpdateStageButtons()
    {
        for (int i = 0; i < stageSelect_Btn.Length; i++)
        {
            int stageNumber = i + 1;
            bool isUnlocked = IsStageUnlocked(stageNumber);

            stageSelect_Btn[i].interactable = isUnlocked;
        }
    }

    private bool IsStageUnlocked(int stageNumber)
    {
        if (stageNumber == 1) return true;

        int previousStage = stageNumber - 1;
        return PlayerPrefs.GetInt($"Stage_{previousStage}_Cleared", 0) == 1;
    }
    #endregion

    #region 이벤트 구독/해제
    protected override void SubscribeEvents()
    {
        goToMain_Btn?.onClick.AddListener(GoToMainButton);
        for (int i =0;i<stageSelect_Btn.Length;i++)
        {
            int stageIndex = i;
            stageSelect_Btn[i]?.onClick.AddListener(() => OnStageButtonClicked(stageIndex + 1));
        }
    }

    protected override void UnsubscribeEvents()
    {
        goToMain_Btn?.onClick.RemoveAllListeners();

        for (int i = 0; i < stageSelect_Btn.Length; i++)
        {
            stageSelect_Btn[i]?.onClick.RemoveAllListeners();
        }
    }
    #endregion

    #region 버튼이벤트
    private void OnStageButtonClicked(int stageNumber)
    {
        if (!IsStageUnlocked(stageNumber))
        {
            return;
        }
        Close();
        ManagerRoot.TempSceneManager.LoadStageScene(stageNumber);
    }

    public void GoToMainButton()
    {
        Close();
        ManagerRoot.TempSceneManager.LoadMainScene();
    }
    #endregion
}
