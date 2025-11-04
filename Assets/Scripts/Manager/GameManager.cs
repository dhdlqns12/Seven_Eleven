using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isDie;
    public bool isCollisionObstacle = false;
    private bool isClear_1;  //소녀가 깃발에 닿았을 때
    private bool isClear_2;  //소년이 깃발에 닿았을 때 isClear_1,2가 모두 true여야 스테이지 클리어
    public bool isEnter=false;
    
    [Header("효과음")]
    [SerializeField] private AudioClip dieSound;
    [SerializeField] private AudioClip clearSound;

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
            }
            else if (!value)
            {
                isDie = value;
            }
        }
    }

    public void Dead()
    {
       IsDie = true;
    }

    private void Start()
    {
        currentStageStars = 0;
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

    private string[] stageNames = { "Stage 01", "Stage 02", "Stage 03", "Stage 04", "Stage 05" };
    public int currentStageStars;

    private void SetScore()
    {
        for (int i = 0; i < stageNames.Length; i++)
        {
            string stageKey = stageNames[i];
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


    public void AddStar()//별과 충돌할 때마다 플레이어 스크립트에서 호출
                                                              //RootManager.GameManager.AddStar()
    {
        currentStageStars++;
        Debug.Log($"현재 별 개수: {currentStageStars}");
    }

    private void OnStageFailed()
    {
        currentStageStars = 0;
        Debug.Log("스테이지 실패 - 별 점수 저장 안 함");
    }

    private void SaveStageStars(string stageName)
    {
        if (stageStars.ContainsKey(stageName))
        {
            int savedStars = stageStars[stageName];

            if (currentStageStars > savedStars)
            {
                stageStars[stageName] = currentStageStars;
                PlayerPrefs.SetInt(stageName, currentStageStars);
                PlayerPrefs.Save();
                Debug.Log($"{stageName} 별 점수 업데이트: {currentStageStars}개");
            }
            else
            {
                Debug.Log($"{stageName} 별 점수 유지: {savedStars}개 (현재: {currentStageStars}개)");
            }
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
        ManagerRoot.AudioManager.PlaySfx(clearSound);
        ManagerRoot.UIManager.ShowPanel<StageClearUI>();
        Time.timeScale = 0f;

        string currentSceneName = SceneManager.GetActiveScene().name;
        int stageNumber = GetStageNumber(currentSceneName);

        SaveStageStars(currentSceneName);

        if (stageNumber > 0)
        {
            string key = $"Stage_{stageNumber}_Cleared";
            PlayerPrefs.SetInt(key, 1);
            PlayerPrefs.Save();
            Debug.Log($"저장 완료: {key} = 1");
        }

        StageSelectUI stageSelectUI = ManagerRoot.UIManager.GetPanel<StageSelectUI>();
        if (stageSelectUI != null)
        {
            stageSelectUI.GetScore();
        }

        // StageClearUI 별 표시 업데이트
        StageClearUI stageClearUI = ManagerRoot.UIManager.GetPanel<StageClearUI>();
        if (stageClearUI != null)
        {
            stageClearUI.UpdateStars(currentStageStars);
        }

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
        ManagerRoot.AudioManager.PlaySfx(dieSound);

        OnStageFailed();

        ManagerRoot.UIManager.ShowPanel<StageFailUI>();
        Time.timeScale = 0f;

        isDie = false;
    }
    #endregion
}
