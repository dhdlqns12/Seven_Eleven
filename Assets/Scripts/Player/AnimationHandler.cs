using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class AnimationHandler : MonoBehaviour
    {
        private static readonly int IsRunning = Animator.StringToHash("IsRunning");
        private static readonly int IsJumping = Animator.StringToHash("IsJumping");
        
        private Animator animator;

        protected virtual void Awake() //virtual을 사용하면 이 메서드가 자식 클래스에서 override를 사용하여 재정의될 수 있음
        {
            animator = GetComponentInChildren<Animator>();
        }

        public void Run()
        {
            animator.SetBool(IsRunning, true);
        }

        public void Jump(Vector2 direction)
        {
            animator.SetBool(IsJumping, true);
        }

       
        
    }

}
