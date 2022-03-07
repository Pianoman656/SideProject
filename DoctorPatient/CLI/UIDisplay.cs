using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorPatient.CLI
{
    public class UIDisplay
    {   
        public void MainMenu()
        {
            Console.WriteLine("**Welcome to The Scheduling App**");
            Console.WriteLine($"****{DateTime.Now}****");
            Console.WriteLine("Select 1 to create an appointment");
            Console.WriteLine("Select 2 to  view  an appointment");
            Console.WriteLine("Select 3 to update an appointment");
            Console.WriteLine("Select 4 to remove an appointment");
            Console.WriteLine("Select 5 to add/edit a patient");
            Console.WriteLine("Select 6 to edit employee schedule");
            Console.WriteLine("Select 0 to exit");
            Console.WriteLine("*********************************");
            Console.WriteLine();
        }
        
        //user selects 1 in main menu
        public void CreateApptMenu()
        {
            Console.WriteLine();
            Console.WriteLine("****Create New Appointment****");
            Console.WriteLine("******************************");
            Console.WriteLine();
        }

        //user selects 2 in main menu 
        public void SearchMenu()
        {
            Console.WriteLine();
            Console.WriteLine("*******************Appointment Search******************");
            Console.WriteLine();

        }
        
        //user selects 3 in main menu
        public void UpdateMenu()
        {
            Console.WriteLine();
            Console.WriteLine("*******************Change Appointment******************");
            Console.WriteLine();
            Console.Write("Please enter the last name of the patient: ");
        }

        //user selects 4 in main menu
        public void DeleteMenu()
        {
            Console.WriteLine();
            Console.WriteLine("*******************Cancel Appointment******************");
            Console.WriteLine();
        }

        //user selects 5 in main menu
        public void PatientMenu()
        {
            Console.WriteLine();
            Console.WriteLine("*******************Patient Menu************************");
            Console.WriteLine();
        }

        //user selects 6 in main menu
        public void DoctorMenu()
        {
            Console.WriteLine();
            Console.WriteLine("*******************Doctor Menu******************");
            Console.WriteLine();

    }
}
