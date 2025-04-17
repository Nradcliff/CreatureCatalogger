using TMPro;
using UnityEngine;
using UnityEngine.TextCore;

public class CrazyText : MonoBehaviour
{
    //characters to pull from
    const string glyphs = "abcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()-+=`~{}/";
    public TextMeshProUGUI Text;
    public TextMeshProUGUI textBox;

    private string[] loreText = {"Hi", "Hello", "Bye"};

    //repeat the function for a "glitch" effect
    void Start()
    {
        textBox.text = loreText[Random.Range(0, loreText.Length)];
        InvokeRepeating(nameof(randomizeText), 0f, 0.1f);
    }

    void randomizeText()
    {
        string randomText = "";
        for (int i = 0; i < 8; i++)
        {
            randomText += glyphs[Random.Range(0, glyphs.Length)];
        }
        Text.text = randomText;
    }
}
