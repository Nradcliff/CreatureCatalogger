using UnityEngine;
using UnityEngine.UI;

public class InstallerDemo : MonoBehaviour
{
    public float timer;
    public bool startInstall;

    public Button startButton, finishButton;
    public Slider progressBar;

    public GameObject parent;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        progressBar.value = timer;
        if (startInstall)
        {
            if (timer >= 1)
            {
                startInstall = false;
                finishButton.gameObject.SetActive(true);
            }
            else if (timer < .45f)
            {
                timer += Time.deltaTime * 1.25f;
            }
            else if ((timer > .45f && timer < .55f) || timer > .90f)
            {
                timer += Time.deltaTime*.5f;
            }
            else if (timer >= .55f || timer <= .90f)
            {
                timer += Time.deltaTime * .15f;
            }
            
        }
    }
    public void startInstallFunc()
    {
        startInstall = true;
        startButton.gameObject.SetActive(false);
    }

    public void OnEnable()
    {
            startInstall = false;
            progressBar.value = 0;
            timer = 0;
            startButton.gameObject.SetActive(true);
            finishButton.gameObject.SetActive(false);
    }
}
