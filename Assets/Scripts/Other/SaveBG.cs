using UnityEngine;
using UnityEngine.UI;

public class SaveBG : MonoBehaviour
{
    public Image background;
    public ProgramPersist persist;
    public Sprite bg1, bg2, bg3;
    public int currentIndex;

    private void Start()
    {
        persist = GameObject.Find("LoadProgramManager").GetComponent<ProgramPersist>();
        switch (persist.backgroundIndex) {
            case 0:
                background.sprite = bg1;
                break;
            case 1:
                background.sprite = bg2;
                break;
            case 2:
                background.sprite = bg3;
                break;
        }
    }

    public void saveChanges(int index)
    {
        persist.backgroundIndex = index;
    }
}
