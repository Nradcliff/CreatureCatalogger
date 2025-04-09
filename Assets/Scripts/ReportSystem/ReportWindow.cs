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
    public enum EntityThreat
    {
        Safe,
        Harmful,
        Dangerous,
        Lethal
    };
    public EntityThreat Threat;
    public enum EntityType
    {
        Beast,
        Humanoid,
        Inanimate,
        Abstract
    };
    public EntityType Type;
    public bool isUsed = false; //If we plan to not have repeat reports used. Then this bool can be used to show that its been used before and not have it load into the list for future levels.

}
