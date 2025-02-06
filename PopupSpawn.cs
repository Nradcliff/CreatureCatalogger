using UnityEngine;

public class PopupSpawn : MonoBehaviour
{
    //Boundaries
    float minX = 0f;
    float maxX = 1f - 0.25f;
    float minY = 0f;
    float maxY = 1f - 0.25f;

    public Camera cam;

    public float chance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        cam = Camera.main;
        if (cam == null)
            print("Camera not found");
    }

    private void OnEnable()
    {
        //Generate random position whenever window is active without going beyond camera view
        float randX = Random.Range(minX, maxX);
        float randY = Random.Range(minY, maxY);

        Vector3 worldPos = cam.ViewportToWorldPoint(new Vector3(randX, randY, cam.nearClipPlane));

        this.gameObject.transform.position = new Vector3(worldPos.x, worldPos.y, this.gameObject.transform.position.z);
    }

    public void spawnPopup()
    {
        this.gameObject.SetActive(true);
    }

    public void chancePopup()
    { 
        if (Random.Range(0,100) < chance)
            this.gameObject.SetActive(true);
    }
}