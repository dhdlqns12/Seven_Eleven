using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedWater : MonoBehaviour
{
        private void OnTriggerEnter2D(Collider2D _player)
        {
            if (_player.CompareTag("Water"))
            {
                GameManager.Instance.isDie = true;
                Debug.Log("용암에 빠져 죽었습니다.");
            }
        }
}
