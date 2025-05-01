using Unity.VisualScripting;
using UnityEngine;

public class CryptySpawn : MonoBehaviour
{
    public GameObject creture;
    public GameObject bars;
    public GameObject button;
    public GameObject image;

    private AudioSource sound;
    public AudioClip clip;

    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    public void spawnACrypty()
    {
        Instantiate(creture, transform.position - new Vector3(0, 1, 0), Quaternion.identity);
        sound.clip = clip;
        sound.Play();
        bars.SetActive(false);
        image.SetActive(false);
        button.SetActive(false);
    }
}
