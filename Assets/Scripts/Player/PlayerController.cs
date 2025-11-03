using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Player
{
    public abstract class PlayerController : MonoBehaviour
    {
        [SerializeField] protected float speed = 8f;
        [SerializeField] protected float jumpForce = 3f;
        private float lastJumpTime;
        private float jumpCooldown;

        public Vector2 movementDirection;
        [SerializeField] public Rigidbody2D rb;

        [SerializeField] protected SpriteRenderer spriteRenderer;
        protected bool jumpRequsted = false;
        public bool isGrounded = false;

        [SerializeField] private AnimationHandler animationHandler;

        [Header("효과음")]
        //[SerializeField] private AudioSource playerAudioSource;
        [SerializeField] private AudioClip jumpClip;


        private void Awake()
        {
            Init();
        }

        private void Update()
        {
            HandleAction();
            Color rayColor = isGrounded ? Color.green : Color.red;
        }

        private void FixedUpdate() //물리효과(rigidbody)가 적용된 오브젝트를 조정할 때
        {
            Move();
            Jump();
        }
        

        private void Init()
        {
            lastJumpTime = 0f;
            jumpCooldown = 0.2f;
        }

        protected void Dead()
        {
            animationHandler.Dead();
        }

        private void Move()
        {
            animationHandler.Run(movementDirection);
            rb.velocity = new Vector2(movementDirection.x * speed, rb.velocity.y);
        }


        protected void Jump()
        {
            isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.5f, LayerMask.GetMask("Ground")); ;
            // Debug.Log($"jumpRequsted: {jumpRequsted}, isGrounded: {isGrounded}");

            lastJumpTime += Time.deltaTime;

            animationHandler.Jump();

            if (jumpRequsted && lastJumpTime >= jumpCooldown)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpRequsted = false;
                lastJumpTime = 0f;
                //ManagerRoot.AudioManager.PlaySfx(jumpClip); 음악이 아직 없어유 오류방지용주석
            }
        }
        public abstract void HandleAction();
    }


}

