using UnityEngine;
using UnityEngine.UI;
using TMPro;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Rendering;

public class ReportDisplay : MonoBehaviour
{
    public ReportWindow[] reportArr; //Array for the resource folder of reports

    public List<ReportWindow> dayReports; //List for the current reports of the day
    public List<GameObject> createdDuplicates;

    public ProgramPersist program;

    public int reportAmount; // number of reports we want to generate
    public Transform parentTransform; //Transform of the parent that the buttons will become children of
    public GameObject reportButton; //Varible to store button prefab

    public TMP_Dropdown currentReport;

    public void Start()
    {
        program = GameObject.Find("LoadProgramManager").GetComponent<ProgramPersist>();
        currentReport.options.Clear();
        reportArr = Resources.LoadAll("Reports", typeof(ReportWindow)).Cast<ReportWindow>().ToArray(); //Loads all of the reports in resources folder into an array

        List<ReportWindow> tempReports = new List<ReportWindow>(); //A temp list to avoid duplicate reports when being selected

        reportAmount = reportAmount + (2 * program.DayNum);
        if(reportAmount > 69)
        {
            reportAmount = 69;
        }

        for (int i = 0; i < reportArr.Length; i++ ) //Copies the reports of the reportArr into this temporary list so we can avoid duplicate selections later
        {
            tempReports.Add(reportArr[i]);
        }
        

        for (int i = 0; i < reportAmount; i++) //Goes through and creates reports equal to the reportAmount that is set in the inspector
        {
            int randomIndex = Random.Range(0, tempReports.Count);
            if (program.reportDisallowedToAppear[tempReports[randomIndex].id] == false)
            {
                dayReports.Add(tempReports[randomIndex]);
                tempReports.RemoveAt(randomIndex);

                GameObject duplicate = Instantiate(reportButton, parentTransform); //creates a button as a child of the grid confines
                duplicate.name = "Report " + i; //Sets the name of the game object
                duplicate.GetComponent<SwitchTab>().report = dayReports[i]; //sets the button to the randomly selected/generated report
                duplicate.GetComponent<SwitchTab>().report.isUsed = true;


                // If you want to set the button's text, you can do it like this
                TMP_Text buttonText = duplicate.GetComponentInChildren<TMP_Text>();
                if (buttonText != null)
                {
                    buttonText.text = duplicate.GetComponent<SwitchTab>().report.name; //Sets the name of the creature as the report name
                }

                currentReport.options.Add(new TMP_Dropdown.OptionData(duplicate.GetComponent<SwitchTab>().report.name));

                createdDuplicates.Add(duplicate);
            }
            else
            {
                bool aaaaa = checkIfAll();
                if (aaaaa)
                {
                    program.reportDisallowedToAppear.Clear();
                    program.reportDisallowedToAppear.AddRange(Enumerable.Repeat(false, 69));
                }
                i--;
            }
        }

        program.totalReports = dayReports.Count;
        program.correctReports = 0;
    }

    public bool checkIfAll()
    {
        int numberofr = 0;
        for(int i = 0; i < 69; i++)
        {
            if(program.reportDisallowedToAppear[i] == false)
            {
                numberofr += 1;
            }
        }
        if(numberofr > reportAmount) {
            return false;
        }
        else
        {
            return true;
        }
    }
}
