using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Report", menuName = "Report")]
public class ReportWindow : ScriptableObject
{
    public new string name;
    public string description;

    public Sprite artwork;

    public int id;
    public string threat;
    public string type;

    public void Print ()
    {
        Debug.Log(name + ": " + description + " The threat level is " + threat + " and it belongs in the catagory of " + type);
    }
}
