using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecretScreen : MonoBehaviour
{
    protected float timer1Goal, timer2Goal, timer3Goal, timer4Goal, timer;
    public TextMeshProUGUI orangeText, greenText;
    public GameObject parentobj;
    public Scene loadTo;
    public List<string> thingsToSay;
    public int stringIndex;

    public GameObject activateMe;

    public ProgramPersist persist;
    void Start()
    {
        persist = GameObject.Find("LoadProgramManager").GetComponent<ProgramPersist>();
        persist.programBool[5] = false; //Removes the secret window from the avaliable list of programs
        timer1Goal = 1;
        timer2Goal = Random.Range(.5f, 1.25f) + timer1Goal / 2;
        persist.DayNum += 1;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timer2Goal)
        {
            //Activate text and button
            activateMe.SetActive(true);
            parentobj.SetActive(false);
        }
        if (timer < .75f)
        {
            InvokeRepeating("addLines", .25f, .45f);
        }
    }

    void addLines()
    {
        if (stringIndex < thingsToSay.Count)
        {
            TextMeshProUGUI orange = Instantiate(orangeText, parentobj.transform);
            orange.text = thingsToSay[stringIndex];
            stringIndex += 1;
        }
        else
        {
        }
    }

    public void finishScene()
    {
        SceneManager.UnloadSceneAsync("SecretScene");
        persist.correctReports = persist.totalReports * 2;
        SceneManager.LoadScene("DayCompletion", LoadSceneMode.Additive);
    }
}
