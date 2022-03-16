using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorPatient.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string LastName { get; set; }

        public string FirstName { get; set; }


        public DateTime DateOfBirth { get; set; }

        public bool HasInsurance { get; set; }

        public Patient(int patientId, string lastName, string firstName, DateTime dateOfBirth, bool hasInsurance)
        {
            PatientId = patientId;
            LastName = lastName;
            FirstName = firstName;
            DateOfBirth = dateOfBirth;
            HasInsurance = hasInsurance;
        }

        public Patient()
        {

        }
    }
}
