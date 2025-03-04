using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioSource sourceFilmMaker;
    public List<AudioClip> clipList;

    public void playsound(int index)
    {
        sourceFilmMaker.PlayOneShot(clipList[index]);
    }
}
