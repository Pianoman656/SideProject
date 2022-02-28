using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorPatient.Models
{
    public class Patient
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Address { get; set; }

        public DateTime DateOfBirth { get; set; }

        public bool HasInsurance { get; set; }

        public Patient(string lastName, string firstName, string address, DateTime dateOfBirth, bool hasInsurance)
        {
            LastName = lastName;
            FirstName = firstName;
            Address = address;
            DateOfBirth = dateOfBirth;
            HasInsurance = hasInsurance;
        }

        public Patient()
        {

        }
    }
}
