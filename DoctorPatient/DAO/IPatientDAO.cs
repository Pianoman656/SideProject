﻿using System;
using System.Collections.Generic;
using System.Text;
using DoctorPatient.Models;

namespace DoctorPatient.DAO
{
    public interface IPatientDAO
    {
        
        
        /// <summary>
        /// Inserts a new patient into the data store
        /// </summary>
        /// <param name="newPatient">The patient to add to the data store.</param>
        /// <returns>A filled out Patient object.</returns>
        Patient CreatePatient(Patient newPatient);
        
        
        
        ///<summary>
        ///Gets a patient from the data store that has the given id.
        ///If the id is not found, return null.
        ///</summary>
        ///<param name="patientId">The id of the patient to get from the data store.</param>
        ///<returns>A filled out Patient object.</returns>
        Patient ReturnPatient(int patientId);

        

        ///<summary>
        ///Updates a Patient to the data store. 
        ///Only called on patients already in the data store.
        ///</summary>
        ///<param name="updatedPatient">The Patient object to update</param>
        Patient UpdatePatient(Patient updatedPatient);

   

        ///<summary>
        ///Deletes a Patient from the data store. 
        ///</summary>
        ///<param name="patientId">The id of the Patient object to delet</param>
        void DeletePatient(int patientId);

    }
}