using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum UIType
{
    Scene,
    Popup
}

public abstract class UIBase : MonoBehaviour
{
    [Header("UI 설정")]
    [SerializeField] protected UIType uiType;

    public UIType UIType => uiType;
    protected bool isInit = false;

    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void OnDisable()
    {
        UnsubscribeEvents();
    }

    public virtual void Init()  // 초기화
    {
        if (isInit)
        {
            return;
        }

        SetupUI();
        isInit = true;
    }

    protected abstract void SetupUI(); // 각 패널에서 UI요소 설정,초기 텍스트나, 초기 상태 설정
    protected abstract void SubscribeEvents(); // 각 패널의 버튼 이벤트 또는 이벤트 구독
    protected abstract void UnsubscribeEvents(); // 각 패널의 버튼 이벤트 또는 이벤트 구독 해제

    public virtual void Show()
    {
        gameObject.SetActive(true);
        OnShow();
    }

    public virtual void Close()
    {
        gameObject.SetActive(false);
        OnClose();
    }

    protected virtual void OnShow() // 각 패널에서 Show시 추가 로직
    {

    }

    protected virtual void OnClose() // 각 패널에서 Close시 추가 로직
    {

    }
}
