using UnityEditor.ShaderGraph.Serialization;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.UI;

public class WindowScript : MonoBehaviour
{
    //Scaling Variables
    //baseScale - Original intended size of window
    public float baseScaleX, baseScaleY;
    //Target Scales - baseScale/10, used to minimize to icon on taskbar
    public float targetScaleX, targetScaleY;
    public Vector3 baseScale, targetScale;

    //Position Variables
    //basePos - Position before minimizing, not origin
    public float basePosX, basePosY;
    //Target Pos - intended position when minimizing - WILL EVENTUALLY BE REPLACED WITH TASKBAR OBJECT AND LIST
    public float targetPosX, targetPosY;
    public Vector3 basePos, targetPos;
    //LockPos - used to keep position before minimizing in pPos and basePos
    bool lockPos;

    //Minimize Button Variables
    public Button mimizeButton;
    public bool pressed;
    public float timeLerped = 1;
    public float speed;


    void Start()
    {
        //Defining original, intended scale of window
        baseScaleX = transform.localScale.x;
        baseScaleY = transform.localScale.y;
        baseScale = new Vector3(baseScaleX, baseScaleY, transform.localScale.z);
        //Defining scale of minimized window
        targetScaleX = baseScaleX / 10;
        targetScaleY = baseScaleY / 10;
        targetScale = new Vector3(targetScaleX, targetScaleY, transform.localScale.z);
    }
    
    void Update()
    {
        //If not currently being minimized or unminimized
        if (!pressed && !lockPos)
        {
            //Record current position x and y
            basePosX = transform.localPosition.x;
            basePosY = transform.localPosition.y;
        }
        //Defining icon and current positions
        targetPos = new Vector3(targetPosX, targetPosY, transform.localPosition.z);
        basePos = new Vector3(basePosX, basePosY, transform.localPosition.z);

        //If minimizing
        if (pressed)
        {
            //Scale down and move to icon position
            transform.localScale = Vector3.MoveTowards(baseScale, targetScale, speed*timeLerped);
            if (lockPos)
            {
                transform.localPosition = Vector3.MoveTowards(basePos, targetPos, speed * timeLerped);
            }
            //If one second has passed, do nothing. Else, add to timer.
            if (timeLerped >= 1)
            {
            }
            else
            {
                timeLerped += Time.deltaTime;
            }
        }
        else
        {
            //Scale up and move to last position
            transform.localScale = Vector3.MoveTowards(targetScale, baseScale, speed * timeLerped);
            if (lockPos)
            {
                transform.localPosition = Vector3.MoveTowards(targetPos, basePos, speed * timeLerped);
            }
            //If one second has passed, lock the movement of the window via drag.  Else, add to timer.
            if (timeLerped >= 1)
            {
                lockPos = false;
            }
            else
            {
                timeLerped += Time.deltaTime;
            }
        }
    }

    public void minimizeButton()
    {
        //Set timeLerped to 1/speed, lock position recording, and swap pressed bool. Currently 1/10.
        timeLerped = .1f;
        lockPos = true;
        pressed = !pressed;
    }
}
