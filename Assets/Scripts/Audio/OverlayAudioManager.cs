using UnityEngine;

public class OverlayAudioManager : MonoBehaviour
{
    AudioSource audioS;
    public AudioClip woahNeatAmbience,startup;
    public ProgramPersist prog;
    public bool ambience;

    void OnEnable()
    {
        audioS = GetComponent<AudioSource>();
        if (ambience)
        {
            audioS.PlayOneShot(startup);
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

        if (prog.dead)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void PlayASound(AudioClip clip)
    {
        audioS.PlayOneShot(clip);
    }
}
