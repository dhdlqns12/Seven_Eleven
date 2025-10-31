using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour  //UI매니저는 UI패널을 관리하는 역활
{
    [Header("Canvas")]
    [SerializeField] private Canvas sceneCanvas;
    [SerializeField] private Canvas popupCanvas;

    [Header("UI 프리팹")]
    [SerializeField] private List<UIBase> uiPrefabLists;

    private Dictionary<string, UIBase> uiPanels = new Dictionary<string, UIBase>();

    private UIBase currentPanel;  // 현재 활성화된 패널 추적

    private void Awake()
    {
        InstantiatePrefabs();
        InitPanels();
    }

    private void InstantiatePrefabs()
    {
        foreach (var prefab in uiPrefabLists)
        {
            Canvas targetCanvas = GetTargetCanvas(prefab.UIType);

            if (targetCanvas != null)
            {
                UIBase instance = Instantiate(prefab, targetCanvas.transform);
                instance.name = prefab.name;
                uiPanels[instance.GetType().Name] = instance;
            }
        }
    }

    private Canvas GetTargetCanvas(UIType _uiType)
    {
        switch (_uiType)
        {
            case UIType.Scene:
                return sceneCanvas;
            case UIType.Popup:
                return popupCanvas;
            default:
                return sceneCanvas;
        }
    }

    private void InitPanels()
    {
        foreach (var panel in uiPanels.Values)
        {
            panel.Init();
            panel.gameObject.SetActive(false);
        }
    }

    public T GetPanel<T>() where T : UIBase
    {
        if (uiPanels.TryGetValue(typeof(T).Name, out UIBase panel))
        {
            return panel as T;
        }

        Debug.LogWarning($"패널 찾을 수 없음: {typeof(T).Name}");
        return null;
    }

    public void ShowPanel<T>() where T : UIBase
    {
        UIBase panel = GetPanel<T>();

        if (panel.UIType == UIType.Scene)
        {
            if (currentPanel != null && currentPanel != panel)
            {
                currentPanel.Close();
            }
            currentPanel = panel;
        }

        panel.Show();
    }

    public void ClosePanel<T>() where T : UIBase
    {
        UIBase panel = GetPanel<T>();

        panel.Close();

        if (currentPanel == panel)
        {
            currentPanel = null;
        }
    }

    public void CloseAllPanels()
    {
        foreach (var panel in uiPanels.Values)
        {
            panel.Close();
        }
        currentPanel = null;
    }

    public bool IsShowing<T>() where T : UIBase //패널이 현재활성화 상태인지 체크용도
    {
        UIBase panel = GetPanel<T>();
        return panel != null && panel.gameObject.activeSelf;
    }
}
