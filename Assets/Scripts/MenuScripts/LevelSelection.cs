using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public string LastActiveScene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

   public void GoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SaveAndQuit()
    {
        Application.Quit();
    }

    public void RetryLevel()
    {
        LastActiveScene = LastLoaded.currentLevel;
        SceneManager.LoadScene(LastActiveScene);
    }

}
