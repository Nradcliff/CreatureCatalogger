using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InternetScript : MonoBehaviour
{
    public float timer;
    public bool on;

    public Sprite onSprite, offSprite;

    public float connectionTime;
    public bool restarting;

    public TextMeshProUGUI reconnectingText;

    public TMP_InputField inputField;
    public string password;

    public bool freeToRestart;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 90)
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
            this.GetComponent<Image>().sprite = onSprite;
            freeToRestart = true;
        }
        else this.GetComponent<Image>().sprite = offSprite;

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
