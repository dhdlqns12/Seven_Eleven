using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevaterManager : MonoBehaviour
{
    protected int isEnterCount=0;

    [SerializeField] protected GameObject elevater;
    [SerializeField] protected GameObject button;

    protected void EnterColliderCheack()
    {
        isEnterCount += 1;
    }
    protected void ExitColliderCheack()
    {
        isEnterCount -= 1;
    }

}
