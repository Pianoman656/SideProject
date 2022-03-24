using Microsoft.VisualStudio.TestTools.UnitTesting;
using DoctorPatient.DAO;
using DoctorPatient.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorPatient.DAO.Tests
{
    [TestClass()]
    public class DoctorSqlDaoTests
    {
        [TestMethod()]
        public void ReturnAllDoctors_ReturnsAllDoctors()
        {
            //todo
        }

        private void AssertDoctorsMatch (Doctor expected, Doctor actual, string message)
        {
            Assert.AreEqual(expected.DoctorId, actual.DoctorId, message);
            Assert.AreEqual(expected.LastName, actual.LastName, message);
            Assert.AreEqual(expected.FirstName, actual.FirstName, message);
            Assert.AreEqual(expected.Specialty, actual.Specialty, message);
        }
    }
}