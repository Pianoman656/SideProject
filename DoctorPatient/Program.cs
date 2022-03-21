using Microsoft.Extensions;
using DoctorPatient.CLI;
using DoctorPatient.DAO;
using System.IO;
using System.Resources;

namespace DoctorPatient
{
    public class Program
    {
        static void Main(string[] args)
        {

            string connectionString = @"Server=.\SQLEXPRESS;Database=DoctorPatient;Trusted_Connection=True";

            IAppointmentDAO appointmentDao = new AppointmentSqlDao(connectionString);
            IPatientDAO patientDao = new PatientSqlDao(connectionString);
            IDoctorDAO doctorDao = new DoctorSqlDao(connectionString);

            SchedulingApp application = new SchedulingApp(patientDao, doctorDao, appointmentDao);
            application.Run();
        }

    }
}
