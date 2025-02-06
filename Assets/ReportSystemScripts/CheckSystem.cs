using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheckSystem : MonoBehaviour
{
    public TMP_Dropdown currentReport;
    public ReportDisplay DayStuff;

    public TMP_Dropdown currentThreat;
    public TMP_Dropdown currentType;


   public void GetDropdownValue()
    {
        



        int pickedEntryIndex = currentThreat.value;
        string selectedOption = currentThreat.options[pickedEntryIndex].text;

        int pickedEntryIndex2 = currentType.value;
        string selectedOption2 = currentType.options[pickedEntryIndex].text;


        Debug.Log(selectedOption);
    }
   public void CheckComparison()
    {
        
    }

}
