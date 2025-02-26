using UnityEngine;

public class MenuEasing : MonoBehaviour
{
    public float targetOpenPos,targetClosedPos;
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

    void Update()
    {
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
