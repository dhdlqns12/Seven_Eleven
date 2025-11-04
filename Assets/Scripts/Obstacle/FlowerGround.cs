using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlowerGround : FlowerController
{
    
   

    private Vector2 originPos;                             
    

    bool isBloom=false;
    float time = 0f;

    
    void Start()
    {
        originPos = transform.localPosition;
    }

    void Update()
    {
        Vector2 pos;

        if (isBloom)//도착지점 바꿈
        {
            pos = targetPosition;
        }
        else
        {
            pos = originPos;
        }

        time += Time.deltaTime;


        float rate = time / Speed;
        rate = Mathf.Clamp01(rate);
        transform.localPosition = Vector2.Lerp(transform.localPosition, pos, rate * 0.05f);
       
    }

    public void SetActive(bool _state)
    {
        isBloom = _state;
    }

    public void ResetTime()
    {
        time = 0f;
    }


}
