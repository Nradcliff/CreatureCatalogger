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
    /// Quit or Menu |
    /// True = quit game
    /// False = main menu
    /// </summary>
    public bool quitOrMenu;

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
                if (quitOrMenu == true)
                {
                    Application.Quit();
                }
                else
                {
                    SceneManager.LoadScene("MainMenu");
                }
            }
            fadePanel.GetComponent<Image>().color = new Color(0, 0, 0, timer);
        }
    }
    public void quitTheGame()
    {
        quitOrMenu = true;
        fadeInOrOut = false;
    }
    public void goToMenu()
    {
        quitOrMenu = false;
        fadeInOrOut = false;
    }
}
