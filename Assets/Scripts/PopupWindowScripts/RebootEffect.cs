using System.Collections;
using System.Data;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RebootEffect : MonoBehaviour
{
    GameObject ErrorT, BootT, LoadP, PL, LoadR, RL, LoadD, blackPanel;
    bool CR_Running;
    void Start()
    {
        blackPanel = GameObject.Find("BlackPanel");
        ErrorT = blackPanel.transform.GetChild(0).gameObject;
        BootT = blackPanel.transform.GetChild(1).gameObject;
        LoadP = blackPanel.transform.GetChild(2).gameObject;
        PL = blackPanel.transform.GetChild(3).gameObject;
        LoadR = blackPanel.transform.GetChild(4).gameObject;
        RL = blackPanel.transform.GetChild(5).gameObject;
        LoadD = blackPanel.transform.GetChild(6).gameObject;
    }
    public void startReboot()
    {
        if(!CR_Running)
        {
            StartCoroutine(Effect());
        }
    }

    //nightmare no time sorry
    IEnumerator Effect()
    {
        CR_Running = true;
        blackPanel.GetComponent<Image>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        yield return new WaitForSeconds(3f);
        ErrorT.SetActive(true);
        yield return new WaitForSeconds(1f);
        BootT.SetActive(true);
        yield return new WaitForSeconds(2f);
        LoadP.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        PL.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        LoadR.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        RL.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        LoadD.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        blackPanel.GetComponent<Image>().enabled = false;
        ErrorT.SetActive(false); BootT.SetActive(false); LoadP.SetActive(false); PL.SetActive(false); LoadR.SetActive(false); 
        RL.SetActive(false); LoadD.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        CR_Running = false;
        gameObject.SetActive(false);
        Invoke("destroyInsteadOfDisable", 0f);
    }

}
