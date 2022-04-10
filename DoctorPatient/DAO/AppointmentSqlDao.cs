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
                SqlCommand cmd = new SqlCommand("SELECT a.appointment_id, p.patient_id, p.date_of_birth, d.doctor_id, " +
                                                     "d.last_name AS doctor_last_name, p.last_name AS patient_last_name, " +
                                                     "p.first_name AS patient_first_name, a.start_time, a.reason_for_visit " +
                                                 "FROM appointment a " +
                                                 "JOIN patient p " +
                                                 "ON a.patient_id = p.patient_id " +
                                                 "JOIN doctor d " +
                                                 "ON a.doctor_id = d.doctor_id " +
                                                 "WHERE a.appointment_id = @appointment_id ", connection);
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

        public List<Appointment> ReturnAllApptsByLastNameDOB(Appointment appointment)
        {
            List<Appointment> appointments = new List<Appointment>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT a.appointment_id, p.patient_id, p.date_of_birth, d.doctor_id, " +
                                                    "d.last_name AS doctor_last_name, p.last_name AS patient_last_name, " +
                                                    "p.first_name AS patient_first_name, a.start_time, a.reason_for_visit " +
                                                "FROM appointment a " +
                                                "JOIN patient p " +
                                                "ON a.patient_id = p.patient_id " +
                                                "JOIN doctor d " +
                                                "ON a.doctor_id = d.doctor_id " +
                                                "WHERE (p.last_name LIKE @patient_last_name " +
                                                "AND p.date_of_birth = @patient_date_of_birth) ", connection);
                cmd.Parameters.AddWithValue("@patient_last_name", appointment.PatientLastName);
                cmd.Parameters.AddWithValue("@patient_date_of_birth", appointment.PatientDOB);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Appointment newAppointment = CreateAppointmentFromReader(reader);
                    appointments.Add(newAppointment);
                }
                //grab all appointments for specific doctors
            }   //grab all appointments for specific days
            return appointments;
        }

        public List<Appointment> ReturnAllApptsByDateAndDoctor(DateTime beginningOfShift, DateTime endOfShift, string doctorLastName)
        {
            List<Appointment> appointments = new List<Appointment>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT a.appointment_id, p.patient_id, p.date_of_birth, d.doctor_id, " +
                                                    "d.last_name AS doctor_last_name, p.last_name AS patient_last_name, " +
                                                    "p.first_name AS patient_first_name, a.start_time AS appointment_start_time, a.reason_for_visit " +
                                                "FROM appointment a " +
                                                "JOIN patient p " +
                                                "ON a.patient_id = p.patient_id " +
                                                "JOIN doctor d " +
                                                "ON a.doctor_id = d.doctor_id " +
                                                "WHERE a.start_time >= @beginning_of_shift " +
                                                "AND a.start_time <= @end_of_shift " +
                                                "AND d.last_name LIKE @doctor_last_name", connection);
                cmd.Parameters.AddWithValue("@beginning_of_shift", beginningOfShift);
                cmd.Parameters.AddWithValue("@end_of_shift", endOfShift);
                cmd.Parameters.AddWithValue("@doctor_last_name", doctorLastName);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Appointment newAppointment = CreateAppointmentFromReader(reader);
                    appointments.Add(newAppointment);
                }
                //grab all appointments for specific doctors on specific days
            } 
            return appointments;
        }

        public List<Appointment> ReturnAllApptsByDate(DateTime beginningOfShift, DateTime endOfShift)
        {
            List<Appointment> appointments = new List<Appointment>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT a.appointment_id, p.patient_id, p.date_of_birth, d.doctor_id, " +
                                                    "d.last_name AS doctor_last_name, p.last_name AS patient_last_name, " +
                                                    "p.first_name AS patient_first_name, a.start_time AS appointment_start_time, a.reason_for_visit " +
                                                "FROM appointment a " +
                                                "RIGHT JOIN patient p " +
                                                "ON a.patient_id = p.patient_id " +
                                                "RIGHT JOIN doctor d " +
                                                "ON a.doctor_id = d.doctor_id " +
                                                "WHERE a.start_time >= @beginning_of_shift " +
                                                "AND a.start_time <= @end_of_shift " +
                                                "ORDER BY a.start_time", connection);
                cmd.Parameters.AddWithValue("@beginning_of_shift", beginningOfShift);
                cmd.Parameters.AddWithValue("@end_of_shift", endOfShift);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Appointment newAppointment = CreateAppointmentFromReader(reader);
                    appointments.Add(newAppointment);
                }
                //grab all appointments for specific doctors on specific days
            }
            return appointments;
        }

        public List<Appointment> CreateAppointment(Appointment newAppointment)
        {/////
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Appointment (last_name, first_name, start_time, reason_for_visit)" +
                                                "OUTPUT INSERTED.patient_id " +
                                                "VALUES (last_name = @last_name, first_name = @first_name, " +
                                                       "( start_time = @start_time, reason_for_visit = @reason_for_visit", connection);
                cmd.Parameters.AddWithValue("@last_name", newAppointment.PatientId);
                cmd.Parameters.AddWithValue("@first_name", newAppointment.DoctorId);
                cmd.Parameters.AddWithValue("@reason_for_visit", newAppointment.ReasonForVisit);
                cmd.Parameters.AddWithValue("@start_time", newAppointment.StartTime);

                int newAppointmentId = Convert.ToInt32(cmd.ExecuteScalar());

                Appointment createdAppointment = ReturnAppointment(newAppointmentId);
                List<Appointment> appointmentContainer = new List<Appointment>();
                appointmentContainer.Add(createdAppointment);

                return appointmentContainer;
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
            appointment.PatientDOB = Convert.ToDateTime(reader["date_of_birth"]);
            appointment.DoctorId = Convert.ToInt32(reader["doctor_id"]);
            appointment.DoctorLastName = Convert.ToString(reader["doctor_last_name"]);
            appointment.PatientLastName = Convert.ToString(reader["patient_last_name"]);
            appointment.PatientFirstName = Convert.ToString(reader["patient_first_name"]);
            appointment.StartTime = Convert.ToDateTime(reader["appointment_start_time"]);
            appointment.ReasonForVisit = Convert.ToString(reader["reason_for_visit"]);


            return appointment;
        }

    }

}
