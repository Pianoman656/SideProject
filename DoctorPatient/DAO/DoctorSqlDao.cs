using DoctorPatient.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace DoctorPatient.DAO
{
    public class DoctorSqlDao : IDoctorDAO
    {
        private readonly string connectionString;
        public DoctorSqlDao(string connString)
        {
            connectionString = connString;
        }

        public Doctor ReturnDoctor(int doctorId)
        {
            Doctor doctor = new Doctor();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT doctor_id, last_name, first_name, specialty " +
                                                "FROM doctor " +
                                                "WHERE doctor_id = @doctor_id;", connection);
                cmd.Parameters.AddWithValue("@doctor_id", doctorId);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    doctor = CreateDoctorFromReader(reader);
                }
                return doctor;
            }
        }

        public IList<Doctor> ReturnAllDoctors()
        {
            IList<Doctor> doctors = new List<Doctor>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM doctor;", connection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Doctor doctor = CreateDoctorFromReader(reader);
                    doctors.Add(doctor);
                }
            }
            return doctors;
        }

        public Doctor CreateDoctor(Doctor newDoctor)
        {
            int doctorId;
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO doctor (last_name, first_name, specialty) " +
                                                "OUTPUT INSERTED.doctor_id " +
                                                "VALUES (@last_name, @first_name, @specialty);", connection);
                cmd.Parameters.AddWithValue("@last_name", newDoctor.LastName);
                cmd.Parameters.AddWithValue("@first_name", newDoctor.FirstName);
                cmd.Parameters.AddWithValue("@specialty", newDoctor.Specialty);
                
                doctorId = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return ReturnDoctor(doctorId);
        }

        public Doctor UpdateDoctorSpecialty(Doctor updatedDoctor)
        {
            Doctor doctorToUpdate = new Doctor();

            using (SqlConnection connection = new SqlConnection())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("UPDATE doctor " +
                                                "SET specialty = @specialty" +
                                                "WHERE doctor_id = @doctor_id;", connection);
                cmd.ExecuteNonQuery();
            }

            return ReturnDoctor(updatedDoctor.DoctorId);
        }
        
        public void DeleteDoctor(int doctorId)
        {
            using(SqlConnection connection = new SqlConnection())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM doctor WHERE doctor_id LIKE @doctor_id", connection);
                cmd.Parameters.AddWithValue("doctor_id", doctorId);

                cmd.ExecuteNonQuery();
            }
        }

        private Doctor CreateDoctorFromReader(SqlDataReader reader)
        {
            Doctor doctor = new Doctor();
            doctor.DoctorId = Convert.ToInt32(reader["doctor_id"]);
            doctor.LastName = Convert.ToString(reader["last_name"]);
            doctor.FirstName = Convert.ToString(reader["first_name"]);
            doctor.Specialty = Convert.ToString(reader["specialty"]);
            return doctor;
        }
    }
}
