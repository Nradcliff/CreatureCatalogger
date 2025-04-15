using UnityEngine;

//May add more here, for now only serves to delete popups from scene without messing up the WindowLayerManager
public class PopupScript : MonoBehaviour
{
    GameObject winManager;
    InternetScript internet;

    void Start()
    {
        winManager = GameObject.Find("WindowLayerManager");
        internet = GameObject.Find("Internet").GetComponent<InternetScript>();

        internet.openPrograms += 1;
    }

    public void deletePopup()
    {
        //Remove the popup from windowSortList before deletion to prevent errors
        winManager.GetComponent<WindowLayerManagement>().windowSortList.Remove(this.gameObject);
        internet.openPrograms -= 1;
        Destroy(this.gameObject);
    }
}