using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPageSwap : MonoBehaviour
{
    public List<GameObject> pages;

    public void swapWebpage(int index)
    {
        for(int i = 0;i < pages.Count; i++)
        {
            pages[i].SetActive(false);
        }
        pages[index].SetActive(true);
    }
}
