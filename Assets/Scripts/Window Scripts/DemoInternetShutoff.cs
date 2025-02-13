using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DemoInternetShutoff : MonoBehaviour
{
    public float timer;
    public bool on;

    public Sprite onSprite, offSprite;

    public float connectionTime;
    public bool restarting;

    public TextMeshProUGUI reconnectingText;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 90)
        {
            timer = 0;
            on = false;
            reconnectingText.text = "Not Connected";
            reconnectingText.color = Color.red;
        }
        if (on) this.GetComponent<Image>().sprite = onSprite;
        else this.GetComponent<Image>().sprite = offSprite;

        if (restarting)
        {
            on = false;
            connectionTime += Time.deltaTime;
            reconnectingText.text = "Reconnecting...";
            reconnectingText.color = Color.yellow;

            if (connectionTime > 3)
            {
                reconnectingText.text = "Connected";
                reconnectingText.color = Color.green;
                connectionTime = 0;
                restarting = false;
                on = true;
            }
        }

    }

    public void reconnect()
    {
        connectionTime = 0;
        restarting = true;
        timer = 0;
    }
}
