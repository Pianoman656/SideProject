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
            string yesNo = Console.ReadLine();
            newPatient.HasInsurance = yesNo.Equals("Y");
            return newPatient;
        }    
    }
}
