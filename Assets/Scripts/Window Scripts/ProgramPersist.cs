using System.Collections.Generic;
using UnityEngine;

public class ProgramPersist : MonoBehaviour
{
    public List<bool> programBool;
    public string notepadText;
    public int DayNum;

    //This saves active programs throughout days
    //Could also add this to work with a notepad doc
    //This should be reset when new game is started

    public void saveBoolData(List<GameObject> goList)
    {
        for(int i = 0; i < goList.Count; i++)
        {
            programBool[i] = goList[i].activeSelf;
        }
    }
    public void loadBoolData(List<GameObject> goList)
    {
        for (int i = 0; i < goList.Count; i++)
        {
            goList[i].SetActive(programBool[i]);
        }
    }

}
