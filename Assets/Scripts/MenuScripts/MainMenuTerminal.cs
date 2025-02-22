using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.XR;
using TMPro;
using Unity.VisualScripting;

public class MainMenuTerminal : MonoBehaviour
{
    public GameObject directoryLine;
    public GameObject responseLine;

    public TMP_InputField inputField;
    public GameObject userInputLine;
    public ScrollRect sr;
    public GameObject msgList;

    public TerminalInterpreter interpreter;

    public void Start()
    {
        inputField.ActivateInputField();
        inputField.Select();
    }

    private void OnGUI()
    {
        if(inputField.isFocused && inputField.text != "" && Input.GetKeyDown(KeyCode.Return))
        {
            string userInput = inputField.text;

            ClearInputField();

            AddDirectoryLine(userInput);

            int lines = AddInterpreterLines(interpreter.Interpret(userInput));

            ScrollToBottom(lines);

            userInputLine.transform.SetAsLastSibling();

            inputField.ActivateInputField();
            inputField.Select();
        }
    }

    void ClearInputField()
    {
        inputField.text = "";
    }

    void AddDirectoryLine(string userInput)
    {
        //Resizing command line container
        Vector2 msgListSize = msgList.GetComponent<RectTransform>().sizeDelta;
        msgList.GetComponent<RectTransform>().sizeDelta = new Vector2(msgListSize.x, msgListSize.y + 35.0f);

        GameObject msg = Instantiate(directoryLine, msgList.transform);

        msg.transform.SetSiblingIndex(msgList.transform.childCount - 1);

        msg.GetComponentsInChildren<TMP_Text>()[1].text = userInput;
    }

    int AddInterpreterLines(List<string> interpretation)
    {
        for (int i = 0; i < interpretation.Count; i++)
        {
            GameObject res = Instantiate(responseLine, msgList.transform);

            res.transform.SetAsLastSibling();

            Vector2 listSize = msgList.GetComponent<RectTransform>().sizeDelta;
            msgList.GetComponent<RectTransform>().sizeDelta = new Vector2(listSize.x, listSize.y + 35.0f);

            res.GetComponentInChildren<TMP_Text>().text = interpretation[i];
        }

        return interpretation.Count;
    }

    void ScrollToBottom(int lines)
    {
        if (lines > 4)
        {
            sr.velocity = new Vector2(0, 450);
        }
        else
        {
            sr.verticalNormalizedPosition = 0;
        }
    }
}
