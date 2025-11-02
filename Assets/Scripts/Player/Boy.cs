using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Boy : PlayerController
    {
        public override void HandleAction()
        {
            float horizontalInput = 0f;
            float verticalInput = 0f;
            
            jumpRequsted = false;
            
            if (isGrounded==true && Input.GetKey(KeyCode.W))
            {
                jumpRequsted = true;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                horizontalInput = -1f;
                spriteRenderer.flipX = true;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                horizontalInput = 1f;
                spriteRenderer.flipX = false;
            }
            
            movementDirection=new Vector2(horizontalInput, verticalInput).normalized;
            
        }
    }

}
