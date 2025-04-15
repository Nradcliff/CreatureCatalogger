using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class RebootEffect : MonoBehaviour
{
    GameObject ErrorT, BootT, LoadP, PL, LoadR, RL, LoadD;
    public GameObject blackPanel;
    bool CR_Running;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ErrorT = blackPanel.transform.GetChild(0).gameObject;
        BootT = blackPanel.transform.GetChild(1).gameObject;
        LoadP = blackPanel.transform.GetChild(2).gameObject;
        PL = blackPanel.transform.GetChild(3).gameObject;
        LoadR = blackPanel.transform.GetChild(4).gameObject;
        RL = blackPanel.transform.GetChild(5).gameObject;
        LoadD = blackPanel.transform.GetChild(6).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void startReboot()
    {
        if(!CR_Running)
        {
            StartCoroutine(Effect());
        }
    }

    IEnumerator Effect()
    {
        CR_Running = true;
        blackPanel.SetActive(true);
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
        blackPanel.SetActive(false);
        CR_Running = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

}
