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
    public ProgramPersist progressTracker;

    void Start()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("MainLevel"));
        progressTracker = GameObject.Find("LoadProgramManager").GetComponent<ProgramPersist>();
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
                SceneManager.SetActiveScene(SceneManager.GetSceneByName("OverlayScene"));
                if (progressTo == 1)
                {
                    Application.Quit();
                }
                else if(progressTo == 2)
                {
                    //SceneManager.LoadScene("MainMenu");
                    //COMMENTED OUT CODE IS FOR REGULAR SCENE CHANGES, CURRENT CODE IS FOR ADDITIVE SCENES
                    SceneManager.UnloadSceneAsync("MainLevel");
                    SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
                    progressTo = 0;
                }
                else if (progressTo == 3)
                {
                    //SceneManager.LoadScene("DayCompletion");
                    SceneManager.UnloadSceneAsync("MainLevel");
                    SceneManager.LoadScene("DayCompletion", LoadSceneMode.Additive);
                }
                else if (progressTo == 4)
                {
                    //SceneManager.LoadScene("GameOver");
                    SceneManager.UnloadSceneAsync("MainLevel");
                    SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
                }
            }
            fadePanel.GetComponent<Image>().color = new Color(0, 0, 0, timer);
        }
    }
    public void quitTheGame()
    {
        Time.timeScale = 1;
        progressTo = 1;
        fadeInOrOut = false;
    }
    public void goToMenu()
    {
        Time.timeScale = 1;
        progressTo = 2;
        fadeInOrOut = false;
    }
    public void nextLevel()
    {
        Time.timeScale = 1;
        progressTo = 3;
        progressTracker.DayNum += 1;
        fadeInOrOut = false;
    }
}
