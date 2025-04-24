using UnityEngine;
using UnityEngine.UI;

public class upgradeAntivirus : MonoBehaviour
{
    bool startInstall;
    public float timer;

    public Slider slider;
    public Button installButton;

    void Update()
    {
        slider.value = timer;
        if (startInstall)
        {
            if (timer >= 1)
            {
                startInstall = false;
                AntivirusScript.upgraded = true;
            }
            else if (timer < .45f)
            {
                timer += Time.deltaTime * 1.25f;
            }
            else if ((timer > .45f && timer < .55f) || timer > .90f)
            {
                timer += Time.deltaTime * .5f;
            }
            else if (timer >= .55f || timer <= .90f)
            {
                timer += Time.deltaTime * .15f;
            }
        }

    }
    public void upgrade()
    {
        if (!AntivirusScript.upgraded)
        {
            startInstall = true;
            installButton.gameObject.SetActive(false);
        }
    }
}
