using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.UI;

public class Minimize : MonoBehaviour
{
    public float pScaleX, pScaleY;
    public bool pressed;
    public float targetScaleX, targetScaleY;
    public Button mimizeButton;

    public Vector3 baseScale,targetScale;
    public float timeLerped =1;
    public float speed;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pScaleX = transform.localScale.x;
        pScaleY = transform.localScale.y;
        targetScaleX = pScaleX / 10;
        targetScaleY = pScaleY / 10;

        baseScale = new Vector3(targetScaleX, targetScaleY, transform.localScale.z);
        baseScale = new Vector3(pScaleX, pScaleY, transform.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(pressed)
        {
            timeLerped += Time.deltaTime;
            transform.localScale = baseScale / (speed*timeLerped);
        }
        else
        {
            transform.localScale = baseScale;
        }
    }

    public void minimizeButton()
    {
        timeLerped = .1f;
        pressed = !pressed;
        
    }

}
