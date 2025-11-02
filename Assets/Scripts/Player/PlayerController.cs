using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Player
{
    //리지드바디를 통해 이동을 이제 시켜줘야한다
    public abstract class PlayerController : MonoBehaviour
    {
        [SerializeField] protected float speed = 8f;
        [SerializeField] protected float jumpForce = 3f;
        
        public Vector2 movementDirection;
        
        [SerializeField] Rigidbody2D rb;
        
        [SerializeField] protected SpriteRenderer spriteRenderer;
        protected bool jumpRequsted = false;
        protected bool isGrounded = false;  //질문 1. 이 줄 public으로 써도 되나요? 안된다면 protected가 좀 더 보안이 좋기 때문일까요?
                                            //답변 : 가능은 하지만, 캡슐화와 은닉화 위해서 protected가 더 좋습니다.
        void Update() 
        {
            HandleAction();
            Color rayColor = isGrounded ? Color.green : Color.red;
            
            Debug.DrawRay(transform.position, new Vector2(0,0.5f), rayColor);
        }

        void FixedUpdate() //물리효과(rigidbody)가 적용된 오브젝트를 조정할 때
        {
            Move();
            Jump();
        }
        private void Move() //이 안에서 리지드바디 이용해서 구현해야함
        {
            rb.velocity=new Vector2(movementDirection.x * speed, rb.velocity.y); //이동 = 방향 * 속도
        }
        
        private void OnTriggerEnter2D(Collider2D Object) //장애물들과 충돌처리 코드 완료. 테스트 필요
        {
           
            

            //(채윤님 Star완성되시면 이 주석 지우시면 됩니다!
            //if (Object.CompareTag("Star"))
            //{
            //   ManagerRoot.GameManager.AddStar("Stage 01", 1);
            //}
        }
        
        protected void Jump() 
        {
            isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.5f, LayerMask.GetMask("Ground"));
           // Debug.Log($"jumpRequsted: {jumpRequsted}, isGrounded: {isGrounded}");
            
            if (jumpRequsted)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpRequsted = false;
            }
        }
        public abstract void HandleAction();
    }
    
    
}

