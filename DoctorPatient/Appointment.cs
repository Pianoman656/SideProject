using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorPatient
{
    public class Appointment
    {
        public Patient Patient { get; set; }

        public Doctor Doctor { get; set; }

        public DateTime StartTime { get; set; }

        int LengthOfVisitInMinutes { get; set; } = 30;
        //length may need to change 

        public string ReasonForVisit { get; set; }

        public Appointment (Patient patient, Doctor doctor, DateTime startTime, string reasonForVisit)
        {
            Patient = patient;
            Doctor = doctor;
            StartTime = startTime;
            ReasonForVisit = reasonForVisit;
        }
    }
}
        
        

