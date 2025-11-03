using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Player
{
    public class AnimationHandler : MonoBehaviour
    {
        private PlayerController playerController;
        
        //파라미터 컨트롤 할 변수
        private static readonly int IsRunning = Animator.StringToHash("IsRun");
        private static readonly int IsJumping = Animator.StringToHash("IsJump");
        private static readonly int IsDead = Animator.StringToHash("IsDead");
        
        private Animator animator;

        protected virtual void Awake() //virtual을 사용하면 이 메서드가 자식 클래스에서 override를 사용하여 재정의될 수 있음
        {
            animator = GetComponentInChildren<Animator>();
        }

        private void Start()
        {
            playerController = GetComponent<PlayerController>();
        }
        
        
        public void Run(Vector2 velocity)
        {
            animator.SetBool(IsRunning,Mathf.Abs(velocity.x)>0.5f); //mathf.abs로 velocity.x를 절대값으로 바꿔주었다. 0.5보다 크면 ture/ 0.5보다 작으면 false이다.
        }                                                              

        public void Jump()
        {
            animator.SetBool(IsJumping, playerController.isGrounded? false : true);
        }

        public void Dead()
        {
           animator.SetBool(IsDead,true);
        }
    }

}
