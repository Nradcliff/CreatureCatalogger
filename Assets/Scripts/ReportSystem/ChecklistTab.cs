using System.Collections.Generic;
using TMPro;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;

public class ChecklistTab : MonoBehaviour
{
    public TMP_Text categoryDescriptionText;
    public string categoryNameText;
    

    public TMP_Text checkText;
    public TMP_Text checkDescriptionText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public void SwitchCheckTab()
    {
        checkText.text = categoryNameText;
        checkDescriptionText.text = categoryDescriptionText.text;
    }
}
