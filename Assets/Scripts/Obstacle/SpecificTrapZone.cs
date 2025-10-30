using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpecificTrapZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D _player)
    {
        if (_player.CompareTag("Fire")|| _player.CompareTag("Water"))
        {
            ManagerRoot.GameManager.isCollisionObstacle = true;

            //물이 용암 충돌=>사망
            //불이 물 충돌=>사망
            //물이 얼음 충돌=>느려짐 collision.getcomponent<스크립트이름>
            //불이 얼음 충돌=>빨라짐
            //물이 식물 충돌=> 식물이 자라나는 애니메이션+밟고 있던 바닥이 발판이 되서 위로 이동함
            //엘레베이터를 작동시킴>>이중딕셔너리 
            //물,불,박스는 스위치를 누를 수 있음 

            

        }
    }

    private void OnTriggerExit2D(Collider2D _player)
    {
        if (_player.CompareTag("Player"))
        {

            //스위치를 충돌영역을 벗어나면 스위치가 다시 원위치로 올라감

            ManagerRoot.GameManager.isCollisionObstacle = false;
        }
    }
}
