using System.Collections;
using TMPro;
using UnityEngine;


//Another time
public class timedPopupDisable : MonoBehaviour
{
    //public float time;
    public TextMeshProUGUI text;
    public GameObject[] buttons;

    //public static bool timedPopupRunning;

    /*public void timedPopup()
    {
        StartCoroutine(disable());
    }*/

    /*IEnumerator disable()
    {
        if (PopupSpawnManageScript.allowPopups == true)
        {
            timedPopupRunning = true;
            PopupSpawnManageScript.allowPopups = false;
            yield return new WaitForSeconds(time);
            PopupSpawnManageScript.allowPopups = true;
            timedPopupRunning = false;
            gameObject.SetActive(false);
            Invoke("closeButtonScript", 0f);
        }
        
    }*/

    IEnumerator message()
    {
        text.text = "Thank you! :)";
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(false);
        }
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
        Invoke("destroyInsteadOfDisable", 0f);
    }

    public void virusMessage()
    {
        StartCoroutine(message());
    }
}
