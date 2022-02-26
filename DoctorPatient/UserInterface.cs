﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorPatient
{
    public class UserInterface
    {
        public string DisplayMainMenu()
        {
            Console.WriteLine("**Welcome to The Scheduling App**");
            Console.WriteLine("*********************************");
            Console.WriteLine("Select 1 to create an appointment");
            Console.WriteLine("Select 2 to  view  an appointment");
            Console.WriteLine("Select 3 to update an appointment");
            Console.WriteLine("Select 4 to remove an appointment");
            Console.WriteLine("*********************************");
            Console.WriteLine();
            Console.Write("Please select a menu number: ");
            string displayMenuChoice = Console.ReadLine();
            return displayMenuChoice;
        }
        
        
        //user selects 1 in main menu - starts 'createappt' OR 'createpatient' followed by 'createappt'
        public string CreateApptMenu()
        {
            Console.WriteLine();
            Console.WriteLine("****Create New Appointment****");
            Console.WriteLine("******************************");
            Console.Write    ("Is this a new patient? Y/N: ");
            string newPatientYN = Console.ReadLine();
            return newPatientYN;
        }


        //user selects 2 in main menu - send lastname string to search
        public string DisplaySearchMenu()
        {
            Console.WriteLine();
            Console.WriteLine("*******************Appointment Search******************");
            Console.WriteLine();
            Console.Write    ("Please enter the last name of the patient: ");
            string lastName = Console.ReadLine();
            return lastName;
        }
        
        
        //user selects 3 in main menu, string search followed by update
        public string DisplayUpdateMenu()
        {
            Console.WriteLine();
            Console.WriteLine("*******************Appointment Update******************");
            Console.WriteLine();
            Console.Write("Please enter the last name of the patient: ");
            string lastName = Console.ReadLine();
            return lastName;
        }


        //user selects 4 in main menu, appointment deleted 
        public string DisplayDeleteMenu()
        {
            Console.WriteLine();
            Console.WriteLine("*******************Appointment Delete******************");
            Console.WriteLine();
            Console.Write("Please enter the last name of the patient: ");
            string lastName = Console.ReadLine();
            return lastName;
        }

    }
}
