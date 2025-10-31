using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isDie = false;
    public bool isCollisionObstacle = false;

    
    //isdDie==true일 때 실패 UI 뜨는거 작성 부탁드려용
    public void GameOVer()
    {
        ManagerRoot.UIManager.ShowPanel<StageFailUI>();
        Time.timeScale = 0f;
    }
}
