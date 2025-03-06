using UnityEngine;
/*This script is necessary to call functions with multiple parameters while still being able to easily input values in inspector
I don't know how else to do this so this is a temporary solution*/

public class PopupParametersToButton : MonoBehaviour
{
    GameObject manager;

    [Header("Function: chanceSpecificPopup(chance, listElement)")]
    [Tooltip("Parameter 1")]
    public int chance;
    [Tooltip("Paramter 2")]
    public int listElement;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = GameObject.Find("PopupsManager");
    }

    public void chanceSpecificPopup()
    {
        if (Random.Range(0, 100) <= chance)
            manager.GetComponent<PopupSpawnManageScript>().spawnPopup(listElement);
    }
}
