using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheckSystem : MonoBehaviour
{
    public TMP_Dropdown currentReport;

    public ReportDisplay display;
    private ReportWindow activeReport;

    private Dictionary<string, ReportWindow> dict = new Dictionary<string, ReportWindow>();

    public TMP_Dropdown currentThreat;
    public TMP_Dropdown currentType;

    string threatSelection;
    string typeSelection;

    bool submission;

    public void Start()
    {

        for (int i = 0; i < display.dayReports.Count; i++) //Copies the reports of the reportArr into this temporary list so we can avoid duplicate selections later
        {
            dict.Add(display.dayReports[i].name, display.dayReports[i]);
        }
    }

    public void GetDropdownReport() 
    {
        int reportIndex = currentReport.value;
        string reportSelection = currentReport.options[reportIndex].text;
        activeReport = dict[reportSelection];

        Debug.Log(reportSelection);
        Debug.Log(activeReport.name);
    }

    public void GetDropdownThreatValue()
    {
        int threatIndex = currentThreat.value;
        threatSelection = currentThreat.options[threatIndex].text;

    }

    public void GetDropdownTypeValue()
    {
        int typeIndex = currentType.value;
        typeSelection = currentType.options[typeIndex].text;
    }


   public void CheckComparison()
    {
        if (activeReport.threat == threatSelection && activeReport.type == typeSelection)
        {
            submission = true;
            Debug.Log("Correct Answer!");
        }
        else
        {
            submission = false;
            Debug.Log("Incorrect Answer!");
        }
    }

}
