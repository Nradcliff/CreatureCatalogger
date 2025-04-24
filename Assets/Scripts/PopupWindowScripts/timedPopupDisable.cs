using System.Collections;
using TMPro;
using UnityEngine;


//Another time
public class timedPopupDisable : MonoBehaviour
{
    //public float time;
    public TextMeshProUGUI text;
    public GameObject[] buttons;

    WindowScript wScript;

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

    void Start ()
    {
        wScript = GetComponent<WindowScript>();
    }

    IEnumerator message()
    {
        text.text = "Thank you! :)";
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(false);
        }
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
        wScript.destroyInsteadOfDisable();
    }

    public void virusMessage()
    {
        StartCoroutine(message());
    }
}
