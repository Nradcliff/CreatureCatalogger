using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SolverDropdown : MonoBehaviour
{
    public ReportDisplay reportManager;
    public List<ReportWindow> reportList;
    public TMP_Dropdown dropdown;
    bool checking;
    public float timer;
    public Button button;
    public TextMeshProUGUI displayResults;
    public PopupSpawnManageScript popMan;
    public Slider progressbar;
    public int chosenValue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < reportManager.dayReports.Count; i++)
        {
            reportList.Add(reportManager.dayReports[i]);
            dropdown.options.Add(new TMP_Dropdown.OptionData(reportManager.dayReports[i].name));
        }
    }

    // Update is called once per frame
    void Update()
    {
        chosenValue = dropdown.value;
        if (checking)
        {
            displayResults.text = "Checking...";
            if (Input.GetMouseButtonDown(0))
            {
                popMan.chancePopup(25);
            }

            button.interactable = false;
            dropdown.interactable = false;
            
            if (timer >= 70f)
            {
                timer = 0;
                checking = false;
                dropdown.interactable = true;
                button.interactable = true;
                //display results
                //Name:
                //Threat Level:
                //Type:
                string results = "Name: " + reportList[chosenValue].name + "\nThreat Level: " + reportList[chosenValue].threat + "\nType: " + reportList[chosenValue].type;
                displayResults.text = results;
            }
            else if (timer < .45f*60)
            {
                timer += Time.deltaTime * 1.75f;
            }
            else if ((timer > .45f * 60 && timer < .55f * 60) || timer > .90f * 60)
            {
                timer += Time.deltaTime * .5f;
            }
            else if (timer >= .55f || timer <= .90f * 60)
            {
                timer += Time.deltaTime * .65f;
            }
            progressbar.value = timer/70;
        }
    }

    private void OnDisable()
    {
        timer = 0;
        checking = false;
        dropdown.interactable = true;
        button.interactable = true;
        displayResults.text = "ERROR\nFunction Aborted\nExit Code 09FMBH2";
        progressbar.value = 0;
    }

    public void startCheck()
    {
        checking = true;
    }
}
