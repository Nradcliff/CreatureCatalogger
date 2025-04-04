using UnityEngine;

public class DropdownSortingLayerFix : MonoBehaviour
{

    public WindowScript parentWindow;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnEnable()
    {
        
    }

    public void Update()
    {
        Canvas canvas = GetComponent<Canvas>();
        GameObject.Find("Blocker");
        if (canvas)
        {
            canvas.sortingOrder = parentWindow.contentLayers + 2;
        }
    }
}
