using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
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
    public string randPass, UserTwelveFourteenPassword;

    public int totalReports, correctReports;

    public bool noTimer;
    public float masterVol, sfxVol, ambienceVol;

    public int backgroundIndex;

    public bool dead;

    public float totalTime;
    public int errorsMade;

    public void Start()
    {
        loadVol();
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

    public void SaveFile()
    {
        string destination = Application.persistentDataPath + "/PsyEmployee.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenWrite(destination);
        else file = File.Create(destination);

        SaveDays data = new SaveDays();
        data.saveCurrentData(programBool, notepadText, DayNum,backgroundIndex,totalTime,errorsMade);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, data);
        file.Close();
    }

    public bool LoadFile()
    {
        string destination = Application.persistentDataPath + "/PsyEmployee.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenRead(destination);
        else
        {
            Debug.LogError("File not found");
            return false;
        }

        BinaryFormatter bf = new BinaryFormatter();
        SaveDays data = (SaveDays)bf.Deserialize(file);
        file.Close();

        programBool = data.savedProgramBool;
        notepadText = data.savedNotepadText;
        DayNum = data.savedDayNumber;
        backgroundIndex = data.savedImage;
        errorsMade = data.savedErrors;
        totalTime = data.savedTime;
        return true;
    }

    public void clearData()
    {
        string destination = Application.persistentDataPath + "/PsyEmployee.dat";

        if (File.Exists(destination)) File.Delete(destination);

        programBool = startingProgramBool;
        notepadText = string.Empty;
        DayNum = 0;
        backgroundIndex = 0;
    }

    public void saveVol()
    {
        string destination = Application.persistentDataPath + "/PsyEmployeeSystemSettings.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenWrite(destination);
        else file = File.Create(destination);

        SaveAudio data = new SaveAudio();
        data.saveCurrentData(masterVol,sfxVol,ambienceVol);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, data);
        file.Close();
    }
    public bool loadVol()
    {
        string destination = Application.persistentDataPath + "/PsyEmployeeSystemSettings.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenRead(destination);
        else
        {
            Debug.LogError("File not found");
            return false;
        }

        BinaryFormatter bf = new BinaryFormatter();
        SaveAudio data = (SaveAudio)bf.Deserialize(file);
        file.Close();

        masterVol = data.smasterVol;
        sfxVol = data.ssfxVol;
        ambienceVol = data.sambienceVol;
        return true;
    }
}
