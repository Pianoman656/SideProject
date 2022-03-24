using System;
using System.Collections.Generic;
using System.Text;
using DoctorPatient.Models;

namespace DoctorPatient.DAO
{
    public interface IPatientDAO
    {
        

        ///<summary>
        ///Gets a patient from the data store that has the given last name.
        ///If the last name is not found, return null.
        ///</summary>
        ///<param name="patientId">The id of the patient to get from the data store.</param>
        ///<returns>A filled out Patient object.</returns>
        Patient ReturnPatient(string lastName);
        
        
        /// <summary>
        /// Inserts a new patient into the data store
        /// </summary>
        /// <param name="newPatient">The patient to add to the data store.</param>
        /// <returns>A filled out Patient object.</returns>
        Patient CreatePatient(Patient newPatient);
        

        ///<summary>
        ///Updates a Patient to the data store. 
        ///Only called on patients already in the data store.
        ///</summary>
        ///<param name="updatedPatient">The Patient object to update</param>
        Patient UpdatePatient(Patient updatedPatient);

  

    }
}
