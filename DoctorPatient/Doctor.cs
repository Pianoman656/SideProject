using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorPatient
{
    public class Doctor
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Specialty { get; set; }

        public Doctor (string lastName, string firstName, string specialty)
        {
            LastName = lastName;
            FirstName = firstName;
            Specialty = specialty;
        }

        public Doctor()
        { 
        
        }
    }
}
