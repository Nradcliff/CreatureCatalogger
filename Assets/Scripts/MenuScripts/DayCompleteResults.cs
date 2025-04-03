using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DayCompleteResults : MonoBehaviour
{
    public ProgramPersist progressTracker;
    public TextMeshProUGUI results,flavor;
    public string resultsText,flavorText;

    public float correct, total;
    public float resultsPercent;
    public string flGreat,flGood,flOkay,flBad;

    void Start()
    {
        progressTracker = GameObject.Find("LoadProgramManager").GetComponent<ProgramPersist>();
        progressTracker.programBool[3] = false;
        correct = progressTracker.correctReports;
        total = progressTracker.totalReports;
        resultsText = correct.ToString() + " out of " + (total*2).ToString() + "\nPossible Points";
        results.text = resultsText;

        resultsPercent = correct / total;

        if (resultsPercent >= .9)
        {
            flavor.text = flGreat;
        }
        else if (resultsPercent >= .75)
        {
            flavor.text = flGood;
        }
        else if (resultsPercent >= .6)
        {
            flavor.text = flOkay;
        }
        else if (resultsPercent >= .45)
        {
            flavor.text = flBad;
        }
        else
        {
            SceneManager.UnloadSceneAsync("DayCompletion");
            SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
        }
    }

    void Update()
    {
        
    }
}
