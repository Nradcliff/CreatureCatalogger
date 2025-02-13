using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ProgramOwnership : MonoBehaviour
{
    public List<GameObject> programs; //List of desktop icons for programs; disabling a desktop icon disables the window completely

    public void Start()
    {
        
    }
    public void Update()
    {
        
    }

    public void grantProgram(int index)
    {
        programs[index].SetActive(true);
        //port over taskbar stuff for icons
    }
    public void revokeProgram(int index)
    {
        programs[index].SetActive(false);
    }
}
