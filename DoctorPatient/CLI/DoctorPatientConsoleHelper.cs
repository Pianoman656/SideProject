using System;
using System.Collections.Generic;
using System.Text;
using DoctorPatient.Models;

namespace DoctorPatient.CLI
{           //todos:: 
            //create view if patients aren't valid in the data store.
            //display a list of all avalable/unavaliable slots on specified day, with specified doctor 
            //days - 5 per week monday - friday
            //slots - 16 per day, 8:00 - 5:00 with lunch from 12 - 1
            //validate appointment
            //new day/new doctor options
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
        {   //verify new patient's info before storing
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

        public Appointment ScheduleAppointmentPrompt()
        {
            Appointment newAppointment = new Appointment();
            newAppointment.DoctorLastName = PromptForString("Doctor's Last Name").Trim();
            newAppointment.PatientLastName = PromptForString("Patient's Last Name").Trim();
            newAppointment.PatientDOB = PromptForDate("Patient's DOB");
            newAppointment.StartTime = PromptForDate("Preferred datetime");
            return newAppointment;
        }
       
        public Appointment SearchByLastNameDOB()
        {
 
            Appointment newAppointment = new Appointment();
            newAppointment.PatientLastName = PromptForString("Patient's Last Name").Trim();
            newAppointment.PatientDOB = PromptForDate("Patient's DOB");
            return newAppointment;
        }
        
        public void ListAppointmentsForPatient(List<Appointment> appointments)
        {
            if (appointments.Count == 0 || appointments == null)
            {
                Console.WriteLine("No matching results");
            }
            else
            {
                foreach (Appointment appointment in appointments)
                {
                    Console.WriteLine($"{appointment.PatientFirstName} {appointment.PatientLastName} has an appointment with " + $"Dr.{appointment.DoctorLastName} at {appointment.StartTime}");
                    Console.WriteLine($"Reason for visit: {appointment.ReasonForVisit}");
                    Console.WriteLine();
                }
            }
            Pause();
        }
        public void ListAppointmentsByDay(List<Appointment> appointments)
        {
            if (appointments.Count == 0 || appointments == null)
            {
                Console.WriteLine("No appointments today");
            }
            else
            {
                foreach (Appointment appointment in appointments)
                {
                    Console.WriteLine($"{appointment.PatientFirstName} {appointment.PatientLastName} has an appointment with " + $"Dr.{appointment.DoctorLastName} at {appointment.StartTime} until {appointment.StartTime.AddMinutes(29)}");
                    Console.WriteLine();
                }
            }
            Pause();
        }
        public void SingleAppointmentDetails(Appointment appointment)
        {
            Console.WriteLine($"{appointment.PatientFirstName} {appointment.PatientLastName} has an appointment with " + $"Dr.{appointment.DoctorLastName} at {appointment.StartTime}");
            Console.WriteLine($"Reason for visit: {appointment.ReasonForVisit}");
            Console.WriteLine();
            Pause();
        }        

        public void ListAllDoctors(List<Doctor> doctors)
        {   
            for(int i = 0; i < doctors.Count; i++)
            {
                Console.WriteLine($"Dr.{doctors[i].LastName}   Specialty: {doctors[i].Specialty}");
            }
            Console.WriteLine();
            Pause();
        }
    }
}
