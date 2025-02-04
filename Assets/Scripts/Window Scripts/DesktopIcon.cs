using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DesktopIcon : MonoBehaviour
{
    public GameObject AssignedWindow;
    public Button selfButton;
    public TextMeshProUGUI nameOnIcon;

    public string ProgramName;
    public Image icon;

    public int clickCount;

    public float timeToOpen;

    public void Start()
    {
        ProgramName = AssignedWindow.GetComponent<WindowScript>().windowName;
        nameOnIcon.text = ProgramName;
    }

    public void Update()
    {
        if(timeToOpen < 1)
        {
            timeToOpen += Time.deltaTime;
        }
        else
        {
            clickCount = 0;
        }
    }

    public void checkForOpen()
    {
        if(clickCount >= 1)
        {
            clickCount = 0;
            openWindowfromDesktop();
        }
        else if (clickCount < 1)
        {
            timeToOpen = 0;
            clickCount++;
        }
    }

    public void openWindowfromDesktop()
    {
        if (AssignedWindow != null)
        {

            if (AssignedWindow.activeSelf == false)
            {
                AssignedWindow.SetActive(true);
                AssignedWindow.GetComponent<WindowScript>().pressed = false;
                AssignedWindow.GetComponent<WindowScript>().priority = true;
                AssignedWindow.transform.localScale = AssignedWindow.GetComponent<WindowScript>().baseScale;
                AssignedWindow.transform.position = AssignedWindow.GetComponent<WindowScript>().basePos;
                //Add icon to taskbar     - done in another script
            }
            else
            {
                //Set window to highest priority in list
                AssignedWindow.GetComponent<WindowScript>().priority = true;
                if (AssignedWindow.GetComponent<WindowScript>().pressed)
                {
                    AssignedWindow.GetComponent<WindowScript>().minimizeButton();
                }
            }

        }
    }
}
