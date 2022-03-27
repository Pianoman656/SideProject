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
        private readonly IDoctorDAO doctorDao;
        private readonly IPatientDAO patientDao;

        public SchedulingApp(IPatientDAO patientDao, IDoctorDAO doctorDao, IAppointmentDAO appointmentDao)
        {
            this.patientDao = patientDao;
            this.doctorDao = doctorDao;
            this.appointmentDao = appointmentDao;
        }

        public void Run()
        {
            while (true)
            {
                display.MainMenu();

                int choice = display.PromptForInteger("Please enter a menu number", 0, 6);
                
                if (choice == 1)
                {
                    display.CreateAppointmentMenu(); 
                    bool patientExists = helper.PromptForYesNo("Existing patient? Y/N");             
                    //Patient must be in data store before before creating appointment
                    if (!patientExists)
                    {
                        CreatePatientMenuProcess();
                    }
                    else
                    {
                        CreateAppointmentMenuProcess();
                    }
                }
                
                else if (choice == 2)
                {
                    SearchAppointmentMenuProcess();
                }
                
                else if (choice == 3)
                {
                    UpdateAppointmentMenuProcess();
                }
                
                else if (choice == 4)
                {
                    DeleteAppointmentMenuProcess();
                }
                
                else if(choice == 5)
                {
                    bool patientExists = helper.PromptForYesNo("Existing patient? Y/N");
                    //Patient must be in data store before before creating appointment
                    if (!patientExists)
                    {
                        CreatePatientMenuProcess();
                    }
                    else
                    {
                        SearchPatientMenuProcess();
                    }
                }
                else if(choice == 6)
                {
                    display.DoctorMenu();
                    CreateDoctorMenuProcess();
                }
                else 
                {
                    break;
                }
            }
        }
        private void CreatePatientMenuProcess()
        {
            display.PatientMenu();
            Patient newPatientInfo = helper.PromptForPatientInfo();
            bool isVerified = helper.VerifyPatientInfoPrompt(newPatientInfo);

            if (isVerified)
            {
                patientDao.CreatePatient(newPatientInfo);
                helper.PrintSuccess("The new patient has been added!");
                helper.Pause("Press any key to return to the main menu");
            }
            else
            {
                helper.PrintError("No patient added to the data store. Please try again");
                Console.WriteLine();
                helper.Pause("Press any key to return to the main menu"); // or make an appointment?
            }
        }

        private void SearchPatientMenuProcess()
        {
            //search for patient by last name and birthday
            //option to view appointments/ update info
        }
        
        private void CreateDoctorMenuProcess()
        {
            display.DoctorMenu();
            Doctor newDoctorInfo = helper.PromptForNewDoctorInfo();
            bool isVerified = helper.VerifyDoctorInfoPrompt(newDoctorInfo);
            
            if (isVerified)
            {
                doctorDao.CreateDoctor(newDoctorInfo);
                Console.WriteLine();
                helper.PrintSuccess("The new doctor has been added!");
                helper.Pause("Press any key to return to the main menu");
            }
            else
            {
                helper.PrintError("No doctor added to the data store. Please try again");
                Console.WriteLine();
                helper.Pause("Press any key to return to the main menu");
            }
        }
        private void CreateAppointmentMenuProcess()
        {
            display.CreateAppointmentMenu();
            Console.WriteLine();
            Appointment tryAppointment = helper.TryNewAppointment();
            List<Appointment> appointments = appointmentDao.ReturnAllAppointments(tryAppointment);

        }

        private void SearchAppointmentMenuProcess()
        {
            display.SearchAppointmentMenu();
            //search for and display list of appointments by patient last name and DOB
            //pass off to update if needed
        }

        private void UpdateAppointmentMenuProcess()
        {
            display.UpdateAppointmentMenu();
            //update appointment in data store
        }

        private void DeleteAppointmentMenuProcess()
        {
            display.DeleteAppointmentMenu();
        }
            

        
    }
}
    

