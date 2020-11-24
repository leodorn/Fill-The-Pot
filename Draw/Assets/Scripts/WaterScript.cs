using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour
{
    // Start is called before the first frame update
    private bool canTp = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("LavaWall"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bucket"))
        {
            collision.GetComponent<IBucket>().ReducePoint();
        }
        if(collision.CompareTag("BlackHole"))
        {
            Destroy(gameObject);
        }
        if(collision.CompareTag("Portal") && canTp )
        {
            collision.GetComponent<PortalScript>().TeleportWater(gameObject);
            GetComponent<TrailRenderer>().enabled = false;
            StartCoroutine(TimerTp());
            if(collision.gameObject.transform.rotation.z == collision.GetComponent<PortalScript>().otherPortal.transform.rotation.z)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-GetComponent<Rigidbody2D>().velocity.x, -GetComponent<Rigidbody2D>().velocity.y);
            }

        }
        
    }

    private IEnumerator TimerTp()
    {
        canTp = false;
        yield return new WaitForSeconds(0.2f);
        canTp = true;
    }


}
