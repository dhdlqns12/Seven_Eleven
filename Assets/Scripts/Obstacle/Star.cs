using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using UnityEngine;

public class Star : MonoBehaviour
{
    bool isGetStar=false;


    static int StarGetcount;//추후 수정




    private void OnTriggerEnter2D(Collider2D _player)//플레이어기준으로 붙을 예정
    {
        if (_player.CompareTag("Water")|| _player.CompareTag("Fire"))
        {
            
            isGetStar = true;
            gameObject.SetActive(false);
            StarGetcount+=1;
            PlayerPrefs.SetInt("GetStarSave", StarGetcount);
            PlayerPrefs.Save();


            int starDebug=PlayerPrefs.GetInt("GetStarSave");
            Debug.Log($"별 {starDebug}개 획득!");
            //starDebug는 나중에 게임매니저에 선언하고 불러오고 하는거 작성하기
            //스테이지 해금하고나
        }


    }


}
