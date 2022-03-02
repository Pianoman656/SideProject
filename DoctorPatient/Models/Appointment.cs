using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorPatient.Models
{
    public class Appointment
    {
        public int PatientId{ get; set; }

        public int DoctorId { get; set; }

        public DateTime StartTime { get; set; }

        int LengthOfVisitInMinutes { get; set; } = 30;
        //length may need to change -- for now 30minutes is the statndard

        public string ReasonForVisit { get; set; }

        public Appointment (int patientId, int doctorId, DateTime startTime, string reasonForVisit)
        {
            PatientId = patientId;
            DoctorId = doctorId;
            StartTime = startTime;
            ReasonForVisit = reasonForVisit;
        }
    }
}
        
        

