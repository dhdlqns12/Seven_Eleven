using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Player
{
    public class Girl : PlayerController
    {
        public override void HandleAction()
        {
            float horizontalInput = 0f; //수평이동
            float verticalInput = 0f; //수직이동 (Y축)

            jumpRequsted = false;
            
            if (isGrounded==true && Input.GetKey(KeyCode.UpArrow))
            {
                jumpRequsted = true;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                horizontalInput = -1f;
                spriteRenderer.flipX = true;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                horizontalInput = 1f;
                spriteRenderer.flipX = false;
            }
            
            movementDirection = new Vector2(horizontalInput, verticalInput).normalized; 
        }
    }

}
