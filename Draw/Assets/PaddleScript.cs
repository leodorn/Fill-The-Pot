using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Water2D;

public class PaddleScript : MonoBehaviour
{
    [SerializeField] GameObject prefabCube;
    [SerializeField] GameObject spawnPoint;
    [SerializeField] float speed;
    [SerializeField] int debit;
    public bool waterOpen = false;
    public int totalWater;

    public static PaddleScript instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.right * Time.deltaTime * -1 * speed);
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * Time.deltaTime * 1 * speed);
        }

        if(waterOpen)
        {
            totalWater--;
            SliderManager.instance.SetSliderWater(totalWater);
            
        }
        else if(!waterOpen && totalWater > 0)
        {
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                waterOpen = true;
                Water2D_Spawner.instance.Spawn();
                //Instantiate(prefabCube, spawnPoint.transform.position, Quaternion.identity);
            }
        }
        if(totalWater == 0)
        {
            Water2D_Spawner.instance._breakLoop = true;
        }

        
        

    }
}
