using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class WindowScript : MonoBehaviour
{
    //Scaling Variables
    //baseScale - Original intended size of window
    public float baseScaleX, baseScaleY;
    //Target Scales - baseScale/10, used to minimize to icon on taskbar
    public float targetScaleX, targetScaleY;
    public Vector3 baseScale, targetScale;

    public bool grabbed;
    public float grabbedScaleX, grabbedScaleY;
    public Vector3 grabbedScale;

    //Position Variables
    //basePos - Position before minimizing, not origin
    public float basePosX, basePosY;
    //Target Pos - intended position when minimizing - WILL EVENTUALLY BE REPLACED WITH TASKBAR OBJECT AND LIST
    public float targetPosX, targetPosY;
    public Vector3 basePos, targetPos;
    //LockPos - used to keep position before minimizing in pPos and basePos
    bool lockPos;
    public GameObject windowHeader,buttonsInHeader;

    //Minimize Button Variables
    public Button mimizeButton;
    public bool pressed;
    public float timeLerped = 1;
    public float speed;

    //Close Button Variables
    public Button closeButton;
    public bool isPopup;

    //Misc
    public TextMeshProUGUI windowNameTMP;
    public string windowName;
    public bool requiresInternet;
    public GameObject internet;
    public GameObject noInternet;
    public AudioScript audioManager;

    //Sorting Layer Variables
    public GameObject background, shadow,content,contentCanvas,border,secondCanvas;
    public int headerLayer, backgroundLayer, shadowLayer, contentLayers;
    public int posInArray;
    public bool priority;
    public SortingGroup sortingGroup;
    //change to require WindowLayerManagement
    public GameObject manager;

    //Taskbar Stuff
    public GameObject taskBarManager;

    //Desktop Icon Stuff
    public GameObject desktopIcon;
    public Image icon;
    //make this to where desktop icon gives icon to window

    void Start()
    {
        //Defining original, intended scale of window
        //baseScaleX = transform.localScale.x;
        //baseScaleY = transform.localScale.y;
        baseScale = new Vector3(baseScaleX, baseScaleY, transform.localScale.z);
        //Defining scale of minimized window
        targetScaleX = baseScaleX / 10;
        targetScaleY = baseScaleY / 10;
        targetScale = new Vector3(targetScaleX, targetScaleY, transform.localScale.z);
        //Defining scale of grabbed window;
        grabbedScaleX = baseScaleX * 1.01f;
        grabbedScaleY = baseScaleY * 1.01f;
        grabbedScale = new Vector3(grabbedScaleX, grabbedScaleY, transform.localScale.z);
        
        //Setting Managers
        manager = GameObject.Find("WindowLayerManager");
        manager.GetComponent<WindowLayerManagement>().windowSortList.Add(this.gameObject);
        taskBarManager = GameObject.Find("WindowLayerManager");
        taskBarManager.GetComponent<CheckIfOpen>().windowList.Add(this.gameObject);

        //Setting Window Name
        windowNameTMP.text = windowName;

        audioManager = GameObject.Find("AudioManager").GetComponent<AudioScript>();
    }
    
    void Update()
    {
        if (Time.timeScale != 0)
        {
            //Sorting Layer
            sortingGroup.sortingOrder = posInArray * 10;
            headerLayer = 3 + sortingGroup.sortingOrder;
            backgroundLayer = 1 + sortingGroup.sortingOrder;
            shadowLayer = 0 + sortingGroup.sortingOrder;
            contentLayers = 2 + sortingGroup.sortingOrder;

            if (desktopIcon != null)
            {
                if (desktopIcon.activeSelf == false)
                {
                    this.gameObject.SetActive(false);
                }
            }

            if (internet != null)
            {
                if (requiresInternet && internet.GetComponent<InternetScript>().on == false)
                {
                    content.SetActive(false);
                    contentCanvas.SetActive(false);
                    noInternet.SetActive(true);
                }
                if (internet.GetComponent<InternetScript>().on == true)
                {
                    content.SetActive(true);
                    contentCanvas.SetActive(true);
                    noInternet.SetActive(false);
                }
            }

            //Apply layer change
            windowHeader.GetComponent<SpriteRenderer>().sortingOrder = headerLayer;
            buttonsInHeader.GetComponent<Canvas>().sortingOrder = headerLayer;
            background.GetComponent<SpriteRenderer>().sortingOrder = backgroundLayer;
            shadow.GetComponent<SpriteRenderer>().sortingOrder = shadowLayer;
            content.GetComponent<SortingGroup>().sortingOrder = contentLayers;
            contentCanvas.GetComponent<Canvas>().sortingOrder = contentLayers;
            noInternet.GetComponent<SpriteRenderer>().sortingOrder = contentLayers;
            if (border != null)
            {
                border.GetComponent<SpriteRenderer>().sortingOrder = headerLayer;
            }
            if (secondCanvas != null)
            {
                secondCanvas.GetComponent<Canvas>().sortingOrder = contentLayers;
            }

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
                grabbed = false;
                //Scale down and move to icon position
                transform.localScale = Vector3.MoveTowards(baseScale, targetScale, speed * timeLerped);
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
                //Grabbed bool is here for edge-case related reasons. Just duplicate any changes.
                if (grabbed)
                {
                    transform.localScale = grabbedScale;
                    if (lockPos)
                    {
                        transform.localPosition = Vector3.MoveTowards(targetPos, basePos, speed * timeLerped);
                    }
                    //If one second has passed, lock the movement of the window via drag.  Else, add to timer.
                    if (timeLerped >= .5f)
                    {
                        lockPos = false;
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
                    if (timeLerped >= .5f)
                    {
                        lockPos = false;
                    }
                    else
                    {
                        timeLerped += Time.deltaTime;
                    }
                }
            }
        }
    }

    public void minimizeButton()
    {
        if (Time.timeScale > 0)
        {
            //Set timeLerped to 1/speed, lock position recording, and swap pressed bool. Currently 1/10.
            timeLerped = .1f;
            lockPos = true;
            if (pressed)
            {
                audioManager.playsound(5);
            }
            else
            {
                audioManager.playsound(4);
            }
            pressed = !pressed;
            
        }
    }

    public void closeButtonScript()
    {
        if (Time.timeScale > 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void destroyInsteadOfDisable()
    {
        //Use this for popups to not just have them disable when closed
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    public void bringToFront()
    {
        if (Time.timeScale > 0)
        {
            priority = true;
        }
    }

    public void playsoundFromAudioGuy(int index)
    {
        audioManager.playsound(index);
    }
}
