using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girl : PlayerController
{
    public override void HandleAction()
    {
        float horizontalInput = 0f;
        bool jumpRequested = false;
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            jumpRequested = true;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontalInput = -1f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
             horizontalInput = 1f;
        }
    }
}
