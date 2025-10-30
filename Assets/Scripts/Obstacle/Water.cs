using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
        private void OnTriggerEnter2D(Collider2D _player)
        {
            if (_player.CompareTag("Fire"))
            {
                GameManager.Instance.isDie = true;
                Debug.Log("물에 빠져 죽었습니다.");
            }
        }
}
