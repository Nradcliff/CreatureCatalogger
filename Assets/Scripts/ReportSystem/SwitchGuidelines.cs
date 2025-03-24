using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SwitchGuidelines : MonoBehaviour
{
    private GameObject title;
    public GameObject description;

    public string titleOf;


    public void Start()
    {

    }

    public void SwitchingTab()
    {
        PageInfo.Instance.reportName.GetComponent<TMP_Text>().text = titleOf;
        PageInfo.Instance.description.GetComponent<TMP_Text>().text = description.GetComponent<TMP_Text>().text;
    }
}
