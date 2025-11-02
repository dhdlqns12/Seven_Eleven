using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerGround : FlowerController
{

    [SerializeField] private float moveSpeed = 4f;         
    [SerializeField] private float targetPosY;     

    private Vector2 originPos;                             
    private Vector2 targetPos;                             
    private Rigidbody2D rb;

    void Start()
    {
        rb = flowerGround.GetComponent<Rigidbody2D>();
        originPos = rb.position;
        targetPos = new Vector2(originPos.x, originPos.y + targetPosY); 
    }

    void FixedUpdate()
    {
        Vector2 moveTarget = FullFlower ? targetPos : originPos;
        rb.MovePosition(Vector2.Lerp(rb.position, moveTarget, Time.fixedDeltaTime * moveSpeed));
    }

 
}
