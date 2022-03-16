using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorPatient.Models
{
    public class Appointment
    {// all appointments must have a 30 minute timeslot 
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime StartTime { get; set; }
        public string ReasonForVisit { get; set; }
 
        public Appointment (int patientId, int doctorId, DateTime startTime, string reasonForVisit)
        {
            PatientId = patientId;
            DoctorId = doctorId;
            StartTime = startTime;
            ReasonForVisit = reasonForVisit;
        }

        public Appointment()
        {
            
        }


    }
}
        
        

