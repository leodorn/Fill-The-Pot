using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketScript : MonoBehaviour, IBucket
{
    [SerializeField] int pointForWin; 
    int actualPointNumber;


    private void Awake()
    {
        
    }
    private void Start()
    {
        actualPointNumber = pointForWin;
    }
    

    public void ReducePoint()
    {
        actualPointNumber--;
        if(actualPointNumber == 0)
        {
            GameObject.Find("Canvas").GetComponent<CanvasScript>().ActiveButton();
        }
    }
}
