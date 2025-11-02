
using UnityEngine;


public class SwitchManager : MonoBehaviour
{
   
    [SerializeField] protected GameObject elevater;
    
    [SerializeField] protected float elevaterMoveSpeed = 4f;//엘레베이터 움직이는 속도 수정 가능
    [SerializeField] protected float targetPositionY;//엘베 목표지점 원하시는 위치로 수정가능
    [SerializeField] protected float targetPositionX;//엘베 목표지점 원하시는 위치로 수정가능

   //플레이어나 박스가 같이 눌러도 중복동작방지
    
    //버튼을 가리려면 -0.19만큼 이동, 버튼 원상복구는 +0.19


}
