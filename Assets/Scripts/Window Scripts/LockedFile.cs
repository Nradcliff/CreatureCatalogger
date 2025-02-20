using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LockedFile : MonoBehaviour
{
    public GameObject panel;
    public TMP_InputField passwordField;
    public TextMeshProUGUI text;
    public string password;
    public float timer;
    public bool unlocked;

    
    void Update()
    {
        if (unlocked)
        {
            timer += Time.deltaTime;
            if (timer >= 2)
            {
                panel.SetActive(false);
            }
        }
    }

    public void checkToUnlock()
    {
        if (Time.timeScale > 0)
        {
            if (passwordField.text == password)
            {
                unlocked = true;
                text.text = "Program Unlocked";
                text.color = Color.green;
            }
            else
            {
                text.text = "Incorrect Password";
                text.color = Color.red;
            }
        }
    }

    public void OnEnable()
    {
        timer = 0;
        unlocked = false;
        panel.SetActive(true);
        passwordField.text = "";
        text.text = "Enter Password to access file";
        text.color = new Color(.64f, .64f, .64f);
    }
}
