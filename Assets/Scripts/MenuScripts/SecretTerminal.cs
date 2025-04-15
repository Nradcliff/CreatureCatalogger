using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecretTerminal : MonoBehaviour
{
    public TextMeshProUGUI thethingy;
    public GameObject parentobj;

    public List<string> thingsToSay;
    public int stringIndex;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        InvokeRepeating("addLines", .25f, .45f);
    }

    void addLines()
    {
        if (stringIndex < thingsToSay.Count)
        {
            TextMeshProUGUI a = Instantiate(thethingy, parentobj.transform);
            a.text = thingsToSay[stringIndex];
            stringIndex += 1;
        }
        else
        {
            SceneManager.UnloadSceneAsync("MainLevel");
            SceneManager.LoadScene("SecretScene", LoadSceneMode.Additive);
        }
    }
}
