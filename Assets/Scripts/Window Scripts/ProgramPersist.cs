using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProgramPersist : MonoBehaviour
{
    public List<bool> programBool;
    public List<bool> startingProgramBool;
    public string notepadText;
    public int DayNum;
    public bool resetBools;
    public TextMeshProUGUI stickyNoteText;
    public string randPass;

    public int totalReports, correctReports;

    public bool noTimer;
    public float masterVol, sfxVol, ambienceVol;

    public bool dead;

    public void Start()
    {
        //Randomly generates a wifi password
        randPass = "";
        const string glyphs = "bcdfghjklmnpqrstvwxyz0123456789";
        for (int i = 0; i < 8; i++)
        {
            randPass += glyphs[UnityEngine.Random.Range(0, glyphs.Length)];
        }
        stickyNoteText.text = "Wifi Pass:\r\n   " + randPass;
    }

    public void Update()
    {
        if(resetBools == false)
        {
            programBool = new List<bool>(startingProgramBool);
            resetBools = true;
        }
    }

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
