using TMPro;
using UnityEngine;

public class OpenWindowFromIcon : MonoBehaviour
{
    public GameObject AssignedWindow;
    public TextMeshProUGUI programName;
    public Sprite icon;

    public void Start()
    {
        programName.text = AssignedWindow.GetComponent<WindowScript>().windowName;
    }
    public void Update()
    {
        //AssignedWindow.GetComponent<WindowScript>().targetPosY = Camera.main.ScreenToWorldPoint(transform.position).y;
        //AssignedWindow.GetComponent<WindowScript>().targetPosX = Camera.main.ScreenToWorldPoint(transform.position).x;
        AssignedWindow.GetComponent<WindowScript>().targetPosY = this.transform.position.y;
        AssignedWindow.GetComponent<WindowScript>().targetPosX = this.transform.position.x;
    }

    public void openWindow()
    {
        if (AssignedWindow != null) {
            
            if (AssignedWindow.activeSelf == false)
            {
                AssignedWindow.SetActive(true);
                AssignedWindow.GetComponent<WindowScript>().pressed = false;
                AssignedWindow.GetComponent<WindowScript>().priority = true;
                AssignedWindow.transform.localScale = AssignedWindow.GetComponent<WindowScript>().baseScale;
                AssignedWindow.transform.position = AssignedWindow.GetComponent<WindowScript>().basePos;
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
