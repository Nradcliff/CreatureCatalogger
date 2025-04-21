using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;

public class randomNameCountry : MonoBehaviour
{
    public TextMeshProUGUI text;
    public List<string> countries;
    public List<string> names;
    
    void Start()
    {
        text.text = "Hello, sir. This is " + names[Random.Range(0, names.Count)] + " from " + countries[Random.Range(0, countries.Count)] + ". I access your device. Tell me how is your country like? Do not worry. I will not ruin your device.";
    }
}
