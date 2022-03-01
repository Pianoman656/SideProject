using System;
using System.Collections.Generic;
using System.Text;
using DoctorPatient.Models;

namespace DoctorPatient.DAO
{
    public interface IDoctorDao
    {
        /// <summary>
        /// Inserts a new doctor into the data store
        /// </summary>
        /// <param name="newDoctor">The doctor to add to the data store.</param>
        /// <returns>A filled out Doctor object.</returns>
        Doctor CreateDoctor(Doctor newDoctor);

        ///<summary>
        ///Gets a doctor from the data store that has the given id.
        ///If the id is not found, return null.
        ///</summary>
        ///<param name="doctorId">The id of the doctor to get from the data store.</param>
        ///<returns>A filled out Doctor object.</returns>
        Doctor ReturnDoctor(int doctorId);

        /// <summary>
        /// Gets all doctors from the data store.
        /// </summary>
        /// <returns>All doctors as Doctor objects in an IList.</returns>
        IList<Doctor> ReturnAllDoctors();

        ///<summary>
        ///Updates a Doctor to the data store. 
        ///Only called on doctors already in the data store.
        ///</summary>
        ///<param name="updatedDoctor">The Doctor object to update</param>
        Doctor UpdateDoctor(Doctor updatedDoctor);

        ///<summary>
        ///Deletes a Doctor from the data store. 
        ///</summary>
        ///<param name="doctorId">The id of the Doctor object to delet</param>
        void DeleteDoctor(int doctorId);
    }
}
