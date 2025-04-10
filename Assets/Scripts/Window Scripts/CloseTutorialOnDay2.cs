using UnityEngine;

public class CloseTutorialOnDay2 : MonoBehaviour
{
    public ProgramPersist persist;
    void Start()
    {
        persist = GameObject.Find("LoadProgramManager").GetComponent<ProgramPersist>();
        if(persist.DayNum > 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
