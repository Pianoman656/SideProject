using System;
using System.Collections.Generic;
using System.Text;
using DoctorPatient.Models;


namespace DoctorPatient.DAO
{
    //ideas:
    //return all avaliable appointments - time slots with an avaliable doctor and no patient
    //soonest avaliable option
    //search by doctor option
    //search by time option

    public interface IAppointmentDAO
    {
        /// <summary>
        /// Inserts a new appointment into the data store
        /// </summary>
        /// <param name="newAppointment">The appointment to add to the data store.</param>
        /// <returns>A filled out Appointment object.</returns>
        List<Appointment> CreateAppointment(Appointment newAppointment);

        ///<summary>
        ///Gets an appointment from the data store that has the given id.
        ///If the id is not found, return null.
        ///</summary>
        ///<param name="appointmentId">The id of the appointment to get from the data store.</param>
        ///<returns>A filled out Appointment object.</returns>
        Appointment ReturnAppointment(int appointmentId);

        /// <summary>
        /// Gets all appointments from the data store.
        /// </summary>
        /// <param name="appointment">The partially built appointment object</param>
        /// <returns>All matching appointments as Appointment objects in a List.</returns>
        List<Appointment> ReturnAllApptsByLastNameDOB(Appointment appointment);

        /// <summary>
        /// Gets all appointments from the data store.
        /// </summary>
        /// <param name="beginningOfShift">The BOS on specific day</param>
        /// <param name="endOfShift">The EOS on specific day</param>
        /// <returns>All matching appointments as Appointment objects in a List.</returns>
        public List<Appointment> ReturnAllApptsByDate(DateTime beginningOfShift, DateTime endOfShift);

        /// <summary>
        /// Gets all appointments from the data store with matching doctor.
        /// </summary>
        /// <param name="doctorLastName"></param>
        /// <returns>All matching appointments as Appointment objects in a List.</returns>
        public List<Appointment> ReturnAllApptsByDateAndDoctor(DateTime beginningOfShift, DateTime endOfShift, string doctorLastName);

        ///<summary>
        ///Updates an Appointment to the data store. 
        ///Only called on appointments already in the data store.
        ///</summary>
        ///<param name="updatedAppointment">The Appointment object to update</param>
        void UpdateAppointment(Appointment updatedAppointment);

        ///<summary>
        ///Deletes an Appointment from the data store. 
        ///</summary>
        ///<param name="appointmentId">The id of the Appointment object to delete</param>
        void DeleteAppointment(int appointmentId);
    }
}

