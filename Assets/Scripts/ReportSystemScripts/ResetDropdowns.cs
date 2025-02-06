using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class ResetDropdowns : MonoBehaviour
{
    public GameObject option, threat, type;
    //currently this uses GetComponent which is probably less efficient overall
    public void ReportSubmittedSoWeResetTheDropdownsToValueZeroWhichWeCanChangeTheMeaningOfAtALaterDateIThink()
    {
        option.GetComponent<TMP_Dropdown>().value = 0;
        threat.GetComponent<TMP_Dropdown>().value = 0;
        type.GetComponent<TMP_Dropdown>().value = 0;
    }
}
