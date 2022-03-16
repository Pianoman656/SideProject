using Microsoft.Extensions.Configuration;
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

            // Get the connection string from the appsettings.json file
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            string connectionString = configuration.GetConnectionString("DoctorPatient");

            
            IAppointmentDAO appointmentDao = new AppointmentSqlDao(connectionString);
            IPatientDAO patientDao = new PatientSqlDao(connectionString);
            IDoctorDAO doctorDao = new DoctorSqlDao(connectionString);

            SchedulingApp application = new SchedulingApp(patientDao, doctorDao, appointmentDao);
            application.Run();
        }

    }
}
