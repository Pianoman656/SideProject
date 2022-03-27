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

        public Patient()
        {

        }
    }
}
