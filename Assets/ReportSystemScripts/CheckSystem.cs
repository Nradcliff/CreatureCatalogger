using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheckSystem : MonoBehaviour
{
    public TMP_Dropdown currentReport;
    private ReportDisplay activeReport;

    public TMP_Dropdown currentThreat;
    public TMP_Dropdown currentType;

    string threatSelection;
    string typeSelection;

    bool submission;

   public void GetDropdownValue()
    {
        int reportIndex = currentReport.value;
        string reportSelection = currentReport.options[reportIndex].text;
        activeReport = Resources.Load<ReportDisplay>(reportSelection);
        Debug.Log(reportSelection);
        Debug.Log(activeReport.name);


        int threatIndex = currentThreat.value;
        threatSelection = currentThreat.options[threatIndex].text;

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
