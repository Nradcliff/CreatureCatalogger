using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    //Additions for Notification System
    public NotificationScript notifSystem;
    bool spawnFinalPopup;

    public void Start()
    {

        for (int i = 0; i < display.dayReports.Count; i++) //Copies the reports of the reportArr into this temporary list so we can avoid duplicate selections later
        {
            dict.Add(display.dayReports[i].name, display.dayReports[i]);
        }
        reportIndex = currentReport.value;
        string reportSelection = currentReport.options[reportIndex].text;
        activeReport = dict[reportSelection];
        int threatIndex = currentThreat.value;
        threatSelection = currentThreat.options[threatIndex].text;
        int typeIndex = currentType.value;
        typeSelection = currentType.options[typeIndex].text;
    }

    public void GetDropdownReport() 
    {
        reportIndex = currentReport.value;
        string reportSelection = currentReport.options[reportIndex].text;
        activeReport = dict[reportSelection];

        Debug.Log(reportIndex);
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
        if (currentReport.options.Count > 0)
        {
            if (activeReport.threat == threatSelection && activeReport.type == typeSelection)
            {
                submission = true;
                Debug.Log("Correct Answer!");

                Destroy(display.createdDuplicates[reportIndex]);
                display.createdDuplicates.RemoveAt(reportIndex);

                currentReport.options.RemoveAt(reportIndex);
                currentReport.value = 0; // Reset to the first option or handle as needed
                currentReport.RefreshShownValue();
            }
            else
            {
                submission = false;
                Debug.Log("Incorrect Answer!");

                notifSystem.sendIncorrectNotif();

                GameObject.Destroy(display.createdDuplicates[reportIndex]);
                display.createdDuplicates.RemoveAt(reportIndex);

                currentReport.options.RemoveAt(reportIndex);
                currentReport.value = 0; // Reset to the first option or handle as needed
                currentReport.RefreshShownValue();

            }
        }
    }

    public void Update()
    {
         if (!spawnFinalPopup && currentReport.options.Count == 0)
        {
                spawnFinalPopup = true;
                notifSystem.sendFinalNotif();

         }
    }

}
