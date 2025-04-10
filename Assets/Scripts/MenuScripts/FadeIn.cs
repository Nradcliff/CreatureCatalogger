using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public Image fadeImg;
    public float fadeTimer;
    public ProgramPersist persist;
    public GameObject ambiencePlayer,menuloader;
    public bool fadeBool;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeTimer > -.25f)
        {
            fadeTimer -= Time.deltaTime;
            fadeImg.color = new Color(0, 0, 0, fadeTimer);
        }
        else if (fadeBool)
        {
            fadeBool = false;
            fadeImg.gameObject.SetActive(false);
            ambiencePlayer.SetActive(true);
            menuloader.SetActive(true);
        }
    }
}
