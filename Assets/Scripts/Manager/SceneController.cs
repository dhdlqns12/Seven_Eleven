using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static int CurrentLoadingStage { get; private set; }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoded;
    }

    private void OnSceneLoded(Scene _scene, LoadSceneMode _mode)
    {
        CurrentLoadingStage = -1;

        if (_scene.name== "StageSelect")
        {
            ManagerRoot.UIManager.ShowPanel<StageSelectUI>();
        }
        else if(_scene.name== "Main_Title")
        {
            ManagerRoot.UIManager.ShowPanel<MainTitleUI>();
        }
        else if(_scene.name== "Intro")
        {
            ManagerRoot.UIManager.ShowPanel<IntroUI>();
        }
        else if (_scene.name.StartsWith("Stage "))
        {
            ManagerRoot.UIManager.ShowPanel<StageOptionUI>();
            ManagerRoot.GameManager.currentStageStars = 0;
            ManagerRoot.GameManager.IsDie = false;
        }
    }

    public void LoadScene(string _sceneName) // 씬 전환 전 공통 작업 처리
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void LoadSceneAsync(string _sceneName) // 비동기 씬 로딩
    {
        StartCoroutine(LoadSceneAsyncCoroutine(_sceneName));
    }

    // 로딩 비동기 처리
    private IEnumerator LoadSceneAsyncCoroutine(string _sceneName)
    {
        ManagerRoot.UIManager.ShowPanel<LoadingUI>();
        LoadingUI loadingUI = ManagerRoot.UIManager.GetPanel<LoadingUI>();

        yield return new WaitForSeconds(0.5F);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_sceneName);

        while (!asyncLoad.isDone)
        {
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);

            if (loadingUI != null)
            {
                loadingUI.UpdateProgress(progress);
            }

            yield return null;
        }
        ManagerRoot.UIManager.ClosePanel<LoadingUI>();
    }

    public void LoadStageSelectScene()
    {
        LoadScene("StageSelect");
    }

    public void RestartScene()
    {
        Scene curScene = SceneManager.GetActiveScene();
        LoadScene(curScene.name);
    }

    public void LoadStageScene(int _stageNumber)
    {
        CurrentLoadingStage = _stageNumber;
        string sceneName = $"Stage {_stageNumber:D2}";
        LoadSceneAsync(sceneName);
    }

    public void LoadMainScene()
    {
        LoadScene("Main_Title");
    }
}
