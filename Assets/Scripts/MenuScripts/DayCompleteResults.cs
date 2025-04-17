using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DayCompleteResults : MonoBehaviour
{
    public AudioSource source;
    public AudioClip tick;

    public ProgramPersist progressTracker;

    public float correct, total;
    public float resultsPercent;

    public float timer,timer1Goal,timer2Goal,timer3Goal,timer4Goal;

    public TextMeshProUGUI flavor, yourPoints, totalPoints, passingStatus;
    public Image smileorfrown,darkness;

    public GameObject passingButtons;

    public bool sound1, sound2, sound3, sound4,sound5;

    public float killTimer,darknessTimer;


    void Start()
    {
        darkness = GameObject.Find("Death").GetComponent<Image>();
        progressTracker = GameObject.Find("LoadProgramManager").GetComponent<ProgramPersist>();
        progressTracker.programBool[3] = false;
        correct = progressTracker.correctReports;
        total = progressTracker.totalReports;
        resultsPercent = correct / total;

        if(resultsPercent < .45)
        {
            progressTracker.resetBools = false;
        }
    }

    void Update()
    {
        source.volume = progressTracker.masterVol * progressTracker.sfxVol*.05f;

        timer += Time.deltaTime;
        if (timer >= timer4Goal)
        {
            //Display Grade and Passing Status
            passingStatus.gameObject.SetActive(true);
            if(resultsPercent >= .45)
            {
                passingStatus.text = "Passed!";
                passingButtons.SetActive(true);
                if (sound4)
                {
                    sound4 = false;
                    source.PlayOneShot(tick);
                }
                if(progressTracker.DayNum == 5)
                {
                    passingStatus.text = "Passed!\nERROR: USER-1214 PASSWORD RESET: " + progressTracker.UserTwelveFourteenPassword;
                }
                //Save Player Data
            }
            else
            {
                //Make alarm sound and flash
                passingStatus.text = ":(";
                killTimer += Time.deltaTime;
                progressTracker.clearData();
                if (sound4)
                {
                    sound4 = false;
                    source.PlayOneShot(tick);
                }
                //Erase Save Data
            }
        }
        else if (timer >= timer3Goal)
        {
            //Obtained Points: #
            yourPoints.gameObject.SetActive(true);
            yourPoints.text = "Points Obtained:....."+correct.ToString();
            if (sound3)
            {
                sound3 = false;
                source.PlayOneShot(tick);
            }
        }
        else if(timer >= timer2Goal)
        {
            //Total Possible Points: #
            totalPoints.gameObject.SetActive(true);
            totalPoints.text = "Points Possible:....." + (total*2).ToString();

            if (sound2)
            {
                sound2 = false;
                source.PlayOneShot(tick);
            }
        }
        else if(timer >= timer1Goal)
        {
            //Display a line
            flavor.gameObject.SetActive(true);
            if (sound1)
            {
                sound1 = false;
                source.PlayOneShot(tick);
            }
        }

        if(killTimer > 1.5f)
        {
            darknessTimer += Time.deltaTime;
            progressTracker.dead = true;
            darkness.color = new Color(0, 0, 0, 1);

            if (darknessTimer > 2)
            {
                SceneManager.LoadScene("OverlayScene");
            }
        }
    }
}
