using UnityEngine;
using UnityEngine.UI;

public class VolumeSliders : MonoBehaviour
{
    public Slider master, sfx, ambience;
    public float masterVol,sfxVol,ambienceVol;
    public ProgramPersist persist;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        persist = GameObject.Find("LoadProgramManager").GetComponent<ProgramPersist>();

        masterVol = persist.masterVol;
        sfxVol = persist.sfxVol;
        ambienceVol = persist.ambienceVol;

        master.value = masterVol / 1;
        sfx.value = sfxVol / 1;
        ambience.value = ambienceVol / 1;
    }

    // Update is called once per frame
    void Update()
    {
        masterVol = master.value;
        sfxVol = sfx.value;
        ambienceVol = ambience.value;

        persist.masterVol = masterVol;
        persist.sfxVol = sfxVol;
        persist.ambienceVol = ambienceVol;
    }

    public void updateTheFileAAAA()
    {
        persist.saveVol();
    }
}
