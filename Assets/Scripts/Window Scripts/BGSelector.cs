using UnityEngine;
using UnityEngine.UI;

public class BGSelector : MonoBehaviour
{
    public Image bg;
    public Sprite bg1, bg2;

    public void Update()
    {
        
    }

    public void selectBG(int bgIndex)
    {
        if (bgIndex == 0) bg.sprite = bg1;
        else if(bgIndex == 1) bg.sprite = bg2;
    }
}
