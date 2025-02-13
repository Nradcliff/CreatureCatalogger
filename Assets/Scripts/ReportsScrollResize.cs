using TMPro;
using UnityEngine;

public class ReportsScrollResize : MonoBehaviour
{
    //THIS SUCKS BUT IT WORKS I HATE UNITY

    public TextMeshProUGUI textplace;
    public int reportsNum;
    public string resizeString;

    void Update()
    {
        resizeString = new string('A',reportsNum);
        textplace.text = resizeString;
    }
}
