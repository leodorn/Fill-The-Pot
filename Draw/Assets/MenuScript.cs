using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    
    public void StartNewGame()
    {
        SceneManager.LoadScene(1);
        PlayerPrefs.SetInt("level", 1);
    }

    public void ContinueGame()
    {
        if(PlayerPrefs.HasKey("level"))
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("level"));
        }
        else
        {
            StartNewGame();
        }
        
    }
}
