using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    bool playerInRange=false; //매니저 추가 시 수정

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;//Player 추가되면 수정 MainGameManager.Instance.
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;//Player 추가되면 수정 MainGameManager.Instance.playerInRange
        }
    }
}
