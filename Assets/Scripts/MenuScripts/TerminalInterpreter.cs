using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System.IO;

public class TerminalInterpreter : MonoBehaviour
{
    Dictionary<string, string> colors = new Dictionary<string, string>()
    {
        {"black",  "#021b21"},
        {"gray",   "#555d71"},
        {"red",    "#ff5879"},
        {"yellow", "#f2f1b9"},
        {"blue",   "#9ed9d8"},
        {"green",  "#00FF00"},
        {"orange", "#ef5847"}
    };

    List<string> response = new List<string>();

    public List<string> Interpret(string userInput)
    {
        response.Clear();

        string[] args = userInput.Split();

        if (args[0] == "help" || args[0] == "Help")
        {
            ListEntry("start", "Type \"start\" to begin the game ");
            ListEntry("load", "Type \"load\" if you have existing save data");
            ListEntry("ascii", "Type \"ascii\" to see the title!");
            ListEntry("options", "Type \"options\" to open the options menu ");
            ListEntry("help", "Type \"help\" to see the list of available commands ");
            ListEntry("quit", "Type \"quit\" to close the game ");

            return response;
        }


        if (args[0] == "start" || args[0] == "Start")
        {
            response.Add("Beginning game, Happy Sorting! ");
            SceneManager.LoadScene("MainLevel");
            return response;
            
        }
        if (args[0] == "ascii" || args[0] == "Ascii" || args[0] == "ASCII")
        {
            LoadTitle("ascii.txt", "green", 2);
        }
        if (args[0] == "load")
        {
            response.Add("Function not added yet, but thanks for trying! ");
            return response;
        }
        if (args[0] == "options" || args[0] == "Options")
        {
            response.Add("Loading options, please wait... ");
            response.Add("Options menu still in progress, thank you for your time.");
            return response;
        }
        if (args[0] == "quit" || args[0] == "Quit")
        {
            response.Add("Closing Game... please dont go...");
            Application.Quit();
            return response;
        }
        else
        {
            response.Add("Command not recognized. Type help for a list of commands.");

            return response;
        }

        
    }

    public string ColorString(string s, string color)
    {
        string leftTag = "<color=" + color + ">";
        string rightTag = "</color>";

        return leftTag + s + rightTag;
    }

    void ListEntry(string a, string b)
    {
        response.Add(ColorString(a, colors["orange"]) + ": " + ColorString(b, colors["yellow"]));
    }

    public void LoadTitle(string path, string color, int spacing)
    {
        StreamReader file = new StreamReader(Path.Combine(Application.streamingAssetsPath, path));

        for (int i = 0; i < spacing; i++)
        {
            response.Add("");
        }

        while(!file.EndOfStream)
        {
            response.Add(ColorString(file.ReadLine(), colors[color]));
        }

        for (int i = 0; i < spacing; i++)
        {
            response.Add("");
        }

        file.Close();
    }
    
        
}
