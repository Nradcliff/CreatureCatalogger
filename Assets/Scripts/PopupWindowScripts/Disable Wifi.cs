using UnityEngine;

public class DisableWifi : MonoBehaviour
{
    void Update()
    {
        
    }

    public void turnOffWifi()
    {
        InternetScript.timer = 999;
    }
}
