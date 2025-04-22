using UnityEngine;
using TMPro;
using System.Data;
using UnityEngine.UI;
using System.Collections;
using NUnit.Framework;

public class AntivirusScript : MonoBehaviour
{
    public TextMeshProUGUI enableText;
    public TextMeshProUGUI countDisplay;
    public Button closeButton;
    public TextMeshProUGUI ButtonText;
    bool CR_Running;

    PopupSpawnManageScript popupmanager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        countDisplay.text = null;
        ButtonText = GameObject.Find("EnableBut").GetComponentInChildren<TextMeshProUGUI>();
        popupmanager = GameObject.Find("PopupsManager").GetComponent<PopupSpawnManageScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PopupSpawnManageScript.allowPopups)
            print("popups allowed");
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

    //General use [FOR FUTURE, PUT ALL ACTIVE POPUPS INTO AN ARRAY FOR REFERENCING INSTEAD OF USING TAGS]
    //ok done
    int findActivePopups()
    {
        return popupmanager.activePopups.Count;
    }

    public void destroyAllPopups()
    {
        for (int i = 0; i < popupmanager.activePopups.Count; i++)
        {
            popupmanager.activePopups[i].SetActive(false);
            Destroy(popupmanager.activePopups[i]);
            popupmanager.activePopups.Remove(popupmanager.activePopups[i]);
        }

        /*foreach (GameObject popup in popupmanager.activePopups)
        {
            WindowScript T = popup.GetComponent<WindowScript>();
            T.destroyInsteadOfDisable();
            /*popup.SetActive(false);
            Destroy(popup);
            popupmanager.activePopups.Remove(popup);
        }*/
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
