using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.EditorTools;
using UnityEngine;

public class ManagerRoot : Singleton<ManagerRoot>
{
    [Header("직접 참조")]
    [SerializeField] private GameManager gameManager;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private temp_SceneManager tempSceneManager;

    public static GameManager GameManager { get; private set; }
    public static UIManager UIManager { get; private set; }
    public static temp_SceneManager TempSceneManager { get; private set; }

    protected override void Init()
    {
        GameManager = gameManager;
        UIManager = uiManager;
        TempSceneManager = tempSceneManager;
    }
}
