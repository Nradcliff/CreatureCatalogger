using UnityEngine;

public class StartMenuClickDetect : MonoBehaviour
{
    public GameObject personalizeWindow;
    public GameObject pausePanel;

    public bool pauseOnEsc;
    void Update()
    {
        //commented out for MainLevel 2 Scene to test scaling and the UI overlay
        //god unity sucks sometimes
        //HideIfClickedOutside(this.gameObject);
        if (isOpen)
        {
            positionFor.y = targetOpenPos;
            this.transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, positionFor, speed * Time.deltaTime);
        }
        else if (!isOpen)
        {
            positionFor.y = targetClosedPos;
            this.transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, positionFor, speed * Time.deltaTime);
        }
        if(pauseOnEsc && Input.GetKeyUp(KeyCode.Escape))
        {
            opencloseNotifications();
        }
    }

    private void HideIfClickedOutside(GameObject panel)
    {
        if (Time.timeScale > 0)
        {
            if (Input.GetMouseButton(0) && panel.activeSelf &&
                !RectTransformUtility.RectangleContainsScreenPoint(
                    panel.GetComponent<RectTransform>(),
                    Input.mousePosition,
                    null))
            {
                isOpen = false;
            }
        }
    }
    
    public void openPersonalize()
    {
        personalizeWindow.SetActive(true);
    }

    public void pauseGame()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }
    }
    public float targetOpenPos, targetClosedPos;
    Vector3 positionFor;
    public float speed;

    public bool isOpen;
    void Start()
    {
        positionFor.x = this.transform.localPosition.x;
        positionFor.z = 0;
        positionFor.y = targetClosedPos;
        isOpen = false;
    }

    public void opencloseNotifications()
    {
        if (isOpen == false)
        {
            isOpen = true;
        }
        else
        {
            isOpen = false;
        }
    }
}
