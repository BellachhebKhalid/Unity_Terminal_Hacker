using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    /**** Game Configuration ****/
    string[] level1Password = { "books", "ailse", "self", "password", "font", "borrow" };
    string[] level2Password = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };
    string[] level3Password = { "astronaut", "cosmonaut", "cosmonaut", "pilot", "aerospace" };
    /**** Game Stat ****/
    // Member variable
    int level;
    // enum is dictionary with contain constant variable
    enum Screen { MainMenu,Password,Win};
    Screen currentScreen = Screen.MainMenu;
    string password;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu ()
    {
        
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hacke into ?");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the Police Station");
        Terminal.WriteLine("Press 3 for NASA !");
        Terminal.WriteLine("Enter your selection : ");
        currentScreen = Screen.MainMenu;
    }

    void OnUserInput(string input)
    {
        // is called whenever the user hits return after having typed characters
        if(input=="menu")
        {
            ShowMainMenu();
            
        }
        else if(currentScreen==Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if(currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }


    }

    // to rename a methode we use ctrl+ R twice
    void RunMainMenu(string input)
    {
        bool isValidNumber = (input == "1" || input == "2" || input == "3");

        if (isValidNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level");
            Terminal.WriteLine("You may tap \"menu\" at any time");

        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("You may tap \"menu\" at any time");
        Terminal.WriteLine("Enter your Password , hint: " + password.Anagram());

    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Password[UnityEngine.Random.Range(0, level1Password.Length)];
                break;
            case 2:
                password = level2Password[UnityEngine.Random.Range(0, level2Password.Length)];
                break;
            case 3:
                password = level3Password[UnityEngine.Random.Range(0, level3Password.Length)];
                break;
            default:
                Debug.LogError("invalid level number");
                break;

        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();

        }
        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        Terminal.WriteLine("You may tap \"menu\" at any time");
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        switch(level)
        {
            case 1:
                Terminal.WriteLine("Have a Book ...");
                Terminal.WriteLine(@"
    _______
   /      /,
  /      //
 /______//
(______(/
            WELL DONE !
");
                break;

            case 2:
                Terminal.WriteLine("My Respect for you");
                Terminal.WriteLine(@"
             _ _          
  _ __   ___ | (_) ___ ___ 
 | '_ \ / _ \| | |/ __/ _ \
 | |_) | (_) | | | (_|  __/
 | .__/ \___/|_|_|\___\___|
 |_|             
            WELL DONE !
");
                break;
            case 3:
                Terminal.WriteLine("");
                Terminal.WriteLine(@"
 _ __   __ _ ___  __ _ 
| '_ \ / _` / __|/ _` |
| | | | (_| \__ \ (_| |
|_| |_|\__,_|___/\__,_|

Welcome to NASA's interal system  !
");
                break;

            default:
                Debug.LogError("invalid Level reached");
                break;

        }
        
    }
}
