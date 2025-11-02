using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stem : FlowerController
{
    private void OnTriggerEnter2D(Collider2D _other) //장애물들과 충돌처리 코드 완료. 테스트 필요
    {

        if (_other.CompareTag("Player_Fire"))
        {
            IsBloom(false);//public으로 풀면 프리팹 쓸 때 꼬이니까 상태 바꾸는 매서드로 활용
            Debug.Log("시듦");
        }


        if (_other.CompareTag("Player_Water"))
        {
            IsBloom(true);
            Debug.Log("만개");
        }

    }
}
