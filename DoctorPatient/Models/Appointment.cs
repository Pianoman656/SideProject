using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorPatient.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public int DoctorId { get; set; }
        public string DoctorLastName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime PatientDOB { get; set; }
        public int LengthOfVisit { get; set; } = 30;
        public string ReasonForVisit { get; set; }
        
        public Appointment()
        {
            
        }
    }
}
        
        

