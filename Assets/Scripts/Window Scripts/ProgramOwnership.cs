using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ProgramOwnership : MonoBehaviour
{
    public List<GameObject> programs; //List of desktop icons for programs; disabling a desktop icon disables the window completely
    public ProgramPersist saveLoadThingy;

    public void Start()
    {
        saveLoadThingy = GameObject.Find("LoadProgramManager").GetComponent<ProgramPersist>();
        if (saveLoadThingy.programBool.Count > 0)
        {
            saveLoadThingy.loadBoolData(programs);
        }
        else
        {
            for (int i = 0; i < programs.Count; i++)
            {
                saveLoadThingy.programBool.Add(false);
                saveLoadThingy.programBool[i] = programs[i].activeSelf;
            }
        }
    }
    public void Update()
    {
        
    }

    public void grantProgram(int index)
    {
        programs[index].SetActive(true);
        saveLoadThingy.saveBoolData(programs);
        //port over taskbar stuff for icons
    }
    public void revokeProgram(int index)
    {
        programs[index].SetActive(false);
        saveLoadThingy.saveBoolData(programs);
    }
}
