using UnityEngine;

public class StartMenuClickDetect : MonoBehaviour
{
    public GameObject personalizeWindow;
    public GameObject pausePanel;
    void Update()
    {
        HideIfClickedOutside(this.gameObject);
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
                panel.SetActive(false);
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
}
