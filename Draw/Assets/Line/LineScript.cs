using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineScript : MonoBehaviour
{
    public DrawManager drawManager;

    private void Start()
    {
        drawManager = GameObject.Find("DrawManager").GetComponent<DrawManager>();
    }

   

    
}
