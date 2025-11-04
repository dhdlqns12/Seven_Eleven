using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueFlag : MonoBehaviour
{
    [SerializeField] private Animator blueFlagAnimation;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player_Water"))
        {
            blueFlagAnimation.SetBool("enter_blue", true);
        }
    }



    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player_Water"))
        {
            blueFlagAnimation.SetBool("enter_blue", false);
        }

    }
}
