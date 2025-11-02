using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerRoot : Singleton<ManagerRoot>
{
    [Header("직접 참조")]
    [SerializeField] private GameManager gameManager;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private SceneController sceneController;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private SwitchManager switchManager;

    public static GameManager GameManager { get; private set; }
    public static UIManager UIManager { get; private set; }
    public static SceneController SceneController { get; private set; }
    public static AudioManager AudioManager { get; private set; }
    public static SwitchManager SwitchManager { get; private set; }

    protected override void Init()
    {
        GameManager = gameManager;
        UIManager = uiManager;
        SceneController = sceneController;
        AudioManager = audioManager;
        SwitchManager= switchManager;
    }
}
