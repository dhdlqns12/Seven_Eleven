using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class temp_SceneManager : MonoBehaviour
{
    public void LoadScene(string SceneName) // 씬 전환 전 공통 작업 처리
    {
        SceneManager.LoadScene(SceneName);
    }

    // 로딩 비동기 처리
    //private IEnumerator LoadSceneAsync(string sceneName)
    //{
    //    ManagerRoot.UIManager.ShowPanel<LoadingUI>();

    //    yield return new WaitForSeconds(0.5F);

    //    AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

    //    while(!asyncLoad.isDone)
    //    {
    //        float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);

    //        yield return null;
    //    }

    //    ManagerRoot.UIManager.ClosePanel<LoadingUI>();
    //}

    public void LoadStageSelectScene()
    {
        LoadScene("StageSelect");
    }

    public void RestartScene()
    {
        Scene curScene = SceneManager.GetActiveScene();
        LoadScene(curScene.name);
    }
}
