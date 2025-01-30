using UnityEngine;

public class OpenWindowFromIcon : MonoBehaviour
{
    public GameObject AssignedWindow;
    public Sprite icon;

    public void Start()
    {
        AssignedWindow.GetComponent<WindowScript>().targetPosX = this.transform.position.x;
        AssignedWindow.GetComponent<WindowScript>().targetPosY = this.transform.position.y;
    }
    public void openWindow()
    {
        if (AssignedWindow != null) {
            
            if (AssignedWindow.activeSelf == false)
            {
                AssignedWindow.SetActive(true);
                AssignedWindow.GetComponent<WindowScript>().pressed = false;
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
