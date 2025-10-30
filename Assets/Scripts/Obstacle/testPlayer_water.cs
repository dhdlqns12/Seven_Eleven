using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class testPlayer_water : MonoBehaviour
{
    
    public float moveSpeed = 5f;  
   
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        }

       
    }
}