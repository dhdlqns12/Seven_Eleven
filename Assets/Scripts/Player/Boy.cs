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

        private void OnTriggerEnter2D(Collider2D Object) //장애물들과 충돌처리 코드 완료. 테스트 필요
        {
            if (Object.CompareTag("RedWater"))
            {
                ManagerRoot.GameManager.isDie = true;
                Debug.Log("용암에 충돌했습니다.");
            }
        }


    }

}
