using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorPatient.CLI
{
    public class MenuHeaders : ConsoleService
    {   
        public void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("**Welcome to The Scheduling App**");
            Console.WriteLine($"****{DateTime.Now}****");
            Console.WriteLine("Select 1 to create an appointment");
            Console.WriteLine("Select 2 to  view  an appointment");
            Console.WriteLine("Select 3 to update an appointment");
            Console.WriteLine("Select 4 to remove an appointment");
            Console.WriteLine("Select 5 to add/edit a patient");
            Console.WriteLine("Select 6 to add/edit a doctor");
            Console.WriteLine("Select 0 to exit");
            Console.WriteLine("*********************************");
            Console.WriteLine();
        }

        public void CreateAppointmentMenu()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("****Create New Appointment****");
            Console.WriteLine($"****{DateTime.Now}****");
            Console.WriteLine("******************************");
            Console.WriteLine();
        }

        public void SearchAppointmentMenu()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("*******************Appointment Search******************");
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
