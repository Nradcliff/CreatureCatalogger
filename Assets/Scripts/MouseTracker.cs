using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseTracker : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        this.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = new Vector3(transform.position.x, transform.position.y, 1);
    }
}
