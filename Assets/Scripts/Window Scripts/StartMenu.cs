using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public GameObject startPanel;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startBool()
    {
        startPanel.SetActive(!startPanel.activeSelf);
    }
}
