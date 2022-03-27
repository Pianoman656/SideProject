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
            Patient newPatient = new Patient
            {
                FirstName = PromptForString("First name: "),
                LastName = PromptForString("Last name: "),
                DateOfBirth = PromptForDate("Birthday: ")
            };
            newPatient.HasInsurance = PromptForYesNo("Does the patient have valid insurance? Y/N: ");
            return newPatient;
        }


        public bool VerifyPatientInfoPrompt(Patient newPatient)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Please verify the following information");
                Console.WriteLine();
                Console.WriteLine($"First name: {newPatient.FirstName}");
                Console.WriteLine($"Last name: {newPatient.LastName}");
                Console.WriteLine($"Birthday: {newPatient.DateOfBirth}");
                if (newPatient.HasInsurance)
                    Console.WriteLine("Valid insurance: yes");
                else
                    Console.WriteLine("Valid insurance: no");

                Console.WriteLine();
                Console.WriteLine();
                bool isCorrect = PromptForYesNo("Does this information look correct?");
                Console.Clear();
                if (isCorrect)
                    return true;
                else
                    return false;
            }
        }
        
        public Doctor PromptForNewDoctorInfo()
        {
            Doctor newDoctor = new Doctor
            {
                FirstName = PromptForString("First name"),
                LastName = PromptForString("Last name"),
                Specialty = PromptForString("Specialty")
            };
            return newDoctor;
        }

        public bool VerifyDoctorInfoPrompt(Doctor newDoctor)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Please verify the following information:");
                Console.WriteLine();
                Console.WriteLine($"First name: {newDoctor.FirstName}");
                Console.WriteLine($"Last name: {newDoctor.LastName}");
                Console.WriteLine($"Specialty: {newDoctor.Specialty}");
                Console.WriteLine();
                Console.WriteLine();
                bool isCorrect = PromptForYesNo("Does this information look correct?");
                if (isCorrect)
                    return true;
                else
                    return false;
            }
        }

        public Appointment TryNewAppointment()
        {
            Appointment newAppointment = new Appointment();
            Patient patient = new Patient();
            Doctor doctor = new Doctor();

            patient.LastName = PromptForString("Patient's Last Name").Trim();
            doctor.LastName = PromptForString("Preferred Doctor's Last Name").Trim();
            patient.DateOfBirth = PromptForDate("Patient's DOB");
            newAppointment.StartTime = PromptForDate("Preferred day");
            newAppointment.Patient = patient;
            newAppointment.Doctor = doctor;
            
            return newAppointment;
            //verify patient exists in datastore
            //use this to display a list of all avalable/unavaliable slots on specified day, with specified doctor 
                 //list of days - 5 per week monday - friday
                 //list of slots - 16 per day, 8:00 - 5:00 with lunch from 12 - 1
            //validate appointment
            //else try new day/new doctor
        }
    }
}
