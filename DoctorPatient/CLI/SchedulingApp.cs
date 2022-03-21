using System;
using System.Collections.Generic;
using System.Text;
using DoctorPatient.CLI;
using DoctorPatient.DAO;
using DoctorPatient.Models;

namespace DoctorPatient.CLI
{
    public class SchedulingApp
    {
        private readonly DoctorPatientConsoleHelper helper = new DoctorPatientConsoleHelper();
        private readonly MenuHeaders display = new MenuHeaders();
        private readonly IAppointmentDAO appointmentDao;
        private readonly IDoctorDAO docatorDao;
        private readonly IPatientDAO patientDao;

        public SchedulingApp(IPatientDAO patientDao, IDoctorDAO doctorDao, IAppointmentDAO appointmentDao)
        {
            this.patientDao = patientDao;
            this.docatorDao = doctorDao;
            this.appointmentDao = appointmentDao;
        }

        public void Run()
        {
            while (true)
            {
                display.MainMenu();

                int choice = display.PromptForInteger("Please enter a menu number: ", 0, 4);
                if (choice == 1)
                {
                    display.CreateApptMenu();
                    string yesNo = display.PromptForString("Existing patient? Y/N").ToUpper();
                    //Create new patient before creating appointment
                    if (yesNo.Equals("N"))
                    {
                        Console.Clear();
                        display.PatientMenu();
                        Patient newPatientInfo = helper.PromptForPatientInfo();
                        patientDao.CreatePatient(newPatientInfo);

                    }
                    
                    //if yesNo = N,  call 'createpatient' with string N
                    //use N to call 'createappt' AFTER 'createpatient'
                }
                else if (choice == 2)
                {
                    display.SearchMenu();
                    string lastName = display.PromptForString("Please enter the last name of the patient to search: ").ToLower();
                    //call returnpatient with the string lastName passed in as a parameter 
                }
                else if (choice == 3)
                {
                    display.UpdateMenu();
                    string lastName = display.PromptForString("Please enter the last name of the patient to update: ").ToLower();
                    //call returnpatient with the string lastName passed in as a parameter 
                }
                else if (choice == 4)
                {
                    display.DeleteMenu();
                    string lastName = display.PromptForString("Please enter the last name of the patient to remove from the system: ").ToLower();
                    //call returnpatient with the string lastName passed in as a parameter 
                }
                else if(choice == 5)
                {
                    display.PatientMenu();
                    //ADD OPTION TO UPDATE
                    Patient newPatientInfo = helper.PromptForPatientInfo();
                    patientDao.CreatePatient(newPatientInfo);
                }
                else if(choice == 6)
                {
                    display.DoctorMenu();
                }
                else 
                {
                    break;
                }
            }
        }
    }
}
    

