using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerRoot : Singleton<ManagerRoot>
{
    [Header("직접 참조")]//인스펙터랑 인스턴스를 연결한거
    [SerializeField] private GameManager gameManager;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private SceneController sceneController;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private SwitchManager switchManager;

    public static GameManager GameManager { get; private set; }//프로퍼티를 활용한 static선언
    public static UIManager UIManager { get; private set; }
    public static SceneController SceneController { get; private set; }
    public static AudioManager AudioManager { get; private set; }

    public static SwitchManager SwitchManager { get; private set; }

    protected override void Init()//싱글톤 안에 virtual 메서드가 없는데 이건 왜 있는거??
    {
        GameManager = gameManager;//static선언한 변수에 인스펙터에 연결된 인스턴스를 대입
        UIManager = uiManager;
        SceneController = sceneController;
        AudioManager = audioManager;
        SwitchManager = switchManager;
    }
}
