using System;

namespace DoctorPatient
{
    public class Scheduler
    {
        //create appointment CRUD
        public Appointment CreateAppointment(Park park)
        {
            int newParkId;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO park (park_name, date_established, area, has_camping) " +
                                                "OUTPUT INSERTED.park_id " +
                                                "VALUES (@park_name, @date_established, @area, @has_camping);", conn);
                cmd.Parameters.AddWithValue("@park_name", park.ParkName);
                cmd.Parameters.AddWithValue("@date_established", park.DateEstablished);
                cmd.Parameters.AddWithValue("@area", park.Area);
                cmd.Parameters.AddWithValue("@has_camping", park.HasCamping);

                newParkId = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return GetPark(newParkId);
        }

        //reference - check if time slot is open

        //reference - check if doctor is avaliable

        //Update appointment

        //Delete appointment

    }
}
