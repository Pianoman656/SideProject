using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorPatient.Models
{
    public class Doctor
    {
        public int DoctorId { get; set;  }
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Specialty { get; set; }

        //add schedule

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
