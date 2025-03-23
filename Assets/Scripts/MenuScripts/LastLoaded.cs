using UnityEngine;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

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
