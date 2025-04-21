using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class randomImage : MonoBehaviour
{
    public List<Sprite> images;
    public Image image;

    public TextMeshProUGUI text;  
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        image.sprite = images[Random.Range(0, images.Count)];
        int num = Random.Range(0, 8);
        text.text = num.ToString() + "% OFF!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
