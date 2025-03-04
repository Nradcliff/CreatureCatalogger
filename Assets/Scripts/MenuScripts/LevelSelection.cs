using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public void NextLevel()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        if (gameObject.scene.name == "DayCompletion")
        {
            SceneManager.UnloadSceneAsync("DayCompletion");
        }
        else
        {
            SceneManager.UnloadSceneAsync("GameOver");
        }
        SceneManager.LoadScene("MainLevel", LoadSceneMode.Additive);
    }

   public void GoMainMenu()
    {
        //SceneManager.LoadScene("MainMenu");
        if (gameObject.scene.name == "DayCompletion")
        {
            SceneManager.UnloadSceneAsync("DayCompletion");
        }
        else
        {
            SceneManager.UnloadSceneAsync("GameOver");
        }
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
    }

    public void SaveAndQuit()
    {
        Application.Quit();
    }

    public void RetryLevel()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        if (gameObject.scene.name == "DayCompletion")
        {
            SceneManager.UnloadSceneAsync("DayCompletion");
        }
        else
        {
            SceneManager.UnloadSceneAsync("GameOver");
        }
        SceneManager.LoadScene("MainLevel", LoadSceneMode.Additive);
    }

}
