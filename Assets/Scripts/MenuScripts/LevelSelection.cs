using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public ProgramPersist progressTracker;

    public void Start()
    {
        progressTracker = GameObject.Find("LoadProgramManager").GetComponent<ProgramPersist>();
    }
    public void NextLevel()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.UnloadSceneAsync("DayCompletion");
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
            progressTracker.resetBools = false;
        }
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
    }

    public void SaveAndQuit()
    {
        if (gameObject.scene.name == "DayCompletion")
        {
            SceneManager.UnloadSceneAsync("DayCompletion");
        }
        else
        {
            SceneManager.UnloadSceneAsync("GameOver");
            progressTracker.resetBools = false;
        }
        Application.Quit();
    }

    public void RetryLevel()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        progressTracker.resetBools = false;
        SceneManager.UnloadSceneAsync("GameOver");
        progressTracker.DayNum = 0;
        SceneManager.LoadScene("MainLevel", LoadSceneMode.Additive);
    }

}
