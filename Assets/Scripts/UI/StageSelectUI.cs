using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class StageSelectUI : UIBase
{
    [Header("UI")]
    [SerializeField] private Button goToMain_Btn;

    [Header("스테이지 선택 버튼")]
    [SerializeField] private Button[] stageSelect_Btn;//인덱스는 0,1,2,3,4

    [Header("점수")]
    [SerializeField] private Sprite[] scores;//인덱스는 0,1,2,3
    [SerializeField] private Image[] currentScores;//인덱스는 0,1,2,3,4

    private string[] stageNames = { "Stage 01", "Stage 02", "Stage 03", "Stage 04", "Stage 05" };

    [Header("효과음")]
    [SerializeField] private AudioClip clickbtn;

    protected override void SetupUI()
    {
        
    }

    private void Start()
    {
        Show();
    }

    #region 스테이지 버튼 업데이트
    protected override void OnShow()
    {
        UpdateStageButtons();
        GetScore();
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

    public void GetScore()
    {
        // 배열 체크
        if (scores == null || scores.Length == 0)
        {
            Debug.LogWarning("Scores 배열이 비어있습니다!");
            return;
        }

        if (currentScores == null || currentScores.Length == 0)
        {
            Debug.LogWarning("CurrentScores 배열이 비어있습니다!");
            return;
        }

        for (int i = 0; i < stageNames.Length; i++)
        {
            if (i >= currentScores.Length)
            {
                break;
            }

            if (ManagerRoot.GameManager.stageStars[stageNames[i]] == 0)
            {
                currentScores[i].sprite = scores[0];
            }
            else if (ManagerRoot.GameManager.stageStars[stageNames[i]] == 1)
            {
                currentScores[i].sprite = scores[1];
            }
            else if (ManagerRoot.GameManager.stageStars[stageNames[i]] == 2)
            {
                currentScores[i].sprite = scores[2];
            }
            else if (ManagerRoot.GameManager.stageStars[stageNames[i]] == 3)
            {
                currentScores[i].sprite = scores[3];
            }
        }
    }


    private bool IsStageUnlocked(int _stageNumber)
    {
        if (_stageNumber == 1) return true;

        int previousStage = _stageNumber - 1;
        string key = $"Stage_{previousStage}_Cleared";
        int value = PlayerPrefs.GetInt(key, 0);

        Debug.Log($"스테이지 {_stageNumber} 확인: {key} = {value}");

        return value == 1;
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
    private void OnStageButtonClicked(int _stageNumber)
    {
        if (!IsStageUnlocked(_stageNumber))
        {
            return;
        }
        Close();
        ManagerRoot.SceneController.LoadStageScene(_stageNumber);
        ManagerRoot.AudioManager.PlaySfx(clickbtn);
    }

    public void GoToMainButton()
    {
        Close();
        ManagerRoot.SceneController.LoadMainScene();
        ManagerRoot.AudioManager.PlaySfx(clickbtn);
    }
    #endregion
}
