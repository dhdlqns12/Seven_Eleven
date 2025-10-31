using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Player
{
    public class Girl : PlayerController
    {
        public override void HandleAction()
        {
            float horizontalInput = 0f;
            float verticalInput = 0f;

            jumpRequsted = false;
            
            if (Input.GetKey(KeyCode.UpArrow))
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
            
            movementDirection = new Vector2(horizontalInput, verticalInput).normalized; //0의 숫자를 변경하면 y값도 들어감! 하지만 추후에 점프를 넣을때 수정할 것
            //normalized는 방향을 구하는 기능이다! 
        }
    }

}
