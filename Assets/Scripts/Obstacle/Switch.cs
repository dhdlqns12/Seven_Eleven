using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] private GameObject button;

    private float ButtonMoveSpeed = 4f;
    private Vector2 ButtonOriginPos;
    private Vector2 ButtonPressPos;

    private Rigidbody2D rb;

    private bool isEnter = false;

    void Start()
    {
        rb = button.GetComponent<Rigidbody2D>();
        ButtonOriginPos = rb.position;//현재 버튼의 좌표 기록
        ButtonPressPos = ButtonOriginPos + new Vector2(0, -0.12f);//밟았을 때 위치//왜 클래스에서 선언하면 오류?
    }


    void FixedUpdate()
    {
        Vector2 ButtonPosTarget = isEnter ? ButtonPressPos : ButtonOriginPos;
        rb.MovePosition(Vector2.Lerp(rb.position, ButtonPosTarget, Time.fixedDeltaTime * ButtonMoveSpeed));//현재 위치와 타겟위치 사이를 자연스럽게 속도 맞춰서 위치 바꾸기
    }



    private void OnTriggerEnter2D(Collider2D _boxOrPlayer)
    {
        if (_boxOrPlayer.CompareTag("Player") || _boxOrPlayer.CompareTag("Box"))
        {
            isEnter = true;
            Debug.Log("버튼을 밟고 있습니다.");
        }
    }
    private void OnTriggerExit2D(Collider2D _boxOrPlayer)
    {

        if (_boxOrPlayer.CompareTag("Player") || _boxOrPlayer.CompareTag("Box"))
        {
            isEnter = false;
            Debug.Log("버튼 충돌범위를 벗어났습니다.");
        }
    }
}
