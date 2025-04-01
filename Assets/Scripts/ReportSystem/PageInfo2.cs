using UnityEngine;
using UnityEngine.UI;

public class PageInfo2: MonoBehaviour
{
    public static PageInfo2 Instance2;

    public GameObject reportName;
    public GameObject description;
    public GameObject art;
    public Scrollbar scroll;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instance2 = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
