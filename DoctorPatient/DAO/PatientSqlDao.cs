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
                SqlCommand cmd = new SqlCommand("SELECT patient_id, last_name, first_name, date_of_birth, has_insurance " +
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
                SqlCommand cmd = new SqlCommand("INSERT INTO patient (last_name, first_name, date_of_birth, has_insurance)" +
                                                "OUTPUT INSERTED.patient_id " +
                                                "VALUES (last_name LIKE @last_name, first_name LIKE @first_name, " +
                                                       "( date_of_birth LIKE @date_of_birth, has_insurance LIKE @has_insurance", connection);
                cmd.Parameters.AddWithValue("@last_name", newPatient.LastName);
                cmd.Parameters.AddWithValue("@first_name", newPatient.FirstName);
                cmd.Parameters.AddWithValue("@date_of_birth", newPatient.DateOfBirth);
                cmd.Parameters.AddWithValue("@has_insurance", newPatient.HasInsurance);
            }
                
            return ReturnPatient(newPatient.LastName);
        }

        public void UpdatePatient(Patient updatedPatient)
        {
            {
                Patient patient = new Patient();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Update patient (last_name, first_name, date_of_birth, has_insurance)" +
                                                    "SET last_name = @last_name, first_name = @first_name, date_of_birth = @date_of_birth, has_insurance = @has_insurance" +
                                                    "WHERE patient_id = @patient_id", connection);
                    cmd.Parameters.AddWithValue("patient_id", patient.PatientId);
                    cmd.Parameters.AddWithValue("@last_name", patient.LastName);
                    cmd.Parameters.AddWithValue("@first_name", patient.FirstName);
                    cmd.Parameters.AddWithValue("@date_of_birth", patient.DateOfBirth);
                    cmd.Parameters.AddWithValue("@has_insurance", patient.HasInsurance);
                
                    cmd.ExecuteNonQuery();
                }
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
            patient.DateOfBirth = Convert.ToDateTime(reader["last_name"]);
            patient.HasInsurance = Convert.ToBoolean(reader["birth_date"]);

            return patient;
        }
    }
}
