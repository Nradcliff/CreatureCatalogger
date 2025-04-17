using UnityEngine;
using TMPro;
using System.Data;
using UnityEngine.UI;
using System.Collections;

public class AntivirusScriptG : MonoBehaviour
{
    public TextMeshProUGUI enableText;
    public TextMeshProUGUI countDisplay;
    public Button closeButton;
    public TextMeshProUGUI ButtonText;
    bool CR_Running;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        countDisplay.text = null;
        ButtonText = GameObject.Find("EnableBut").GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void disablePopups()
    {
        if (PopupSpawnManageScript.allowPopups == false)
        {
            enableText.text = "Antivirus currently disabled.";
            ButtonText.text = "Enable";
            PopupSpawnManageScript.allowPopups = true;
            closeButton.enabled = true;
        }
        else
        {
            enableText.text = "Antivirus currently enabled.";
            ButtonText.text = "Disable";
            PopupSpawnManageScript.allowPopups = false;
            closeButton.enabled = false;
        }
    }

    //General use
    int findActivePopups()
    {
        GameObject[] popupCount = GameObject.FindGameObjectsWithTag("Popup");
        return popupCount.Length;
    }

    public void updatePopupCount()
    {
        if (!CR_Running)
        {
            countDisplay.text = findActivePopups().ToString() + " Viruses Detected";
            StartCoroutine(resetText());
        }
    }

    //Need for above function
    IEnumerator resetText()
    {
        CR_Running = true;
        yield return new WaitForSeconds(3f);
        countDisplay.text = null;
        CR_Running = false;
    }

    /*public void deleteAllPopups()
    {
        GameObject[] popups = GameObject.FindGameObjectsWithTag("Popup");
        foreach (GameObject popup in popups)
        {
            Destroy(popup);
        }
    }*/
}
