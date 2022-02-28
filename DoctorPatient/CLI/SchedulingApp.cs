using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorPatient.CLI
{
    public class SchedulingApp
    {
        UIDisplay menu = new UIDisplay();
        public void Run()
        { 
            string mainMenuChoice = menu.DisplayMainMenu();

            while(true)
            {
                Console.WriteLine();
                if (mainMenuChoice == "1")
                {
                    menu.CreateApptMenu();
                }
                else if (mainMenuChoice == "2")
                {
                    menu.DisplaySearchMenu();
                }
                else if (mainMenuChoice == "3")
                {
                    menu.DisplayUpdateMenu();
                }
                else if (mainMenuChoice == "4")
                {
                    menu.DisplayDeleteMenu();
                }
                else if (mainMenuChoice == "0")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("This is an invalid response. Please try again.");
                } 
            }
        }
        
    }
}
