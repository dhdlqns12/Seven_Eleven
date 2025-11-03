using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isDie;
    public bool isCollisionObstacle = false;
    private bool isClear_1;  //소녀가 깃발에 닿았을 때
    private bool isClear_2;  //소년이 깃발에 닿았을 때 isClear_1,2가 모두 true여야 스테이지 클리어
    public bool isEnter=false;
   
    public bool IsClear_1
    {
        get => isClear_1;
        set
        {
            isClear_1 = value;
            CheckStageClear();
        }
    }

    public bool IsClear_2
    {
        get => isClear_2;
        set
        {
            isClear_2 = value;
            CheckStageClear();
        }
    }

    public bool IsDie
    {
        get => isDie;
        set
        {
            if (value && !isDie)
            {
                isDie = value;
                GameOver();
            }
        }
    }

    private void OnDisable()
    {
        ResetStageFlags();
    }

    private void ResetStageFlags()
    {
        isClear_1 = false;
        isClear_2 = false;
        isDie = false;
    }


    public Dictionary<string, int> stageStars = new Dictionary<string, int>();

    string[] stageNames = { "Stage 01", "Stage 02", "Stage 03", "Stage 04", "Stage 05" };
    string stageKey;


    private void SetScore()
    {
        for (int i = 0; i < stageNames.Length; i++)
        {
            stageKey = stageNames[i];
            int savedValue = PlayerPrefs.GetInt(stageKey, 0);

            if (stageStars.ContainsKey(stageKey))
            {
                stageStars[stageKey] = savedValue;
            }
            else
            {
                stageStars.Add(stageKey, savedValue);
            }
        }
    }

    void Awake()
    {
        SetScore();
        LoadResolution(); //해상도 설정
    }


    public void AddStar(string _stageName, int _starCount = 1)//별과 충돌할 때마다 플레이어 스크립트에서 호출
                                                              //RootManager.GameManager.AddStar()
    {

        if (stageStars.ContainsKey(_stageName))// 해당 스테이지가 존재하면
        {
            if (stageStars[_stageName] > 3)
            {
                stageStars[_stageName] = 3;//점수가 3을 넘지않도록 제한
            }
            else
            {
                stageStars[_stageName] += _starCount;

            }


            PlayerPrefs.SetInt(_stageName, stageStars[_stageName]);
            PlayerPrefs.Save(); // 저장 확정
        }

    }

    #region 해상도 설정
    private void LoadResolution()
    {
        //PlayerPrefs에서 불러와서 Screen.SetResolution() 호출
        int width = PlayerPrefs.GetInt("ResolutionWidth", Screen.width);
        int height = PlayerPrefs.GetInt("ResolutionHeight", Screen.height);
        FullScreenMode mode = (FullScreenMode)PlayerPrefs.GetInt("FullScreenMode", (int)FullScreenMode.Windowed);

        Screen.SetResolution(width, height, mode);
    }

    public void SetResolution(int width, int height, FullScreenMode mode)
    {
        Screen.SetResolution(width, height, mode);

        PlayerPrefs.SetInt("ResolutionWidth", width);
        PlayerPrefs.SetInt("ResolutionHeight", height);
        PlayerPrefs.SetInt("FullScreenMode", (int)mode);
        PlayerPrefs.Save();
    }
    #endregion

    #region 스테이지 클리어, 죽음
    private void CheckStageClear()
    {
        // 둘 다 true면
        if (isClear_1 && isClear_2)
        {
            Debug.Log("스테이지 클리어!");
            StageClear();
            SetScore();
        }
    }

    private void StageClear()
    {
        ManagerRoot.UIManager.ShowPanel<StageClearUI>();
        Time.timeScale = 0f;

        // 현재 스테이지 클리어 저장
        string currentSceneName = SceneManager.GetActiveScene().name;
        int stageNumber = GetStageNumber(currentSceneName);

        if (stageNumber > 0)
        {
            PlayerPrefs.SetInt($"Stage_{stageNumber}_Cleared", 1);
            PlayerPrefs.Save();
            Debug.Log($"Stage {stageNumber} 클리어 저장 완료");
        }
        
        StageSelectUI stageSelectUI = ManagerRoot.UIManager.GetPanel<StageSelectUI>();
        stageSelectUI.GetScore();

        isClear_1 = false;
        isClear_2 = false;
    }




    private int GetStageNumber(string sceneName)
    {
        if (sceneName.Length >= 8 && sceneName.StartsWith("Stage "))
        {
            ReadOnlySpan<char> numberPart = sceneName.AsSpan(6);
            if (int.TryParse(numberPart, out int number))
            {
                return number;
            }
        }
        return 0;
    }

    public void GameOver()
    {
        ManagerRoot.UIManager.ShowPanel<StageFailUI>();
        Time.timeScale = 0f;

        isDie = false;
    }
    #endregion
}
