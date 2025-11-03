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

        private void OnTriggerEnter2D(Collider2D other) //장애물들과 충돌처리 코드 완료. 테스트 필요
        {
            if (other.CompareTag("Water"))
            {
                Dead();
                ManagerRoot.GameManager.IsDie = true;
                Debug.Log("파도에 충돌했습니다.");
            }

            if (other.CompareTag("Ice"))
            {
                other.gameObject.SetActive(false);
            }

            if(other.CompareTag("Flag_red"))
            {
                ManagerRoot.GameManager.IsClear_1 = true;
                Debug.Log(ManagerRoot.GameManager.IsClear_1);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if(other.CompareTag("Flag_red"))
            {
                ManagerRoot.GameManager.IsClear_1 = false;
                Debug.Log(ManagerRoot.GameManager.IsClear_1);
            }
        }
    }

}
