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
        [SerializeField] private AudioClip jumpClip;

        private Camera mainCamera;
        private float minX, maxX;
        private float playerHalfWidth;


        private void Awake()
        {
            Init();
        }

        private void Start()
        {
            mainCamera = Camera.main;
            InitCameraBounds();
        }

        private void Update()
        {
            if (!ManagerRoot.GameManager.IsDie)
            {
                HandleAction();
            }
        }

        private void FixedUpdate() //물리효과(rigidbody)가 적용된 오브젝트를 조정할 때
        {
            if (ManagerRoot.GameManager.IsDie==false)
            {
                ClampToCameraBounds();
                Move();
                Jump();
            }
        }
        

        private void Init()
        {
            lastJumpTime = 0f;
            jumpCooldown = 0.2f;
            playerHalfWidth = 0.5f;
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
                ManagerRoot.AudioManager.PlaySfx(jumpClip);
            }
        }
        public abstract void HandleAction();


        #region 카메라 경계 기반 이동 제한
        private void InitCameraBounds()
        {
            if (mainCamera == null)
            {
                Debug.LogWarning("메인 카메라를 없음!");
                return;
            }

            float camHeight = mainCamera.orthographicSize;
            float camWidth = camHeight * mainCamera.aspect;
            Vector3 camPos = mainCamera.transform.position;

            minX = camPos.x - camWidth;
            maxX = camPos.x + camWidth;
        }

        private void ClampToCameraBounds()
        {
            Vector3 pos = transform.position;
            pos.x = Mathf.Clamp(pos.x, minX + playerHalfWidth, maxX - playerHalfWidth);
            transform.position = pos;
        }
        #endregion
    }


}

