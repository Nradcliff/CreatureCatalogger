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

    public GameObject popupCleanUpButton;
    public static bool upgraded;

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
        if (upgraded)
            popupCleanUpButton.SetActive(true);
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
        foreach (GameObject popup in popupmanager.activePopups)
        {
            popup.SetActive(false);
            Destroy(popup);
        }
        popupmanager.activePopups.Clear();
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
