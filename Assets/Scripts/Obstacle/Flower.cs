using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{

    bool Fullflower=false;

    private void OnTriggerEnter2D(Collider2D _player)
    {
        if (_player.CompareTag("Water"))
        {
            Fullflower = true;
            Debug.Log("꽃 발판 위로.");
        }

        if (_player.CompareTag("Fire"))
        {
            Fullflower = false;
            Debug.Log("꽃 발판 원위치.");
        }
    }




    //꽃의 Y축 변화는 최상위오브젝트로, 그리고 줄기부분의 스케일 y값과 포지션 y값을 수정 


    //발판 오브젝트를 켜기
    //애니메이션 파라미터 1(활성화상태)로 변경


    //발판 오브젝트를 끄기//SetActive
    //발판 오브젝트 y축--//변화량 넣기만 하면 되는 식으로 변경? 원래 위치로 변경?
    //애니메이션 파라미터 0(비활성화)으로 변경



}
