using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorPatient
{
    class UserInterface
    {
        public void DisplayMainMenu()
        {
            Console.WriteLine("Welcome to The Scheduling App");
            Console.WriteLine();
            Console.WriteLine("Select 1 to create an appointment");
            Console.WriteLine("Select 2 to view an appointment");
            Console.WriteLine("Select 3 to update an appointment");
            Console.WriteLine("Select 4 to remove an appointment");
        }


        //user selects 2 in main menu
        public void DisplaySearchMenu()
        {
            Console.WriteLine();
            Console.WriteLine("**Appointment Search**");
            Console.Write("Please enter the last name of the patient: ");
            string lastname = Console.ReadLine(); //2/25/22

        }

    }
}
