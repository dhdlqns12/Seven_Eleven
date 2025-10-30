using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 15f;

    [Header("컴포넌트 연결")] 
    [SerializeField]
    private Animator animator;
    private Rigidbody2D rb;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //위로 이동 =>점프 애니메이션
        }
    }
}
