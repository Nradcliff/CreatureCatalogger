using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveDays
{
    public List<bool> savedProgramBool;
    public string savedNotepadText;
    public int savedDayNumber;

    public void saveCurrentData(List<bool> boolList, string text, int dayNum)
    {
        savedProgramBool = boolList;
        savedNotepadText = text;
        savedDayNumber = dayNum;
    }

    public List<bool> loadPrograms()
    {
        return savedProgramBool;
    }
    public string loadText()
    {
        return savedNotepadText;
    }
    public int loadDay()
    {
        return savedDayNumber;
    }

    public void resetData()
    {
        savedProgramBool.Clear();
        savedNotepadText = "";
        savedDayNumber = 0;
    }
}
