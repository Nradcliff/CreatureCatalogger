using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

// ==> THIS SCRIPT TO BE ATTATCHED TO AN EMPTY GAMEOBJECT NAMED "PopupsManager" <==
public class PopupSpawnManageScript : MonoBehaviour
{
    //Use this in other scripts to disable or enable popups
    public bool allowPopups = true;

    //Boundaries
    float minX = 0f;
    float maxX = 1f - 0.25f;
    float minY = 0f;
    float maxY = 1f - 0.25f;

    public Camera cam;

    public List<GameObject> popupWindows;

    private void Awake()
    {
        cam = Camera.main;
        if (cam == null)
            print("Camera not found");
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            chancePopup(5);
        }
    }

    public void spawnRandomPopup()
    {
        if (allowPopups == true)
        {
            //Generate random position vector without going beyond camera view
            float randX = Random.Range(minX, maxX);
            float randY = Random.Range(minY, maxY);

            Vector3 worldPos = cam.ViewportToWorldPoint(new Vector3(randX, randY, cam.nearClipPlane));

            //Randomly chooses then instantiates a popup at the random position
            int randPopup = Random.Range(0, popupWindows.Count);
            Instantiate(popupWindows[randPopup], new Vector3(worldPos.x, worldPos.y, this.gameObject.transform.position.z), Quaternion.identity);
        }
    }

    public void chancePopup(float chance)
    {
        if (Random.Range(0, 100) <= chance)
            spawnRandomPopup();
    }

    public void spawnPopup(int listPos)
    {
        if (allowPopups == true)
        {
            //Generate random position vector without going beyond camera view
            float randX = Random.Range(minX, maxX);
            float randY = Random.Range(minY, maxY);

            Vector3 worldPos = cam.ViewportToWorldPoint(new Vector3(randX, randY, cam.nearClipPlane));

            //Instantiate the specific popup chosen from the list
            Instantiate(popupWindows[listPos], new Vector3(worldPos.x, worldPos.y, this.gameObject.transform.position.z), Quaternion.identity);
        }
    }
}

