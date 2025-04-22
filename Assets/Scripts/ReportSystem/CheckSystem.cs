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
    public ProgramPersist progressTracker;

    //Additions for Notification System
    public NotificationScript notifSystem;
    bool spawnFinalPopup;

    public void Start()
    {
        progressTracker = GameObject.Find("LoadProgramManager").GetComponent<ProgramPersist>();
        for (int i = 0; i < display.dayReports.Count; i++) //Copies the reports of the reportArr into this temporary list so we can avoid duplicate selections later
        {
            dict.Add(display.dayReports[i].name, display.dayReports[i]);
        }
        GetDropdownReport();
        GetDropdownThreatValue();
        GetDropdownTypeValue();
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
            if (activeReport.threat.ToString() == threatSelection && activeReport.type.ToString() == typeSelection)
            {
                submission = true;
                Debug.Log("Correct Answer!");

                progressTracker.correctReports += 2;

                Destroy(display.createdDuplicates[reportIndex]);
                display.createdDuplicates.RemoveAt(reportIndex);

                currentReport.options.RemoveAt(reportIndex);
                currentReport.value = 0; // Reset to the first option or handle as needed
                currentReport.RefreshShownValue();
                if (currentReport.options.Count >= 1)
                {
                    GetDropdownReport();
                    GetDropdownThreatValue();
                    GetDropdownTypeValue();
                }
            }
            else
            {
                submission = false;
                Debug.Log("Incorrect Answer!");

                if(activeReport.threat.ToString() != threatSelection && activeReport.type.ToString() == typeSelection)
                {
                    notifSystem.sendIncorrectTLNotif();
                    progressTracker.correctReports += 1;
                    progressTracker.errorsMade += 1;
                }
                else if (activeReport.type.ToString() != typeSelection && activeReport.threat.ToString() == threatSelection)
                {
                    notifSystem.sendIncorrectTypeNotif();
                    progressTracker.correctReports += 1;
                    progressTracker.errorsMade += 1;
                }
                else
                {
                    notifSystem.sendIncorrectTLTypeNotif();
                    progressTracker.errorsMade += 2;
                }
                GameObject.Destroy(display.createdDuplicates[reportIndex]);
                display.createdDuplicates.RemoveAt(reportIndex);

                currentReport.options.RemoveAt(reportIndex);
                currentReport.value = 0; // Reset to the first option or handle as needed
                currentReport.RefreshShownValue();
                if (currentReport.options.Count > 1)
                {
                    GetDropdownReport();
                    GetDropdownThreatValue();
                    GetDropdownTypeValue();
                }

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
