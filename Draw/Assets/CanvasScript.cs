using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasScript : MonoBehaviour
{
    [SerializeField]
    GameObject buttonNext;
    public void LoadNextLevel()
    {
        Debug.Log("yo la team");
        Debug.Log(PlayerPrefs.GetInt("level"));
        if (SceneManager.sceneCountInBuildSettings - 1 != PlayerPrefs.GetInt("level") )
        {
            int nextLevel = PlayerPrefs.GetInt("level") + 1;
            PlayerPrefs.SetInt("level", nextLevel);
            SceneManager.LoadScene(PlayerPrefs.GetInt("level"));
        }
    }

    public void ActiveButton()
    {
        buttonNext.SetActive(true);
    }

    public void Retry()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("level"));
    }
}
