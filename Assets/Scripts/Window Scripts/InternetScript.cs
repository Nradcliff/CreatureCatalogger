using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InternetScript : MonoBehaviour
{
    public float timer,timerButAgainQuestionMark,loseInternetStartingAfterThisNumberOfSeconds;
    public bool on;

    public Sprite threesprite,twosprite,onesprite,off;

    public float connectionTime;
    public bool restarting;

    public TextMeshProUGUI reconnectingText;

    public TMP_InputField inputField;
    public string password;

    public bool freeToRestart;

    public int openPrograms;
    float timerTarget;

    public ProgramPersist saveLoadThingy;

    void Start()
    {
        saveLoadThingy = GameObject.Find("LoadProgramManager").GetComponent<ProgramPersist>();
        password = saveLoadThingy.randPass;
    }

    // Update is called once per frame
    void Update()
    {
        if(openPrograms <= 3)
        {
            timerTarget = 90;
        }
        else if(openPrograms < 4)
        {
            timerTarget = 75;
        }
        else if (openPrograms < 5)
        {
            timerTarget = 55;
        }
        else if (openPrograms < 8)
        {
            timerTarget = 45;
        }

        
        if (timerButAgainQuestionMark > loseInternetStartingAfterThisNumberOfSeconds)
        {
            timer += Time.deltaTime;
        }
        else timerButAgainQuestionMark += Time.deltaTime;
        if (timer >= timerTarget)
        {
            freeToRestart = false;
            timer = 0;
            on = false;
            reconnectingText.text = "Not Connected";
            reconnectingText.color = Color.red;
            inputField.gameObject.SetActive(true);
            inputField.interactable = true;
        }
        if (on)
        {
            if (timer / timerTarget < .33f)
            {
                this.GetComponent<Image>().sprite = threesprite;
            }
            else if(timer / timerTarget < .66f)
            {
                this.GetComponent<Image>().sprite = twosprite;
            }
            else if (timer / timerTarget < .85f)
            {
                this.GetComponent<Image>().sprite = onesprite;
            }
            freeToRestart = true;
        }
        else this.GetComponent<Image>().sprite = off;

        if (restarting)
        {
            on = false;
            connectionTime += Time.deltaTime;
            if (connectionTime < .75f)
            {
                reconnectingText.text = "Reconnecting";
            }
            else if (connectionTime >= .75f && connectionTime < 1.5f)
            {
                reconnectingText.text = "Reconnecting.";
            }
            else if (connectionTime >= 1.5f && connectionTime < 2.25f)
            {
                reconnectingText.text = "Reconnecting..";
            }
            else if (connectionTime >= 2.25f)
            {
                reconnectingText.text = "Reconnecting...";
            }
            reconnectingText.color = Color.yellow;

            if (connectionTime > 3 && (inputField.text == password || freeToRestart == true))
            {
                reconnectingText.text = "Connected";
                reconnectingText.color = Color.green;
                connectionTime = 0;
                restarting = false;
                on = true;
                timerButAgainQuestionMark = 0;
                timer = 0;
                inputField.text = "";
                inputField.gameObject.SetActive(false);
            }
            else if (connectionTime > 3 && (inputField.text != password)){
                restarting = false;
                connectionTime = 0;
                reconnectingText.text = "Not Connected";
                reconnectingText.color = Color.red;
                inputField.gameObject.SetActive(true);
                inputField.interactable = true;
            }
        }

    }

    public void reconnect()
    {
        if (Time.timeScale > 0)
        {
            inputField.interactable = false;
            connectionTime = 0;
            restarting = true;
            timer = 0;
        }
    }
}
