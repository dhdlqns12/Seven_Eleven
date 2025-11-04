using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stem : FlowerController
{
   

    private void OnTriggerEnter2D(Collider2D _other) //장애물 충돌처리 구현
    {

        if (_other.CompareTag("Player_Fire"))
        {
            flowerGround.SetActive(false);
            Debug.Log("꽃이 작아집니다.");
        }


        if (_other.CompareTag("Player_Water"))
        {
            flowerGround.SetActive(true);
            Debug.Log("꽃이 피었습니다");
        }

    }

    private void update()
    {
        updategroundposition(); // 실시간으로 갱신
    }

    private void updategroundposition()//줄기 끝에 박스 붙이기
    {
        vector3 endpos = transform.position + transform.up * stemlength;//줄기 끝까지
        flowerground.transform.position = endpos;
    }
}

