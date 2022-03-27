using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorPatient.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime StartTime { get; set; }
        public int LengthOfVisit { get; set; } = 30;
        public string ReasonForVisit { get; set; }
        
        public Appointment()
        {
            
        }
    }
}
        
        

