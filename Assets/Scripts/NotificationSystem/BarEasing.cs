using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class BarEasing : MonoBehaviour
{
    public Vector3 originPos;
    Vector3 targetPos;
    public float speed;

    public TextMeshProUGUI barHeader;
    bool isOpen;

    void Start()
    {
        //Immedietly set the bar to be "closed"
        targetPos = new Vector3(originPos.x, -originPos.y, originPos.z);
        this.gameObject.transform.position = targetPos;
        isOpen = false;
        barHeader.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, originPos, speed * Time.deltaTime);
        }
        else if (!isOpen)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, targetPos, speed * Time.deltaTime);
        }
    }

    public void opencloseNotifications()
    {
        if (isOpen == false)
        {
            isOpen = true;
            barHeader.alpha = 1;
        }
        else
        {
            isOpen = false;
            barHeader.alpha = 0;
        }
    }
}
