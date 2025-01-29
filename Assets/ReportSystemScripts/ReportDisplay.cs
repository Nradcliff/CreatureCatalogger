using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReportDisplay : MonoBehaviour
{
    public ReportWindow report;

    public TMP_Text nameText;
    public TMP_Text descriptionText;

    public Image artworkImage;
    

    public void SwitchTab()
    {
        nameText.text = report.name;
        descriptionText.text = report.description;

        artworkImage.sprite = report.artwork;
    }

}
