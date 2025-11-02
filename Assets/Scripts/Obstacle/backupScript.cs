using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class StarManager : MonoBehaviour//게임매니저에 들어갈 내용 백업용 스크립트
{

    /// <summary>
    /// ///////////////////////이 내에서만 만지작하기
    /// </summary>


    Dictionary<string, int> stageStars = new Dictionary<string, int>();

    void Awake()
    {
        stageStars["Stage1"] = 0;
        stageStars["Stage2"] = 0;
        stageStars["Stage3"] = 0;
        stageStars["Stage4"] = 0;
        stageStars["Stage5"] = 0;
    }


    public void AddStar(string _stageName, int _starCount = 1)//별과 충돌할 때마다 플레이어 스크립트에서 호출
                                                              //RootManager.GameManager.AddStar()
    {

        if (stageStars.ContainsKey(_stageName))// 해당 스테이지가 존재하면
        {
            if (stageStars[_stageName] > 3)
            {
                stageStars[_stageName] = 3;//점수가 3을 넘지않도록 제한
            }
            else
            {
                stageStars[_stageName] += _starCount;
            }

            PlayerPrefs.SetInt(_stageName, stageStars[_stageName]);
            PlayerPrefs.Save(); // 저장 확정
        }

    }


    /// <summary>
    /// //////////////////////////////////////////////////////////////////////////
    /// </summary>
}

public class RedWater : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D _player)
    {
        if (_player.CompareTag("Water"))
        {
            ManagerRoot.GameManager.isDie = true;
            Debug.Log("용암에 빠져 죽었습니다.");
        }
    }
}

//public class Water : MonoBehaviour
//{
//    private void OnTriggerEnter2D(Collider2D o)
//    {
//        //if (o.CompareTag("Fire"))
//        //{
//        //    ManagerRoot.GameManager.isDie = true;
//        //    Debug.Log("물에 빠져 죽었습니다.");
//        //}


//        if (o.CompareTag("Ice"))
//        {
//            speed = 5f;
//        }
//    }
//        private void OnTriggerExit2D(Collider2D o)
//        {
//            if(o.CompareTag("Ice"))
//            {
//                speed = 8f;
//            }
//        }
    
//}


