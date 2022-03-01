using System;
using System.Collections.Generic;
using System.Text;
using DoctorPatient.CLI;

namespace DoctorPatient.CLI
{
    public class SchedulingApp
    {
        UIDisplay display = new UIDisplay();
        ConsoleService consoleService = new ConsoleService();
        public void Run()
        {
            while (true)
            {
                display.MainMenu();

                int choice = consoleService.PromptForInteger("Please enter a menu number: ", 0, 4);
                if (choice == 1)
                {
                    display.CreateApptMenu();
                }
                else if (choice == 2)
                {
                    display.SearchMenu();
                }
                else if (choice == 3)
                {
                    display.UpdateMenu();
                }
                else if (choice == 4)
                {
                    display.DeleteMenu();
                }
                else
                {
                    break;
                }
            }
        }
    }
}
    

