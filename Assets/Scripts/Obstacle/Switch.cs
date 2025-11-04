using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : ElevaterManager
{
    
    [SerializeField] private Elevater elevaterScript;

    [Header("효과음")]
    [SerializeField] private AudioClip switchSound;

    float ButtonMoveSpeed = 1f;
    Vector2 ButtonOriginPos;
    Vector2 ButtonPressPos;
    
    float time = 0f;

    
    void Start()
    {
        ButtonOriginPos = transform.localPosition;//현재 버튼의 좌표 기록
        ButtonPressPos = ButtonOriginPos + new Vector2(0, -0.12f);//
    }

    void Update()
    {
        Vector2 pos;
        if(isEnterCount>0)
        {
            pos = ButtonPressPos;
        }
        else
        {
            pos = ButtonOriginPos;
        }

        time += Time.deltaTime;
        float rate = time / ButtonMoveSpeed;
        rate = Mathf.Clamp01(rate);
        transform.localPosition = Vector2.Lerp(transform.localPosition, pos, rate);
        //rb.MovePosition(Vector2.Lerp(rb.position, ButtonPosTarget, Time.fixedDeltaTime * ButtonMoveSpeed));//현재 위치와 타겟위치 사이를 자연스럽게 속도 맞춰서 위치 바꾸기
    }
   
    
    
    private void OnTriggerEnter2D(Collider2D _boxOrPlayer)
    {
        //플레이어 불, 박스, 플레이어 물 태그가 붙어있는 오브젝트와 충돌하는지 체크하기
        if (_boxOrPlayer.CompareTag("Player_Fire") || _boxOrPlayer.CompareTag("Box")|| _boxOrPlayer.CompareTag("Player_Water"))
        {
            if (isEnterCount <= 0)
            {
                time = 0f;
                elevaterScript.ResetTime();
                elevaterScript.SetActive(true);
            }
           
            EnterColliderCheack();
            //elevaterScript.SetActive(isEnterCount>0);

            ManagerRoot.AudioManager.PlaySfx(switchSound);
            Debug.Log("버튼을 밟고 있습니다.");
        }
    }
    private void OnTriggerExit2D(Collider2D _boxOrPlayer)
    {
        //플레이어 불, 박스, 플레이어 물 태그가 붙어있는 오브젝트와 충돌범위를 벗어났는지 체크하기
        if (_boxOrPlayer.CompareTag("Player_Fire") || _boxOrPlayer.CompareTag("Box") || _boxOrPlayer.CompareTag("Player_Water"))
        {
            ExitColliderCheack();
            //elevaterScript.SetActive(isEnterCount > 0);

            if (isEnterCount <= 0)
            {
                time = 0f;
                elevaterScript.SetActive(false);
                elevaterScript.ResetTime();

            }
            
                Debug.Log("버튼 충돌범위를 벗어났습니다.");
        }
    }

}


