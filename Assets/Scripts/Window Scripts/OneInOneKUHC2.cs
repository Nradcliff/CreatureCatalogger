using UnityEngine;

public class OneInOneKUHC2 : MonoBehaviour
{
    public int number;
    public GameObject UHC2;

    void Start()
    {
        number = Random.Range(0, 1000);
        if(number == 0)
        {
            UHC2.SetActive(true);
        }
    }
}
