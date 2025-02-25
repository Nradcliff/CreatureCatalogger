using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CheckSystem : MonoBehaviour
{
    public TMP_Dropdown currentReport;
    int reportIndex;

    public ReportDisplay display;
    private ReportWindow activeReport;

    private Dictionary<string, ReportWindow> dict = new Dictionary<string, ReportWindow>();

    public TMP_Dropdown currentThreat;
    public TMP_Dropdown currentType;

    string threatSelection;
    string typeSelection;

    bool submission;
    private int wrongCounter = 0;

    public void Start()
    {
            for (int i = 0; i < display.dayReports.Count; i++) //Copies the reports of the reportArr into this temporary list so we can avoid duplicate selections later
            {
                dict.Add(display.dayReports[i].name, display.dayReports[i]);
            }
    }

    public void GetDropdownReport() //Gets the current report you want to select
    {
        reportIndex = currentReport.value;
        string reportSelection = currentReport.options[reportIndex].text;
        activeReport = dict[reportSelection];

        //Debug.Log(reportIndex);
    }

    public void GetDropdownThreatValue() //The threat level
    {
        int threatIndex = currentThreat.value;
        threatSelection = currentThreat.options[threatIndex].text;

    }

    public void GetDropdownTypeValue() //The creature type
    {
        int typeIndex = currentType.value;
        typeSelection = currentType.options[typeIndex].text;
    }


   public void CheckComparison()
    {
        if (activeReport.threat == threatSelection && activeReport.type == typeSelection) // If the player selects the right categories it will give a true value and delete the completed report
        {
            submission = true;
            Debug.Log("Correct Answer!");

            Destroy(display.createdDuplicates[reportIndex]);
            display.createdDuplicates.RemoveAt(reportIndex);

            currentReport.options.RemoveAt(reportIndex);
            currentReport.value = 0; // Reset to the first option or handle as needed
            currentReport.RefreshShownValue();
        }
        else //If the player selects the wrong categories, it will give a false value to use and still delete the completed report
        {
            submission = false;
            wrongCounter++;
            Debug.Log("Incorrect Answer!");

            GameObject.Destroy(display.createdDuplicates[reportIndex]);
            display.createdDuplicates.RemoveAt(reportIndex);

            currentReport.options.RemoveAt(reportIndex);
            currentReport.value = 0; // Reset to the first option or handle as needed
            currentReport.RefreshShownValue();

            if(wrongCounter >= 3) //Temporary code to test scene transitions for game over screen
            {
                SceneManager.LoadScene("GameOver");
            }

        }
    }

}
