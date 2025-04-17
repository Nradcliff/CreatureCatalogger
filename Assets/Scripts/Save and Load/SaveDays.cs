using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveDays
{
    public List<bool> savedProgramBool;
    public string savedNotepadText;
    public int savedDayNumber;
    public int savedImage;
    public void saveCurrentData(List<bool> boolList, string text, int dayNum,int img)
    {
        savedProgramBool = boolList;
        savedNotepadText = text;
        savedDayNumber = dayNum;
        savedImage = img;
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
}
