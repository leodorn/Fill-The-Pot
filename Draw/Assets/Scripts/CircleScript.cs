using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bucket"))
        {
            collision.GetComponent<BucketScript>().ReducePoint();
        }
    }
}
