using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlowerController : MonoBehaviour
{
   

    protected bool FullFlower = false;

    [SerializeField] protected GameObject flowerGround;
    [SerializeField] protected GameObject stem;
    
    [SerializeField] protected float Speed = 1f;
    [SerializeField] protected Vector2 targetPosition;
    [SerializeField] private float stemLength;

    Vector2 OriginPos;//엘레베이터 배치 좌표값
    float time = 0f;

    private void Awake()
    {

    }


    void Start()
        {
            OriginPos = transform.localPosition;
        }

        void Update()
        {
            Vector2 pos;

            if (FullFlower)//도착지점 바꿈
            {
                pos = targetPosition;
            }
            else
            {
                pos = OriginPos;
            }

            time += Time.deltaTime;


            float rate = time / Speed * 0.07f;//버그 대비 속도 조정
            rate = Mathf.Clamp01(rate);
            transform.localPosition = Vector2.Lerp(transform.localPosition, pos, rate * 0.05f);
        }
    
    
    public void ResetTime()
    {
        time = 0f;
    }

}
