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
        {"orange", "#ef5847"},
        {"purple", "#9B90EE"}
    };

    List<string> response = new List<string>();
    ProgramPersist programPersist;
    public GameObject volTab;

    public void Start()
    {
        programPersist = GameObject.Find("LoadProgramManager").GetComponent<ProgramPersist>();
    }

    public List<string> Interpret(string userInput)
    {
        response.Clear();

        string[] args = userInput.Split();

        if (args[0].ToLower() == "help")
        {
            ListEntry("start", "Type \"start\" to begin the game ");
            ListEntry("load", "Type \"load\" if you have existing save data");
            ListEntry("ascii", "Type \"ascii\" to see the title!");
            ListEntry("options", "Type \"options\" to open the options menu ");
            ListEntry("help", "Type \"help\" to see the list of available commands ");
            ListEntry("credits", "Type \"credits\" to see the game's credits ");
            ListEntry("quit", "Type \"quit\" to close the game ");
            ListEntry("reboot", "Type \"reboot\" to reset save data");

            return response;
        }


        if (args[0].ToLower() == "start")
        {
            programPersist.clearData();
            programPersist.resetBools = false;
            programPersist.DayNum = 0;
            response.Add("Beginning game, Happy Sorting! ");
            //SceneManager.LoadScene("LoadingScene");
            SceneManager.UnloadSceneAsync("MainMenu");
            SceneManager.LoadScene("LoadingScene", LoadSceneMode.Additive);
            return response;
            
        }
        if (args[0].ToLower() == "ascii")
        {
            LoadTitle("asciixp.txt", "green", 2);
            return response;
        }
        if (args[0].ToLower() == "load")
        {
            response.Add("C:\\Psyence\\System32>LoadState");
            if (programPersist.LoadFile())
            {
                SceneManager.UnloadSceneAsync("MainMenu");
                SceneManager.LoadScene("LoadingScene", LoadSceneMode.Additive);
            }
            else
            {
                response.Add(ColorString("Error: File Not Found", colors["red"]));
            }
            return response;
        }
        if (args[0].ToLower() == "options")
        {
            //response.Add("Loading options, please wait... ");
            //response.Add("Options menu still in progress, thank you for your time.");
            response.Add("C:\\Program-Files\\Options>Access"); 
            ListEntry("volume", "open/close the volume submenu");
            ListEntry("access", "enable/disable accessibility mode (no timer)");
            return response;
        }
        if (args[0].ToLower() == "accessible" || args[0].ToLower() == "access")
        {
            if (programPersist.noTimer == false)
            {
                programPersist.noTimer = true;
                response.Add("Accessibility mode enabled");
            }
            else if(programPersist.noTimer == true)
            {
                programPersist.noTimer = false;
                response.Add("Accessibility mode disabled");
            }
            return response;
        }

        if (args[0].ToLower() == "volume")
        {
            response.Add("C:\\Program-Files\\Options>Volume>Access");
            volTab.SetActive(!volTab.activeSelf);
            return response;
        }

        if (args[0].ToLower() == "quit")
        {
            response.Add("C:\\Psyence\\System32>del");
            Application.Quit();
            return response;
        }
        if (args[0].ToLower() == "reboot")
        {
            programPersist.clearData();
            response.Add("Rebooting System...");
            SceneManager.LoadScene("OverlayScene");
            return response;
        }
        if (args[0].ToLower() == "credits")
        {
            response.Add("C:\\Psyence\\Psyence-XP\\MIB\\Credits");
            response.Add("");
            response.Add("Psyence XP");
            response.Add("");
            response.Add("By Monsters In Boxes - 2025");
            ListCreditsD("Drewnell", "art assets, sound design");
            ListCreditsA("Ahmad", "pop-up and notification system development");
            ListCreditsN("Noah", "main menu and reports system development, report descriptions");
            ListEntry("Gibby", "scenes and window system development");
            response.Add("");
            response.Add("Fonts");
            ListEntry("Daniel Linssen", "m5x7 - https://managore.itch.io/m5x7");
            ListEntry("rektdeckard", "Departure Mono - https://departuremono.com/");
            response.Add("");
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

    void ListCreditsN(string a, string b)
    {
        response.Add(ColorString(a, colors["green"]) + ": " + ColorString(b, colors["yellow"]));
    }
    void ListCreditsA(string a, string b)
    {
        response.Add(ColorString(a, colors["blue"]) + ": " + ColorString(b, colors["yellow"]));
    }
    void ListCreditsD(string a, string b)
    {
        response.Add(ColorString(a, colors["purple"]) + ": " + ColorString(b, colors["yellow"]));
    }
}
