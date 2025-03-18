using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioSource sourceFilmMaker;
    public List<AudioClip> clipList;

    /// <summary>
    /// Sound Indexes (Update this list when adding new sounds)
    /// | 0 = Start-Up
    /// | 1 = Icon Click Sound
    /// | 2 = Shut Down
    /// | 3 = Error
    /// | 4 = Restore Window
    /// | 5 = Minimize Window
    /// | 6 = Notification
    /// </summary>
    /// <param name="index"></param>
    public void playsound(int index)
    {
        sourceFilmMaker.PlayOneShot(clipList[index]);
    }
}
