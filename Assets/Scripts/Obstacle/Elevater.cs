using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevater : ElevaterManager
{
    [SerializeField] private float elevaterMoveSpeed = 1f;//엘레베이터 움직이는 속도
    [SerializeField] private Vector2 targetPosition;//엘베 목표지점
    Vector2 elevaterOriginPos;//엘레베이터 배치 좌표값
    float time = 0f;

    bool isCollider;


    void Start()
    {
        elevaterOriginPos = transform.localPosition;//현재 엘베의 좌표 기록
    }

    void Update()
    {
        Vector2 pos;

        if (isCollider)//도착지점 바꿈
        {
            pos = targetPosition;
        }
        else
        {
            pos = elevaterOriginPos;
        }

        //rb.MovePosition(Vector2.Lerp(rb.position, elevaterArrivePos, Time.fixedDeltaTime * elevaterMoveSpeed));//현재 위치와 타겟위치 사이를 자연스럽게 속도 맞춰서 위치 바꾸기
        time += Time.deltaTime;
       
        
        float rate = time / elevaterMoveSpeed;
        rate = Mathf.Clamp01(rate);
        transform.localPosition = Vector2.Lerp(transform.localPosition, pos, rate*0.05f);
       // Debug.Log($"elevaterOriginPos: {elevaterOriginPos},elevaterArrivePos: {pos}, position: {transform.localPosition} ");
    }

    public void SetActive(bool state)
    {
        isCollider = state;
    }

    public void ResetTime()
    {
        time = 0f;
    }
}