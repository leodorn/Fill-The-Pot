using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreenScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Metaball_liquid"))
        {
            Destroy(collision.gameObject);
        }
    }
}
