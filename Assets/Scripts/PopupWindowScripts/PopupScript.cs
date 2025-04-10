using System.Collections;
using UnityEngine;

//This script contains functions for popups
public class PopupScript : MonoBehaviour
{
    int count;

    void Start()
    {

    }

    public void turnOffWifi()
    {
        InternetScript.timerTarget = 0;
    }

    public void respawnSelf()
    {
        count = 0;
        if (count <= 3)
        {
            Instantiate(this.gameObject);
            count++;
        }
    }

    public void enableFade()
    {
        StartCoroutine(enablesFade());
    }

    IEnumerator enablesFade()
    {
        GameObject obj = GameObject.Find("FadePanel");
        obj.SetActive(true);
        yield return new WaitForSeconds(3f);
        obj.SetActive(false);
    }
}