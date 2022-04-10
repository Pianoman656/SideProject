using System;
using System.Collections.Generic;
using System.Text;
using DoctorPatient.Models;

namespace DoctorPatient.CLI
{
    public class StaticDisplay : ConsoleService
    {   
        public void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("**Welcome to The Scheduling App**");
            Console.WriteLine($"****{DateTime.Now}****");
            Console.WriteLine("Select 1 to create appointment");
            Console.WriteLine("Select 2 to retrieve appointments");
            Console.WriteLine("Select 3 to update appointment");
            Console.WriteLine("Select 4 to delete appointment");
            Console.WriteLine("Select 5 to add/edit a patient");
            Console.WriteLine("Select 6 to add/edit a doctor");
            Console.WriteLine("Select 0 to exit");
            Console.WriteLine("*********************************");
            Console.WriteLine();
        }

        public void CreateAppointmentMenuHeader()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("****Create New Appointment****");
            Console.WriteLine($"****{DateTime.Now}****");
            Console.WriteLine("******************************");
        }
        public void CreateAppointmentMenu()
        {
            CreateAppointmentMenuHeader();
            Console.WriteLine("Select 1 if new patient");
            Console.WriteLine("Select 2 if existing patient");
            Console.WriteLine("Select 3 to return to the main menu");
            Console.WriteLine();
        }
        public void SearchAppointmentMenuHeader()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("*******************Appointment Search******************");
            Console.WriteLine();
        }
        
        public void SearchAppointmentMenu()
        {
            SearchAppointmentMenuHeader();
            Console.WriteLine("Select 1 to search by last name and DOB");
            Console.WriteLine("Select 2 to search by appointment Id");
            Console.WriteLine("Select 3 to list all appointments for a specific date");
            Console.WriteLine("Select 4 to list all appointments for a specific doctor");
            Console.WriteLine("Select 5 to return to the main menu");
            Console.WriteLine();
        }

        public void UpdateAppointmentMenu()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("*******************Change Appointment******************");
            Console.WriteLine();
        }

        public void DeleteAppointmentMenu()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("*******************Cancel Appointment******************");
            Console.WriteLine();
        }

        public void PatientMenu()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("*******************Patient Menu************************");
            Console.WriteLine();
            Console.WriteLine();
        }

        public void SearchPatientMenu()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("************Search For Patient************************");
            Console.WriteLine();
            Console.WriteLine();
        }
        public void UpdatePatientMenu()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("************Update Patient Info************************");
            Console.WriteLine();
            Console.WriteLine();
        }

        public void DoctorMenu()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("*******************Doctor Menu******************");
            Console.WriteLine();
        }
    }
}
