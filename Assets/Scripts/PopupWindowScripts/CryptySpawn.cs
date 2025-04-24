using Unity.VisualScripting;
using UnityEngine;

public class CryptySpawn : MonoBehaviour
{
    public GameObject creture;
    public GameObject bars;
    public GameObject button;
    public GameObject image;

    public AudioSource sound;

    public void spawnACrypty()
    {
        Instantiate(creture, transform.position - new Vector3(0, 1, 0), Quaternion.identity);
        bars.SetActive(false);
        image.SetActive(false);
        sound.Play();
        button.SetActive(false);
    }
}
