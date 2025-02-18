using UnityEngine;

public class StartMenuClickDetect : MonoBehaviour
{
    public GameObject personalizeWindow;
    void Update()
    {
        HideIfClickedOutside(this.gameObject);
    }

    private void HideIfClickedOutside(GameObject panel)
    {
        if (Input.GetMouseButton(0) && panel.activeSelf &&
            !RectTransformUtility.RectangleContainsScreenPoint(
                panel.GetComponent<RectTransform>(),
                Input.mousePosition,
                null))
        {
            panel.SetActive(false);
        }
    }
    
    public void openPersonalize()
    {
        personalizeWindow.SetActive(true);
    }
}
