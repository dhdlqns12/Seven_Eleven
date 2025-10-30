using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boy : PlayerController
{
    public override void HandleAction()
    {
        float horizontalInput = 0f;
        bool jumpRequested = false;
        
        if (Input.GetKey(KeyCode.W))
        {
            jumpRequested = true;
        }

        else if (Input.GetKey(KeyCode.A))
        {
            horizontalInput = -1f;
        }

        else if (Input.GetKey(KeyCode.D))
        {
            horizontalInput = 1f;
        }
            
    }
}
