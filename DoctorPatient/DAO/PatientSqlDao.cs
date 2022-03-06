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
                SqlCommand cmd = new SqlCommand("SELECT patient_id, last_name, first_name, address, date_of_birth, has_insurance " +
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
            Patient patient = new Patient();
            return patient;
        }

        public Patient UpdatePatient(Patient updatedPatient)
        {
            Patient patient = new Patient();
            return patient;
        }

 
        public void DeletePatient(string lastName)
        {

        }

        private Patient CreatePatientFromReader(SqlDataReader reader)
        {
            Patient patient = new Patient();
            patient.PatientId = Convert.ToInt32(reader["patient_id"]);
            patient.LastName = Convert.ToString(reader["last_name"]);
            patient.FirstName = Convert.ToString(reader["first_name"]);
            patient.Address = Convert.ToString(reader["address"]);
            patient.DateOfBirth = Convert.ToDateTime(reader["last_name"]);
            patient.HasInsurance = Convert.ToBoolean(reader["birth_date"]);

            return patient;
        }
    }
}
