using DoctorPatient.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace DoctorPatient.DAO
{
    class DoctorSqlDao : IDoctorDAO
    {
        private readonly string connectionString;
        public DoctorSqlDao(string connString)
        {
            connectionString = connString;
        }

        public Doctor ReturnDoctor(int doctorId)
        {
            throw new NotImplementedException();
        }

        public IList<Doctor> ReturnAllDoctors()
        {
            throw new NotImplementedException();
        }

        public Doctor CreateDoctor(Doctor newDoctor)
        {
            throw new NotImplementedException();
        }

        public Doctor UpdateDoctor(Doctor updatedDoctor)
        {
            throw new NotImplementedException();
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
    }
}
