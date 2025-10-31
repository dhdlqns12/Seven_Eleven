using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Player
{
    //리지드바디를 통해 이동을 이제 시켜줘야한다
    public abstract class PlayerController : MonoBehaviour
    {
        public float speed = 8f;

        [SerializeField] 
        protected float jumpForce = 3f;
        
        public Vector2 movementDirection;
        
        [SerializeField]
        Rigidbody2D rb;
        
        [SerializeField]
        protected SpriteRenderer spriteRenderer;
        protected bool jumpRequsted = false;
        private bool isGrounded = false;
        
        void Update()
        {
            HandleAction();
        }

        void FixedUpdate()
        {
            Move();
            Jump();
        }
        public void Move()
        {
            //이 안에서 리지드바디를 이용해서 움직임을 구현해야함
            rb.AddForce(movementDirection * speed); //이동 = 방향 * 속도
            
        }

        public void Jump()
        {
            isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 1f, LayerMask.GetMask("Ground"));
            Debug.Log($"jumpRequsted: {jumpRequsted}, isGrounded: {isGrounded}");
            
            if (jumpRequsted&&isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0f);
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
            
        }
        public abstract void HandleAction();
    }
    
    
}

