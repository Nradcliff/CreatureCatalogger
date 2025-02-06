using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheckSystem : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;

   public void GetDropdownValue()
    {
        int pickedEntryIndex = dropdown.value;
        string selectedOption = dropdown.options[pickedEntryIndex].text;


        Debug.Log(selectedOption);
    }
   public void CheckComparison()
    {
   
    }

}
