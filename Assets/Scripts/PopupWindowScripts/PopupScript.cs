using UnityEngine;

//May add more here, for now only serves to delete popups from scene without messing up the WindowLayerManager
public class PopupScript : MonoBehaviour
{
    GameObject winManager;

    void Start()
    {
        winManager = GameObject.Find("WindowLayerManager");
    }

    public void deletePopup()
    {
        //Remove the popup from windowSortList before deletion to prevent errors
        winManager.GetComponent<WindowLayerManagement>().windowSortList.Remove(this.gameObject);
        Destroy(this.gameObject);
    }
}