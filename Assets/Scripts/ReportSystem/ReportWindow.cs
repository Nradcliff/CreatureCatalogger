using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using TMPro;

[CreateAssetMenu (fileName = "New Report", menuName = "Report")]
public class ReportWindow : ScriptableObject
{
    public new string name;
    public TMP_Text description;

    public Sprite artwork;

    public int id;
    public string threat;
    public string type;
    public bool isUsed = false; //If we plan to not have repeat reports used. Then this bool can be used to show that its been used before and not have it load into the list for future levels.

    public void Print ()
    {
        Debug.Log(name + ": " + description + " The threat level is " + threat + " and it belongs in the catagory of " + type);
    }
}
