using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class IntroUI : UIBase
{
    [Header("인트로 이미지")]
    [SerializeField] private Image titleImage;
    [SerializeField] private Image logoImage;

    [Header("페이드 설정")]
    [SerializeField] private float fadeDuration = 1.5f;

    protected override void SetupUI()
    {
        
    }

    protected override void SubscribeEvents()
    {
        
    }

    protected override void UnsubscribeEvents()
    {

    }

    public override void Show()
    {
        base.Show();
        StartCoroutine(PlayIntroFadeImage(fadeDuration, titleImage, logoImage));
    }

    private IEnumerator PlayIntroFadeImage(float t, Image i, Image j)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        j.color = new Color(j.color.r, j.color.g, j.color.b, 0);

        // Title 페이드 인
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);

        // Title 페이드 아웃
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }

        // Logo 페이드 인
        while (j.color.a < 1.0f)
        {
            j.color = new Color(j.color.r, j.color.g, j.color.b, j.color.a + (Time.deltaTime / t));
            yield return null;
        }
        j.color = new Color(j.color.r, j.color.g, j.color.b, 1);

        // Logo 페이드 아웃
        while (j.color.a > 0.0f)
        {
            j.color = new Color(j.color.r, j.color.g, j.color.b, j.color.a - (Time.deltaTime / t));
            yield return null;
        }

        Close();
        ManagerRoot.TempSceneManager.LoadMainScene();

    }
}
