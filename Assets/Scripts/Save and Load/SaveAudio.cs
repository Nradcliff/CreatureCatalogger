using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveAudio
{
    public float smasterVol, ssfxVol, sambienceVol;

    public void saveCurrentData(float m, float s, float a)
    {
        smasterVol = m;
        ssfxVol = s;
        sambienceVol = a;
    }
}
