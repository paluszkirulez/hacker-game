using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {
    
    // variables region
    string level;
    enum Screen { StartScreen, Password, Win };
    Screen CurrentScreen = Screen.StartScreen;
    string Password;
    System.Random random = new System.Random();
    string check;

    // game state - password

    string[] PasswordsOne = {"oax","trox","fox","brock","cock" };
    string[] PasswordsTwo = { "material", "occupied", "selected", "orthodox" };
    string[] PasswordsThree = { "lumberjack","caterlippar","eclectic","reasonable" };
    // Use this for initialization
    void ShowMainMenu (string YourName) {
        CurrentScreen = Screen.StartScreen;
        Terminal.ClearScreen();
        string greeting = "Hello " + YourName;
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("Please, choose from the below list the institution \n that you want to check:");
        Terminal.WriteLine(" ");
        Terminal.WriteLine("1. The institute");
        Terminal.WriteLine("2. The cave ");
        Terminal.WriteLine("3. The Machine");
    }
    void Start ()
    {   
        ShowMainMenu("Bartek");
    }



    void OnUserInput(string Input)
    {
        if (Input == "menu")
        {
            ShowMainMenu("Bartek");
        }
        else if (CurrentScreen == Screen.StartScreen)
        {
            CurrentScreen = Screen.StartScreen;
            bool choosen_level = "1,2,3".Contains(Input);
            if (Input == "menu")
            {
                ShowMainMenu("Bartek");

            }
            else
            {
                PasswordSelection(Input, choosen_level);
                OnPasswordGenerate(Input);
            }
        }
        else if (CurrentScreen == Screen.Password)
            {

                    if (Password != "")
                    {
                        InputCheck(Input);
                    }

             }

        else if (CurrentScreen == Screen.Win)
        {
            if (Input == "menu")
            {
                ShowMainMenu("Bartek");
            }
        }
 
        
    }

    void OnPasswordGenerate(string Input)
    {
        check = Input;
        if (CurrentScreen == Screen.Password)
        {
            
            if (level == "1")
            {
                print(level);
                Password = PasswordsOne[random.Next(0, PasswordsOne.Length)];
                Terminal.WriteLine("Enter password, hint: " + Password.Anagram());
                // print("Please, enter your password, hint: " + Password.Anagram());
            }
            else if (level == "2")
            {
                Password = PasswordsTwo[random.Next(0, PasswordsTwo.Length)];
                Terminal.WriteLine("Enter password, hint: " + Password.Anagram());
            }
            else if (level == "3")
            {
                Password = PasswordsThree[random.Next(0, PasswordsThree.Length)];
                Terminal.WriteLine("Enter password, hint: " + Password.Anagram());
            }
            else if (check == "menu")
            {
                ShowMainMenu("Bartek");
            }
            //print(Input);
            //InputCheck(Input);
        }

    }

   void InputCheck(string Input)
    {
        print(check = Input);
        if (Input == Password)
        {
            WinInformation(Password);
        }
        else
        {
            AskForPassword();
        }
    }

    void WinInformation(string CorrectPass)
    {
        CurrentScreen = Screen.Win;
        Terminal.ClearScreen();
        WinPrice(CorrectPass);
        Terminal.WriteLine("The password is " + CorrectPass);
        Terminal.WriteLine("You win, password is correct");
        Terminal.WriteLine("to go back to menu, input menu");
        // ShowMainMenu("Bartek");
    }

    void WinPrice(string CorrectPass)
    {

        switch (level)
        {
            case "1":

                Terminal.WriteLine(@"
          ______ _____
        _/      Y      \_
       // ~~ ~~ | ~~ ~  \\
      // ~ ~ ~~ | ~~~ ~~ \\ 
     //________.|.________\\  
    `----------`-'----------'
                ");
                Terminal.WriteLine("Congrats!, You have won a book");
                break;
            case "2":
                Terminal.WriteLine(@"
                   __        .-.
               .-/` .`'.    /\\|
       _(\-/)_/ ,  .   ,\  /\\\/
      {(#b^d#)} .   ./,  |/\\\/
      `-.(Y).-`  ,  |  , |\.-`
           / ~/,_ / ~~~\,__.-`
          ////~    // ~\\
                                  ");
                Terminal.WriteLine("Conbrats!, You have won a racoon!");
                break;
            case "3":
                Terminal.WriteLine(@"
     ================\
     |----------||@  \\   ___
     |____|_____|||_/_\\_|___|_
    <|  ___\    ||     | ____  |
    <| /    |___||_____|/    | |
    ||/  O  |__________/  O  |_||
      \___/ LAND ROVER \___/
                ");
                Terminal.WriteLine("Conbrats!, You have won a truck!");
                break;
        }
    }

    void PasswordSelection(string Input, bool choosen_level)
    {
        Terminal.ClearScreen();
        if (choosen_level)
        {
            level = Input;
            AskForPassword();
            

        }
        else if ("4,5,6,7,8,9,".Contains(Input))
        {
            Terminal.WriteLine("You have gone too far!!!!");
        }

        else
        {
            Terminal.WriteLine("Please, specify correct number, otherwise you will be unable to hack");
        }
    }

    void AskForPassword()
    {
        CurrentScreen = Screen.Password;
        Terminal.ClearScreen();
        Terminal.WriteLine("You have choosen correct level. Number of Level: " + level);
                
    }


}
