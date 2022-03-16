using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using DoctorPatient.Models;

namespace DoctorPatient.DAO
{
    public class AppointmentSqlDao : IAppointmentDAO
    {
        private readonly string connectionString;
        public AppointmentSqlDao(string connString)
        {
            connectionString = connString;
        }

        public Appointment ReturnAppointment(int appointmentId)
        {
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * " +
                                                "FROM appointment " +
                                                "WHERE appointment_id = @appointment_id;", connection);
                cmd.Parameters.AddWithValue("@appointment_id", appointmentId);

                SqlDataReader reader = cmd.ExecuteReader();
                
                Appointment appointment = new Appointment();
                if (reader.Read())
                {
                    appointment = CreateAppointmentFromReader(reader);
                }
                return appointment;
            }
        } 
        
        //grab all appointments for specific doctors on specific days
        //grab all appointments for a specific patient
        //grab all appointments for specific time lengths ie day week month
        public List<Appointment> ReturnAllAppointments()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * " +
                                                "FROM appointment ", connection);
                SqlDataReader reader = cmd.ExecuteReader();

                List<Appointment> appointments = new List<Appointment>();
                while (reader.Read())
                {
                    Appointment appointment = CreateAppointmentFromReader(reader);
                    appointments.Add(appointment);
                }
                return appointments;
            }
        }

        public Appointment CreateAppointment(Appointment newAppointment)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Appointment (last_name, first_name, start_time, reason_for_visit)" +
                                                "OUTPUT INSERTED.patient_id " +
                                                "VALUES (last_name LIKE @last_name, first_name LIKE @first_name, " +
                                                       "( start_time LIKE @start_time, reason_for_visit LIKE @reason_for_visit", connection);
                cmd.Parameters.AddWithValue("@last_name", newAppointment.PatientId);
                cmd.Parameters.AddWithValue("@first_name", newAppointment.DoctorId);
                cmd.Parameters.AddWithValue("@reason_for_visit", newAppointment.ReasonForVisit);
                cmd.Parameters.AddWithValue("@start_time", newAppointment.StartTime);

                int newProjectId = Convert.ToInt32(cmd.ExecuteScalar());
                return ReturnAppointment(newProjectId);
            }
        }

        public void UpdateAppointment(Appointment updatedAppointment)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Appointment " +
                                                "SET (last_name = @last_name, first_name = @first_name, start_time = @start_time, reason_for_visit = @reason_for_visit)" +
                                                "WHERE appointment_id =  @appointment_id", connection);
                cmd.Parameters.AddWithValue("@last_name", updatedAppointment.PatientId);
                cmd.Parameters.AddWithValue("@first_name", updatedAppointment.DoctorId);
                cmd.Parameters.AddWithValue("@reason_for_visit", updatedAppointment.ReasonForVisit);
                cmd.Parameters.AddWithValue("@start_time", updatedAppointment.StartTime);

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteAppointment(int appointmentId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("Delete Appointment " +
                                                "WHERE appointment_id =  @appointment_id", connection);
                cmd.Parameters.AddWithValue("@appointment_id", appointmentId);

                cmd.ExecuteNonQuery();
            }
        }

        private Appointment CreateAppointmentFromReader(SqlDataReader reader)
        {
            Appointment appointment = new Appointment();
            appointment.AppointmentId = Convert.ToInt32(reader["appointment_id"]);
            appointment.PatientId = Convert.ToInt32(reader["patient_id"]);
            appointment.DoctorId = Convert.ToInt32(reader["doctor_id"]);
            appointment.StartTime = Convert.ToDateTime(reader["start_time"]);
            appointment.ReasonForVisit = Convert.ToString(reader["reason_for_visit"]);


            return appointment;
        }
    }

}
