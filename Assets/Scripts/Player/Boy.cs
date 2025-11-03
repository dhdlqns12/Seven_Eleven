using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class Boy : PlayerController
    {

        public override void HandleAction()
        {
            float horizontalInput = 0f;
            float verticalInput = 0f;

            jumpRequsted = false;


            if (isGrounded == true && Input.GetKey(KeyCode.W))
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

            movementDirection = new Vector2(horizontalInput, verticalInput).normalized;

        }

        private IEnumerator OnTriggerEnter2D(Collider2D _other) //장애물들과 충돌처리 코드 완료. 테스트 필요
        {
            if (_other.CompareTag("RedWater"))
            {
                ManagerRoot.GameManager.IsDie = true;
                Dead();
                yield return new WaitForSeconds(2f);
                ManagerRoot.GameManager.GameOver();
                Debug.Log("용암에 닿았습니다.");
            }

            if(_other.CompareTag("Flag_blue"))
            {
                ManagerRoot.GameManager.IsClear_2 = true;
                Debug.Log(ManagerRoot.GameManager.IsClear_2);
            }

            if (_other.CompareTag("Star"))
            {
                _other.gameObject.SetActive(false);

                string CurrentSceneName = SceneManager.GetActiveScene().name;
                ManagerRoot.GameManager.AddStar(CurrentSceneName);
            }



        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Flag_blue"))
            {
                ManagerRoot.GameManager.IsClear_2 = false;
                Debug.Log(ManagerRoot.GameManager.IsClear_2);
            }
        }

    }
}
