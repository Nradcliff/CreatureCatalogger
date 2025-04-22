using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

// ==> THIS SCRIPT TO BE ATTATCHED TO AN EMPTY GAMEOBJECT NAMED "PopupsManager" <==
public class PopupSpawnManageScript : MonoBehaviour
{
    //Use this in other scripts to disable or enable popups
    public static bool allowPopups = true;

    //Boundaries
    float minX = 0f;
    float maxX = 1f;
    float minY = 0f;
    float maxY = 1f;

    public Camera cam;

    public List<GameObject> popupWindows;
    [Header("Weights should correspond to popup order above. \nHigher value = more common. \n0 means it will not spawn at all.")]
    public float[] weights;

    public List<GameObject> activePopups;

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

    //Weighted random chance. Randomly returns an integer based on a weighted chance.
    public int getRandomWeightedIndex(float[] weights)
    {
        //check if array is populated
        if (weights == null || weights.Length == 0) return -1;

        float weight = 0;
        float total = 0;
        for(int i = 0; i < weights.Length; i++)
        {
            weight = weights[i];
            if (weight >= 0f) total += weights[i];
        }

        float rValue = Random.Range(0f, 1f);
        float s = 0f;

        for (int i = 0; i < weights.Length; i++)
        {
            weight = weights[i];

            s += weight / total;
            if (s >= rValue) return i;
        }

        return -1;
    }
    public void spawnRandomPopup()
    {
            GameObject popup = popupWindows[getRandomWeightedIndex(weights)];
            //Generate random position vector without going beyond camera view
            float randX = Random.Range(minX, maxX);
            float randY = Random.Range(minY, maxY);

            Vector3 worldPos = cam.ViewportToWorldPoint(new Vector3(randX, randY, cam.nearClipPlane));

            //Randomly chooses then instantiates a popup at the random position
            //OBSOLETEint randPopup = Random.Range(0, popupWindows.Count);
            if(allowPopups || popup.CompareTag("StrongVirus"))
            Instantiate(popup, new Vector3(worldPos.x, worldPos.y, this.gameObject.transform.position.z), Quaternion.identity);
        
    }

    public void chancePopup(float chance)
    {
        if (Random.Range(0f, 100f) <= chance)
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

