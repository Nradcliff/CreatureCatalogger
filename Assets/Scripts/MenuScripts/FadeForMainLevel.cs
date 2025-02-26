using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeForMainLevel : MonoBehaviour
{
    public GameObject fadePanel;
    /// <summary>
    /// Fade In Or Out |
    /// True = in |
    /// False = out
    /// </summary>
    public bool fadeInOrOut;
    public float timer;
    /// <summary>
    /// Progress To |
    /// 1 = Quit Game
    /// 2 = Main Menu
    /// 3 = Level Complete
    /// 4 = Game Over
    /// </summary>
    public int progressTo;

    void Start()
    {
        
    }

    void Update()
    {
        if (fadeInOrOut)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                fadePanel.SetActive(false);
            }
            fadePanel.GetComponent<Image>().color = new Color(0, 0, 0, timer);
        }
        else
        {
            if(timer < 1.5f)
            {
                fadePanel.SetActive(true);
                timer += Time.deltaTime;
            }
            else
            {
                if (progressTo == 1)
                {
                    Application.Quit();
                }
                else if(progressTo == 2)
                {
                    SceneManager.LoadScene("MainMenu");
                }
                else if (progressTo == 3)
                {
                    SceneManager.LoadScene("DayCompletion");
                }
                else if (progressTo == 4)
                {
                    SceneManager.LoadScene("GameOver");
                }
            }
            fadePanel.GetComponent<Image>().color = new Color(0, 0, 0, timer);
        }
    }
    public void quitTheGame()
    {
        progressTo = 1;
        fadeInOrOut = false;
    }
    public void goToMenu()
    {
        progressTo = 2;
        fadeInOrOut = false;
    }
    public void nextLevel()
    {
        progressTo = 3;
        fadeInOrOut = false;
    }
}
