using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //MainGameManager.Instance.playerInRange = true;//Player 추가되면 수정
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //MainGameManager.Instance.playerInRange = false;//Player 추가되면 수정
        }
    }
}
