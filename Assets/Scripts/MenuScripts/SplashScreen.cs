using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    protected float timer1Goal,timer2Goal,timer3Goal,timer4Goal,timer;
    public TextMeshProUGUI orangeText, greenText;
    public GameObject parentobj,unity;
    public Scene loadTo;
    public List<string> thingsToSay;
    public int stringIndex;
    void Start()
    {
        timer1Goal = 1;
        timer2Goal = Random.Range(.5f, 1.25f)+timer1Goal/2;
        timer3Goal = 3;
        timer4Goal = Random.Range(1, 1.25f)+timer3Goal/2+1;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= timer4Goal)
        {
            //SceneManager.LoadScene("MainLevel");
            SceneManager.UnloadSceneAsync("SplashScreen");
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
        }
        if(timer >= timer2Goal)
        {
            unity.SetActive(true);
        }
        if (timer < .5f)
        {
            InvokeRepeating("addLines", .25f, .25f);
        }
    }

    void addLines()
    {
        if (stringIndex < thingsToSay.Count)
        {
            TextMeshProUGUI green = Instantiate(greenText, parentobj.transform);
            green.text = thingsToSay[stringIndex];
            stringIndex += 1;
        }
    }
}
