using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CheckIfOpen : MonoBehaviour
{
    public List<GameObject> windowList, openList;
    public List<Button> buttonList;
    public GameObject var, panel;
    public Button addButton;
    public int programsOpen;

    public void Update()
    {
        programsOpen = openList.Count;
        //Check for open windows not already added to the list. Add a taskbar icon for opened windows.
        //If a window is closed, remove it.
        for (int i = 0; i < windowList.Count; i++)
        {
            if (windowList[i].activeSelf == true && !openList.Contains(windowList[i]))
            {
                //Add icon to taskbar
                openList.Add(windowList[i]);
                if (windowList[i].GetComponent<WindowScript>().isPopup == false)
                {
                    AddIconToTaskbar(windowList[i]);
                }
            }
            else if(windowList[i].activeSelf == false && openList.Contains(windowList[i]))
            {
                var close = windowList[i];
                openList.Remove(windowList[i]);
                if(close.GetComponent<WindowScript>().isPopup == true){
                    windowList.Remove(windowList[i]);
                    Destroy(close);
                 }
            }
        }
        //Remove taskbar button for closed windows.
        for(int i = 0; i < buttonList.Count;i++)
        {
            if (buttonList[i].GetComponent<OpenWindowFromIcon>().AssignedWindow.activeSelf == false)
            {
                Destroy(buttonList[i].gameObject);
                buttonList.RemoveAt(i);
            }
        }
    }

    //Buttons representing each program is added to a list and then a grid layout group
    public void AddIconToTaskbar(GameObject windowForButton)
    {
        Button buttonToAdd;
        buttonToAdd = Instantiate(addButton,panel.transform);
        buttonToAdd.GetComponent<OpenWindowFromIcon>().AssignedWindow = windowForButton;
        buttonList.Add(buttonToAdd);
        panel.GetComponent<GridLayoutGroup>().enabled = false;
        panel.GetComponent <GridLayoutGroup>().enabled = true;
    }
}
