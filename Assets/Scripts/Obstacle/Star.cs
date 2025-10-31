using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Star : MonoBehaviour
{
    bool isGetStar=false;
    public static int StarGetcount = 0;
    
    private void OnTriggerEnter2D(Collider2D _player)
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
        }

        
    }


}
