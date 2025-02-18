using System.Collections.Generic;
using UnityEngine;

public class WindowLayerManagement : MonoBehaviour
{
    public List<GameObject> windowSortList;
    public GameObject var;

    public void Update()
    {
        for(int i = 0; i < windowSortList.Count; i++)
        {
            if (windowSortList[i] != null)
            {
                if (windowSortList[i].GetComponent<WindowScript>().priority == true)
                {
                    windowSortList[i].GetComponent<WindowScript>().priority = false;
                    var = windowSortList[i];
                    windowSortList.RemoveAt(i);
                    windowSortList.Add(var);
                }
                windowSortList[i].GetComponent<WindowScript>().posInArray = i;
            }
            else
            {
                windowSortList.Remove(windowSortList[i]);
            }
        }
    }
}
