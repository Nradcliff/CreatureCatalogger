using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NotificationScript : MonoBehaviour
{
    //Objects to parent the messages to
    public GameObject SlotOne, SlotTwo, SlotThree, SlotFour;
    bool OneChecked, TwoChecked, ThreeChecked, FourChecked;

    //These will be all possible notifications that may be called, put your message prefabs here
    public List<GameObject> notificationBoxes;

    //This will be a list to store all notifications that are not currently shown
    public List<GameObject> pendingList;
    
    GameObject Message;
    public GameObject MessageCounter;
    public TextMeshProUGUI CounterText;

    void Start()
    {
        
    }

    void Update()
    {
        //Instantiate first message at final slot if allowed, then bring that message down from Four to One
        if (SlotFour.transform.childCount == 0 && !FourChecked)
        {
            if (pendingList.Count > 0)
            {
                Message = Instantiate(pendingList[0], SlotFour.transform.position, Quaternion.identity, SlotFour.transform);
                Message.transform.localScale = new Vector3(1, 1, 1);
                pendingList.RemoveAt(0);
                FourChecked = true;
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
            }
        }

        if (SlotTwo.transform.childCount == 0 && !TwoChecked)
        {
            if (SlotThree.transform.childCount > 0)
            {
                Transform two = SlotThree.transform.GetChild(0);
                two.transform.position = SlotTwo.transform.position;
                two.transform.parent = SlotTwo.transform;
                TwoChecked = true;
            }
        }

        if (SlotOne.transform.childCount == 0 && !OneChecked)
        {
            if (SlotTwo.transform.childCount > 0)
            {
                Transform one = SlotTwo.transform.GetChild(0);
                one.transform.position = SlotOne.transform.position;
                one.transform.parent = SlotOne.transform;
                OneChecked = true;
            }
        }

        //Reset the check if a child(message) was removed
        else
        {
            if (SlotOne.transform.childCount == 0)
                OneChecked = false;

            if (SlotTwo.transform.childCount == 0)
                TwoChecked = false;

            if (SlotThree.transform.childCount == 0)
                ThreeChecked = false;

            if (SlotFour.transform.childCount == 0)
                FourChecked = false;
        }

        //Determine when to enable and disable the counter and set the counter number depending on wether the Bar
        //is open or not
        if ((BarEasing.isOpen == true && pendingList.Count <= 0) || SlotOne.transform.childCount == 0)
        {
            MessageCounter.SetActive(false);
        }
        else if (SlotOne.transform.childCount > 0 && BarEasing.isOpen == false)
        {
            MessageCounter.SetActive(true);
            CounterText.text = (pendingList.Count + SlotOne.transform.childCount + SlotTwo.transform.childCount
            + SlotThree.transform.childCount + SlotFour.transform.childCount).ToString();
        }
        else
        {
            MessageCounter.SetActive(true);
            CounterText.text = pendingList.Count.ToString();
        }
    }

    /*Send a specific message, made a string to make it easier to call in inspector, if you don't mind then change to
    string notiPos > int notiPos
    remove loop and if, pendingList.Add(notificationBoxes[notiPos])
    Using a for loop for the string will cause performance issues when too many notification messages are made for
    the notificationBoxes array
     */
    public void sendNotification(string notiPos)
    {
        for (int i = 0; i < notificationBoxes.Count; i++)
        {
            if(notificationBoxes[i].name == notiPos)
                pendingList.Add(notificationBoxes[i]);
        }
    }

    //For testing
    public void sendRand()
    {
        int rand = Random.Range(0, notificationBoxes.Count);
        pendingList.Add(notificationBoxes[rand]);
    }

    public void sendIncorrectNotif()
    {
        pendingList.Add(notificationBoxes[1]);
    }
    public void sendFinalNotif()
    {
        pendingList.Add(notificationBoxes[2]);
    }
}
