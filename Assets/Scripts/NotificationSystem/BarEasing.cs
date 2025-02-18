using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class BarEasing : MonoBehaviour
{
    //Store original position of the bar (When it is open in scene)
    public float originPosX, originPosY;
    //Target position (taskbar position)
    float targetPosX, targetPosY;

    bool isOpen;

    //Possible UI elements with alpha values
    public GameObject[] alphaUIElements;

    void Start()
    {
        //Immedietly set the bar to be "closed"
        targetPosX = originPosX;
        targetPosY = -originPosY; //this should work
        this.gameObject.transform.position = new Vector3(targetPosX, targetPosY, this.gameObject.transform.position.z);
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void opencloseNotifications()
    {
        if (isOpen == false)
        {
            //Open the bar
            isOpen = true;
            this.gameObject.transform.position = new Vector3(originPosX, originPosY, this.gameObject.transform.position.z);
        }
        else
        {
            //Close the bar
            isOpen = false;
            this.gameObject.transform.position = new Vector3(targetPosX, targetPosY, this.gameObject.transform.position.z);
        }
    }
}
