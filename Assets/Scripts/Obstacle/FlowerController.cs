using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlowerController : MonoBehaviour
{
    protected bool FullFlower = false;
    [SerializeField] protected GameObject flowerGround;
    [SerializeField] protected GameObject stem;



    public void IsBloom(bool state)
    {
        FullFlower = state;
    }


   
}
