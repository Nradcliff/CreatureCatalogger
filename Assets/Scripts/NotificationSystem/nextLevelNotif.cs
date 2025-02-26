using UnityEngine;

public class nextLevelNotif : MonoBehaviour
{
    public GameObject levelManager;
    void Start()
    {
        levelManager = GameObject.Find("LevelManager");
    }

    void Update()
    {
        
    }
    public void buttonToGoToNextDay()
    {
        levelManager.GetComponent<FadeForMainLevel>().nextLevel();
    }
}
