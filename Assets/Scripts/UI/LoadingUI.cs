using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingUI : UIBase
{
    [SerializeField] private GameObject loadingAVersion;
    [SerializeField] private GameObject loadingBVersion;

    [SerializeField] private Slider loadingSlider;
    [SerializeField] private Image fillArea; // 슬라이더의 Fill Area 이미지
    [SerializeField] private TextMeshProUGUI loadingSliderText; // 진행도 텍스트 (선택사항)

    protected override void SetupUI()
    {
        if (loadingSlider != null)
        {
            loadingSlider.value = 0f;
        }
    }

    protected override void OnShow()
    {
        SetLoidingScreen(SceneController.CurrentLoadingStage);

        if (loadingSlider != null)
        {
            loadingSlider.value = 0f;
        }
    }

    #region 로딩 스크린
    public void UpdateProgress(float progress)
    {
        if (loadingSlider != null)
        {
            loadingSlider.value = progress;
        }

        if (loadingSliderText != null)
        {
            loadingSliderText.text = $"{Mathf.RoundToInt(progress * 100)}%";
        }
    }

    private void SetLoidingScreen(int stageNumber)
    {
        loadingAVersion.SetActive(false);
        loadingBVersion.SetActive(false);

        if (stageNumber == 1)
        {
            // 1스테이지는 랜덤
            bool useA = Random.Range(0, 2) == 0;
            loadingAVersion.SetActive(useA);
            loadingBVersion.SetActive(!useA);
        }
        else if (stageNumber == 2 || stageNumber == 3)
        {
            // 2, 3스테이지는 A버전
            loadingAVersion.SetActive(true);
        }
        else if (stageNumber == 4 || stageNumber == 5)
        {
            // 4, 5스테이지는 B버전
            loadingBVersion.SetActive(true);
        }
        else
        {
            loadingAVersion.SetActive(true);
        }
    }
    #endregion

    #region 이벤트 구독/해제
    protected override void SubscribeEvents()
    {

    }

    protected override void UnsubscribeEvents()
    {

    }
    #endregion
}
