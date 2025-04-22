using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TaskbarTime : MonoBehaviour
{
    //Will be removed for final game probably

    public float timer;
    public TextMeshProUGUI clock;
    public FadeForMainLevel fadeout;
    public float timeLimitInMinutes;
    ProgramPersist saveLoadThingy;
    bool stopGoingToDayOneHundred;

    void Start()
    {
        saveLoadThingy = GameObject.Find("LoadProgramManager").GetComponent<ProgramPersist>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        int seconds = ((int)timer % 60);
        int minutes = ((int)timer / 60);
        clock.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        if (!saveLoadThingy.noTimer)
        {
            if (timer >= (timeLimitInMinutes - 1) * 60f)
            {
                clock.color = Color.red;
            }
            if (timer >= timeLimitInMinutes * 60f)
            {
                if (!stopGoingToDayOneHundred)
                {
                    fadeout.nextLevel();
                    stopGoingToDayOneHundred = true;
                }
            }
        }
    }

    private void OnDestroy()
    {
        saveLoadThingy.totalTime += timer;
    }
}
