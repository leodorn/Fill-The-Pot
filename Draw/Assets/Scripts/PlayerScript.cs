using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Water2D;

public class PlayerScript : MonoBehaviour
{
    public bool waterOpen = false;
    public int totalWater;

    private void Awake()
    {
        
    }

    private void Update()
    {       

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
