using System;
using System.Collections.Generic;
using System.Text;
using DoctorPatient.Models;

namespace DoctorPatient.CLI
{
    public class DoctorPatientConsoleHelper : ConsoleService
    {
        public Patient PromptForPatientInfo()
        {
            Patient newPatient = new Patient();
            newPatient.FirstName = PromptForString("First name: ");
            newPatient.LastName = PromptForString("Last name: ");
            newPatient.DateOfBirth = PromptForDate("Birthday: ");
            Console.Write("Does the patient have valid insurance? Y/N: ");
            string yesNo = Console.ReadLine();//YESNO  ----- prompt for YN method
            newPatient.HasInsurance = yesNo.Equals("Y");
            Console.Clear();
            return newPatient;
        }



        public bool VerifyPatientInfo(Patient newPatient)
        { 
            Console.WriteLine("Please verify the following information"); // need to add an option to loop back if the information is incorrect
            Console.WriteLine($"First name: {newPatient.FirstName}");   // option to escape
            Console.WriteLine($"Last name: {newPatient.LastName}");     // option 
            Console.WriteLine($"Birthday: {newPatient.DateOfBirth}");
            if (newPatient.HasInsurance)
                Console.WriteLine("Valid insurance: yes");
            else
                Console.WriteLine("Valid insurance: no");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Does everything look right? Y/N: ");
            string yesNo = Console.ReadLine();
            Console.Clear();
            if (yesNo.Equals("Y")) //YESNO again. dont repeat. consolodate and encapsulate
                
                return true;
            else
                return false;
        }

        public Doctor PromptForNewDoctorInfo()
        {
            Doctor newDoctor = new Doctor();
            newDoctor.FirstName = PromptForString("First name: ");
            newDoctor.LastName = PromptForString("Last name: ");
            newDoctor.Specialty = PromptForString("Specialty: ");
            Pause();
            return newDoctor;
            

        }

    }
}
