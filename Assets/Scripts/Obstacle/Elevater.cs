using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevater : ElevaterManager
{
    [SerializeField] private float elevaterMoveSpeed = 4f;//엘레베이터 움직이는 속도
    [SerializeField] private Vector2 targetPosition;//엘베 목표지점
    Vector2 elevaterOriginPos;//엘레베이터 배치 좌표값
    float time = 0f;
    Rigidbody2D rb;


    void Start()
    {
        rb = elevater.GetComponent<Rigidbody2D>();
        elevaterOriginPos = transform.localPosition;//현재 엘베의 좌표 기록
        targetPosition = new Vector2(targetPosition.x, targetPosition.y);//목표지점 좌표
    }

    void FixedUpdate()
    {
        Vector2 elevaterArrivePos = isEnter ? targetPosition : elevaterOriginPos;
        //rb.MovePosition(Vector2.Lerp(rb.position, elevaterArrivePos, Time.fixedDeltaTime * elevaterMoveSpeed));//현재 위치와 타겟위치 사이를 자연스럽게 속도 맞춰서 위치 바꾸기
        time += Time.fixedDeltaTime;
        float rate = time / elevaterMoveSpeed;
        rate = Mathf.Clamp01(rate);
        transform.localPosition = Vector2.Lerp(elevaterOriginPos, elevaterArrivePos, rate);
        Debug.Log($"elevaterOriginPos: {elevaterOriginPos},elevaterArrivePos: {elevaterArrivePos}, position: {transform.localPosition} ");
    }

    public void SetActive(bool state)
    {
        isEnter = state;
        time = 0f;
    }

}
