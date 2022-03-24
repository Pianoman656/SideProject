using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using DoctorPatient.Models;

namespace DoctorPatient.DAO
{
    public class PatientSqlDao : IPatientDAO
    {
        private readonly string connectionString;

        public PatientSqlDao(string connString)
        {
            connectionString = connString;
        }

        public Patient ReturnPatient(string lastName)
        {
            Patient patient = new Patient();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT patient_id, last_name, first_name, date_of_birth, insurance_verified " +
                                                "FROM patient " +
                                                "WHERE last_name = @last_name;", connection);
                cmd.Parameters.AddWithValue("@last_name", lastName);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    patient = CreatePatientFromReader(reader);
                }
                return patient;
            }
        }

        public Patient CreatePatient(Patient newPatient)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO patient (last_name, first_name, date_of_birth, insurance_verified)" +
                                                "OUTPUT INSERTED.patient_id " +
                                                "VALUES (@last_name, @first_name, @date_of_birth, @insurance_verified);", connection);
                cmd.Parameters.AddWithValue("@last_name", newPatient.LastName);
                cmd.Parameters.AddWithValue("@first_name", newPatient.FirstName);
                cmd.Parameters.AddWithValue("@date_of_birth", newPatient.DateOfBirth);
                cmd.Parameters.AddWithValue("@insurance_verified", newPatient.HasInsurance);
                cmd.ExecuteNonQuery();
                //excecute scalar would be useful if returning a patient by refrencing its primary key
            }
                
            return ReturnPatient(newPatient.LastName);
        }

        public Patient UpdatePatient(Patient updatedPatient)
        {
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Update patient (last_name, first_name, date_of_birth, insurance_verified)" +
                                                    "SET last_name = @last_name, first_name = @first_name, date_of_birth = @date_of_birth, insurance_verified = @insurance_verified" +
                                                    "WHERE patient_id = @patient_id", connection);
                    cmd.Parameters.AddWithValue("patient_id", updatedPatient.PatientId);
                    cmd.Parameters.AddWithValue("@last_name", updatedPatient.LastName);
                    cmd.Parameters.AddWithValue("@first_name", updatedPatient.FirstName);
                    cmd.Parameters.AddWithValue("@date_of_birth", updatedPatient.DateOfBirth);
                    cmd.Parameters.AddWithValue("@insurance_verified", updatedPatient.HasInsurance);
                    cmd.ExecuteNonQuery();
                }
                return ReturnPatient(updatedPatient.LastName);
            }
        }
 
        public void DeletePatient(int patientId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("DELETE FROM patient WHERE patient_id = @patient_id;", conn);
                cmd.Parameters.AddWithValue("@patient_id", patientId);
                cmd.ExecuteNonQuery();
            }
        }

        private Patient CreatePatientFromReader(SqlDataReader reader)
        {
            Patient patient = new Patient();
            patient.PatientId = Convert.ToInt32(reader["patient_id"]);
            patient.LastName = Convert.ToString(reader["last_name"]);
            patient.FirstName = Convert.ToString(reader["first_name"]);
            patient.DateOfBirth = Convert.ToDateTime(reader["date_of_birth"]);
            patient.HasInsurance = Convert.ToBoolean(reader["insurance_verified"]);

            return patient;
        }
    }
}
