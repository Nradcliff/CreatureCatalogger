using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class SpamError : MonoBehaviour
{
    public GameObject errorWindow;
    Camera cam;

    private void Awake()
    {
        cam = Camera.main;
        if (cam == null)
            print("Camera not found");
    }

    //Spawns an error message multiple times
    public void spawnErrors()
    {  
        for (int i = 0; i < Random.Range(3, 10); i++)
        {
            float randX = Random.Range(0f, 1f);
            float randY = Random.Range(0f, 1f);

            Vector3 worldPos = cam.ViewportToWorldPoint(new Vector3(randX, randY, cam.nearClipPlane));

            Instantiate(errorWindow, new Vector3(worldPos.x, worldPos.y, this.gameObject.transform.position.z), Quaternion.identity);
        }
        Invoke("destroyInsteadOfDisable", 0f);
    }

    /*public void test()
    {
        for (int i = 0; i < 3; i++)
        {
            float randX = Random.Range(0f, 1f);
            float randY = Random.Range(0f, 1f);

            Vector3 worldPos = cam.ViewportToWorldPoint(new Vector3(randX, randY, cam.nearClipPlane));

            GameObject obj = Instantiate(this.gameObject, new Vector3(worldPos.x, worldPos.y, this.gameObject.transform.position.z), Quaternion.identity);
            Button x = obj.gameObject.GetComponentInChildren<Button>();

            x.onClick.AddListener(closeButtonScript);
        }
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    void closeButtonScript()
    {
        if (Time.timeScale > 0)
        {
            gameObject.SetActive(false);
        }
    }*/
}
