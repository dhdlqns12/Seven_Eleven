using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    public bool isDie = false;
    public bool isCollisionObstacle = false;

    public void Awake()
    {
        if(Instance == null)
            Instance = this;

        else
            Destroy(Instance);
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    //idDie==true일 때 실패 UI 뜨는거 작성 부탁드려용
    







}
