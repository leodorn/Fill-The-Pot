using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour, IBucket
{
    // Start is called before the first frame update
    [SerializeField]
    private int actualPointNumber;
    [SerializeField]
    private Animation animToPlay;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReducePoint()
    {

        actualPointNumber--;
        Debug.Log("Hello");
        if (actualPointNumber == 0)
        {
            Debug.Log("yes");
            animToPlay.Play();
        }
    }
}
