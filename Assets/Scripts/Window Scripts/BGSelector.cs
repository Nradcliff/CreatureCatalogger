using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BGSelector : MonoBehaviour
{
    public Image bg, desktopBG;
    public Sprite bg1, bg2, bg3;
    public TMP_Dropdown bgDropdown;

    public Button confirm;

    public int bgIndex;

    public void Update()
    {
        
    }

    public void selectBG()
    {
        bgIndex = bgDropdown.value;
        if (bgIndex == 0) bg.sprite = bg1;
        else if(bgIndex == 1) bg.sprite = bg2;
        else if (bgIndex == 2) bg.sprite = bg3;
    }

    public void confirmButton()
    {
        if (bgIndex == 0) desktopBG.sprite = bg1;
        else if (bgIndex == 1) desktopBG.sprite = bg2;
        else if (bgIndex == 2) desktopBG.sprite = bg3;
    }
}
