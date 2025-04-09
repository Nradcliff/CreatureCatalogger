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
        Canvas blocker = null;
        if (GameObject.Find("Blocker"))
        {
            blocker = GameObject.Find("Blocker").GetComponent<Canvas>();
        }
        if (canvas)
        {
            canvas.sortingOrder = parentWindow.contentLayers + 2;
            if (blocker != null)
            {
                blocker.sortingOrder = parentWindow.contentLayers + 1;
            }
        }
    }
}
