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

        public Doctor()
        {
            
        }
    }
}
