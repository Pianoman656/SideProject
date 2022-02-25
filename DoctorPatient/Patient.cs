using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorPatient
{
    public class Patient
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Address { get; set; }

        public bool HasInsurance { get; set; }

        public Patient(string lastName, string firstName, string address, bool hasInsurance)
        {
            LastName = lastName;
            FirstName = firstName;
            Address = address;
            HasInsurance = hasInsurance;
        }

        public Patient()
        {

        }
    }
}
