using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isDie = false;
    public bool isCollisionObstacle = false;

    
    //isdDie==true일 때 실패 UI 뜨는거 작성 부탁드려용
    public void GameOver()
    {
        ManagerRoot.UIManager.ShowPanel<StageFailUI>();
        Time.timeScale = 0f;
    }

    /// <summary>
    /// ///////////////////////이 내에서만 만지작하기
    /// </summary>

   

    public Dictionary<string, int> stageStars = new Dictionary<string, int>();
   

    void Awake()
    {
        stageStars["Stage1"] = 0;
        stageStars["Stage2"] = 0;
        stageStars["Stage3"] = 0;
        stageStars["Stage4"] = 0;
        stageStars["Stage5"] = 0;

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


    /// <summary>
    /// //////////////////////////////////////////////////////////////////////////
    /// </summary>

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
}
