
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class switchelevater : MonoBehaviour
{
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject elevater;

    
    [SerializeField] private float elevaterMoveSpeed = 4f;//엘레베이터 움직이는 속도 수정 가능
    [SerializeField] private float targetPositionY;//엘베 목표지점 원하시는 위치로 수정가능
    [SerializeField] private float targetPositionX;//엘베 목표지점 원하시는 위치로 수정가능

    float ButtonMoveSpeed = 4f;
    Vector2 ButtonOriginPos;
    Vector2 ButtonPressPos;

    Rigidbody2D rb;

    bool isEnter = false;//플레이어나 박스가 같이 눌러도 중복동작방지
    
    //버튼을 가리려면 -0.19만큼 이동, 버튼 원상복구는 +0.19

    void Start()
    {
        rb = button.GetComponent<Rigidbody2D>();
        ButtonOriginPos = rb.position;//현재 버튼의 좌표 기록
        ButtonPressPos = ButtonOriginPos + new Vector2(0, -0.19f);//밟았을 때 위치//왜 클래스에서 선언하면 오류?
    }


    void Update()
    {




    }

    void FixedUpdate() 
    {
        Vector2 ButtonPosTarget = isEnter ? ButtonPressPos : ButtonOriginPos;
        rb.MovePosition(Vector2.Lerp(rb.position, ButtonPosTarget, Time.fixedDeltaTime * ButtonMoveSpeed));//현재 위치와 타겟위치 사이를 자연스럽게 속도 맞춰서 위치 바꾸기
    }
    


    private void OnTriggerEnter2D(Collider2D _boxOrPlayer) 
    {
        if (_boxOrPlayer.CompareTag("CanEnterButton"))
        {
            isEnter = true;
            Debug.Log("버튼을 밟고 있습니다.");
        }
    }
    private void OnTriggerExit2D(Collider2D _boxOrPlayer)
    {
        
        if (_boxOrPlayer != null)
        {
            isEnter = false;
            Debug.Log("버튼 충돌범위를 벗어났습니다.");
        }
    }

}
