using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class DayConfetti : MonoBehaviour
{
    public List<GameObject> confettiList;
    public int enabledConfettiMax;
    public int enabledConfetti;

    public void Start()
    {
        foreach (Transform child in transform)
        {
            confettiList.Add(child.gameObject);
        }
        GenerateRandomSetOfConfetti();
    }

    public void GenerateRandomSetOfConfetti()
    {
        for(int i = 0; i< confettiList.Count; i++)
        {
            confettiList[i].SetActive(false);
            confettiList[i].transform.rotation = new Quaternion(0,0,0, 0);
        }
        enabledConfetti = 0;
        for (int i = 0; i < confettiList.Count; i++)
        {
            int AA = Random.Range(0, 2);

            bool AAA = false;
            if (AA == 0)
            {
                AAA = true;
                enabledConfetti += 1;
            }
            else
            {
                AAA = false;
            }

            confettiList[i].SetActive(AAA);
            confettiList[i].transform.Rotate(0,0,Random.Range(0, 360));
            confettiList[i].GetComponent<Rigidbody2D>().gravityScale = Random.Range(.45f, 1.25f);

            if (enabledConfetti >= enabledConfettiMax)
            {
                i = confettiList.Count;
                break;
            }
            else if (i == confettiList.Count - 1 && enabledConfetti == 0)
            {
                i = 0;
            }
        }
    }
}
