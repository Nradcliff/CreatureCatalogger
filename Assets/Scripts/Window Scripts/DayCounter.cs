using TMPro;
using UnityEngine;

public class DayCounter : MonoBehaviour
{
    public ProgramPersist persist;
    public TextMeshProUGUI text;
    void Start()
    {
        persist = GameObject.Find("LoadProgramManager").GetComponent<ProgramPersist>();
        text.text = "Day " + (persist.DayNum+1).ToString();
    }
}
