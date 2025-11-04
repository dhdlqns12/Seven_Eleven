using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedFlag : MonoBehaviour
{
    [SerializeField] private Animator redFlagAnimation;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player_Fire"))
        {
            redFlagAnimation.SetBool("enter_red", true);
        }
    }



    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player_Fire"))
        {
            redFlagAnimation.SetBool("enter_red", false);
        }

    }
}
