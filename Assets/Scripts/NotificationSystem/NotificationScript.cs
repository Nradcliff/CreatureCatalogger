using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class NotificationScript : MonoBehaviour
{
    //Objects to snap the notification boxes to
    public GameObject SlotOne, SlotTwo, SlotThree, SlotFour;
    bool OneChecked, TwoChecked, ThreeChecked, FourChecked;

    //These will be all possible notifications that may be called
    public List<GameObject> notificationBoxes;

    //This will be a list to store all notifications that are not currently shown
    public List<GameObject> pendingList;

    public List<GameObject> slots = new List<GameObject>(4);

    void Start()
    {
        
    }

    void Update()
    {
        /*if (slots.Count < 4)
        for (int i  = 0; i < 4; i++)
        {
            slots.Add(pendingList[0]);
            pendingList.RemoveAt(0);
        }*/

        if (SlotFour.transform.childCount == 0 && !FourChecked)
        {
            if (pendingList.Count > 0)
            {
                Instantiate(pendingList[0], SlotFour.transform.position, Quaternion.identity, SlotFour.transform);
                pendingList.RemoveAt(0);
                FourChecked = true;
                print("SlotFour Instantiate");
            }
        }

        if (SlotThree.transform.childCount == 0 && !ThreeChecked)
        {
            if (SlotFour.transform.childCount > 0)
            {
                Transform thr = SlotFour.transform.GetChild(0);
                thr.transform.position = SlotThree.transform.position;
                thr.transform.parent = SlotThree.transform;
                ThreeChecked = true;
                print("SlotThree Child");
            }
            /*else
            {
                if (pendingList.Count > 0)
                {
                    Instantiate(pendingList[0], SlotThree.transform.position, Quaternion.identity, SlotThree.transform);
                    pendingList.RemoveAt(0);
                    ThreeChecked = true;
                    print("SlotThree Instantiate");
                }
            }*/
        }

        if (SlotTwo.transform.childCount == 0 && !TwoChecked)
        {
            if (SlotThree.transform.childCount > 0)
            {
                Transform two = SlotThree.transform.GetChild(0);
                two.transform.position = SlotTwo.transform.position;
                two.transform.parent = SlotTwo.transform;
                TwoChecked = true;
                print("SlotTwo Child");
            }
            /*else
            {
                if (pendingList.Count > 0)
                {
                    Instantiate(pendingList[0], SlotTwo.transform.position, Quaternion.identity, SlotTwo.transform);
                    pendingList.RemoveAt(0);
                    TwoChecked = true;
                    print("SlotTwo Instantiate");
                }
            }*/
        }

        if (SlotOne.transform.childCount == 0 && !OneChecked)
        {
            if (SlotTwo.transform.childCount > 0)
            {
                Transform one = SlotTwo.transform.GetChild(0);
                one.transform.position = SlotOne.transform.position;
                one.transform.parent = SlotOne.transform;
                OneChecked = true;
                print("SlotOne Child");
            }
            /*else
            {
                if (pendingList.Count > 0)
                {
                    Instantiate(pendingList[0], SlotOne.transform.position, Quaternion.identity, SlotOne.transform);
                    pendingList.RemoveAt(0);
                    OneChecked = true;
                    print("SlotOne Instantiate");
                }
            }*/
        }

        else
        {
            print("All slots filled");
            if (SlotOne.transform.childCount == 0)
                OneChecked = false;

            if (SlotTwo.transform.childCount == 0)
                TwoChecked = false;

            if (SlotThree.transform.childCount == 0)
                ThreeChecked = false;

            if (SlotFour.transform.childCount == 0)
                FourChecked = false;
        }

        /*if (!OneFilled)
        {
            Instantiate(pendingList[0], SlotOne.transform.position, Quaternion.identity, this.transform);
            pendingList.RemoveAt(0);
            OneFilled = true;
        }
        else if (!TwoFilled)
        {
            Instantiate(pendingList[0], SlotTwo.transform.position, Quaternion.identity, this.transform);
            pendingList.RemoveAt(0);
            TwoFilled = true;
        }
        else if (!ThreeFilled)
        {
            Instantiate(pendingList[0], SlotThree.transform.position, Quaternion.identity, this.transform);
            pendingList.RemoveAt(0);
            ThreeFilled = true;
        }
        else if (!FourFilled)
        {
            Instantiate(pendingList[0], SlotFour.transform.position, Quaternion.identity, this.transform);
            pendingList.RemoveAt(0);
            FourFilled = true;
        }*/
    }

    public void sendNotification(int notiPos)
    {
        pendingList.Add(notificationBoxes[notiPos]);
    }

    public void sendRand()
    {
        int rand = Random.Range(0, notificationBoxes.Count);
        pendingList.Add(notificationBoxes[rand]);
    }
}
