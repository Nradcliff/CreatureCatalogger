using UnityEngine;

public class OverlayAudioManager : MonoBehaviour
{
    AudioSource audioS;
    public AudioClip woahNeatAmbience;
    public ProgramPersist prog;
    public bool ambience;

    void Start()
    {
        audioS = GetComponent<AudioSource>();
        if (ambience)
        {
            audioS.clip = woahNeatAmbience;
            audioS.Play();
        }
    }

    void Update()
    {
        if(!ambience)
        {
            audioS.volume = prog.sfxVol * prog.masterVol;
        }
        else
        {
            audioS.volume = prog.ambienceVol * prog.masterVol;
        }
    }

    public void PlayASound(AudioClip clip)
    {
        audioS.PlayOneShot(clip);
    }
}
