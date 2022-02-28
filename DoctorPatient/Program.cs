using System;
using System.Collections.Generic;
using DoctorPatient.CLI;

namespace DoctorPatient
{
    public class Program
    {
        static void Main(string[] args)
        {
            SchedulingApp application = new SchedulingApp();

            application.Run();
        }

    }
}
