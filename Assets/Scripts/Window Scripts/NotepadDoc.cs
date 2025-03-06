using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class NotepadDoc : MonoBehaviour
{
    public ProgramPersist saveLoadThingy;
    public TMP_InputField notepadText;

    void Start()
    {
        saveLoadThingy = GameObject.Find("LoadProgramManager").GetComponent<ProgramPersist>();
        notepadText.text = saveLoadThingy.notepadText;
    }

    private void OnEnable()
    {
        saveLoadThingy = GameObject.Find("LoadProgramManager").GetComponent<ProgramPersist>();
        notepadText.text = saveLoadThingy.notepadText;
    }

    public void saveText()
    {
        saveLoadThingy.notepadText = notepadText.text;
    }
}
