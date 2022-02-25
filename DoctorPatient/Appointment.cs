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
        //length may need to change this is a test

        public string ReasonForVisit { get; set; }
    }
}
        
        

