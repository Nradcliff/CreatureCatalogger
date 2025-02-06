using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Drag : MonoBehaviour
{

    private Vector3 screenPoint;
    private Vector3 offset;
    public GameObject windowSelf;

    void OnMouseDown()
    {
        //For the life of me I cannot get this to account for blocking raycasts.
        //If you somehow can figure this out then you are my savior. - Gibby

        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        windowSelf.GetComponent<WindowScript>().grabbed = true;

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        windowSelf.GetComponent<WindowScript>().priority = true;
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;

    }

    private void OnMouseUp()
    {
        windowSelf.GetComponent<WindowScript>().grabbed = false;
    }

}