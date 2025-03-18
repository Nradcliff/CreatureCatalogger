using UnityEngine;

public class OverlayAudioManager : MonoBehaviour
{
    AudioSource audioS;
    public AudioClip woahNeatAmbience;

    void Start()
    {
        audioS = GetComponent<AudioSource>();
        audioS.clip = woahNeatAmbience;
        audioS.Play();
    }

    void Update()
    {
        
    }

    public void PlayASound(AudioClip clip)
    {
        audioS.PlayOneShot(clip);
    }
}
