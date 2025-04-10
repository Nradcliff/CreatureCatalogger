using UnityEngine;
using UnityEngine.UI;
using TMPro;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;

public class SwitchTab : MonoBehaviour
{
    private GameObject reportName;
    private GameObject description;
    private GameObject art;
    public ReportWindow report;

    public TMP_Text nameText;
    public TMP_Text descriptionText;
    public Image artworkImage;

    public Sprite empty;

    public Scrollbar bar;

    public void Start()
    {
        reportName = PageInfo.Instance.reportName;
        description = PageInfo.Instance.description;
        art = PageInfo.Instance.art;

        bar = PageInfo.Instance.scroll;

        nameText = reportName.GetComponent<TMP_Text>();
        descriptionText = description.GetComponent<TMP_Text>();
        artworkImage = art.GetComponent<Image>();
    }

    public void SwitchingTab()
    {
        nameText.text = report.name;
        descriptionText.text = report.description.text;
        bar.value = 1;

        artworkImage.sprite = report.artwork;
        if(report.artwork == null)
        {
            artworkImage.sprite = empty;
        }
    }
}
