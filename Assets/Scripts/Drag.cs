using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]

public class Drag : MonoBehaviour
{

    private Vector3 screenPoint;
    private Vector3 offset;
    public GameObject windowSelf;

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        windowSelf.GetComponent<WindowScript>().priority = true;
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;

    }

}