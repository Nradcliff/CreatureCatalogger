using TMPro;
using UnityEngine;

public class DemoInternetShutoff : MonoBehaviour
{
    public float timer;
    public bool on;

    public Sprite onSprite, offSprite;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 120 && timer < 125)
        {
            on = false;
            this.GetComponent<SpriteRenderer>().sprite = offSprite;
        }
        else
        {
            on = true;
            this.GetComponent<SpriteRenderer>().sprite = onSprite;
        }
    }
}
