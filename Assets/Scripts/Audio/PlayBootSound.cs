using UnityEngine;

public class PlayBootSound : MonoBehaviour
{
    public OverlayAudioManager OverlayAudioManager;
    public AudioClip bootSound;

    public void Start()
    {
        OverlayAudioManager = GameObject.Find("OverlayAudioManager").GetComponent<OverlayAudioManager>();
        OverlayAudioManager.PlayASound(bootSound);
    }
}
