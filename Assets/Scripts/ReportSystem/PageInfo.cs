using UnityEngine;
using UnityEngine.UI;

public class PageInfo : MonoBehaviour
{
    public static PageInfo Instance;

    public GameObject reportName;
    public GameObject description;
    public GameObject art;
    public Scrollbar scroll;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
