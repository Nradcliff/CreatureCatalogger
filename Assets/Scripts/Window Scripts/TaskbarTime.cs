using TMPro;
using UnityEngine;

public class TaskbarTime : MonoBehaviour
{
    //Will be removed for final game probably

    public float timer;
    public TextMeshProUGUI clock;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        int seconds = ((int)timer % 60);
        int minutes = ((int)timer / 60);
        clock.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if(timer >= 150)
        {
            Time.timeScale = 0;
        }
    }
}
