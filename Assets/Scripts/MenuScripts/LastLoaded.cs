using UnityEngine;
using UnityEngine.SceneManagement;

public class LastLoaded : MonoBehaviour
{
    public static string currentLevel;
    private string levelCheck;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        levelCheck = SceneManager.GetActiveScene().name;

        if(levelCheck != "DayCompletion" && levelCheck != "GameOver" && levelCheck != "MainMenu")
        {
            currentLevel = levelCheck;
        }
    }

}
