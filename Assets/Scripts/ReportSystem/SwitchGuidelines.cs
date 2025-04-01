using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SwitchGuidelines : MonoBehaviour
{
    private GameObject title;
    public GameObject description;

    public string titleOf;

    public GameObject descriptionObj;
    public GameObject titleObj;


    public void Start()
    {

    }

    public void SwitchingTab()
    {
        PageInfo2.Instance2.reportName.GetComponent<TMP_Text>().text = titleOf;
        PageInfo2.Instance2.description.GetComponent<TMP_Text>().text = description.GetComponent<TMP_Text>().text;
    }
}
