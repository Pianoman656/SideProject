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
        private readonly StaticDisplay display = new StaticDisplay();
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
                    CreateAppointmentMenuProcess();
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
                helper.Pause("Press any key to continue.");
            }
            else
            {
                helper.PrintError("No patient added to the data store. Please try again.");
                Console.WriteLine();
                helper.Pause("Press any key to continue.");
            }
        }

        private void SearchPatientMenuProcess()
        {
            //someday:
            //search for patient by last name and birthday
            //ability to update patient info
            //option to view appointments
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
            int menuChoice = helper.PromptForInteger("Please enter a menu option", 1, 3);
            if (menuChoice != 3) 
            {
                if (menuChoice == 1)
                {
                    CreatePatientMenuProcess();
                }
                display.CreateAppointmentMenuHeader();

                
                helper.ListAllDoctors(doctorDao.ReturnAllDoctors());
                Appointment tryAppointment = helper.ScheduleAppointmentPrompt();
                
                //this is a good jumping off point for restricting hours/days of week
                //List<Appointment> dailyAppointments = appointmentDao.ReturnAllApptsByDa(tryAppointment.StartTime);
                
            }

            //helper.DisplayAppointments(appointmentDao.CreateAppointment(patientPreferred));*/
        }

        private void SearchAppointmentMenuProcess()
        {
            display.SearchAppointmentMenu();
            
            int choice = helper.PromptForInteger("Please enter a menu number");

            display.SearchAppointmentMenuHeader();
            switch(choice)
            {
                case 1:
                    helper.ListAppointmentsForPatient(appointmentDao.ReturnAllApptsByLastNameDOB(helper.SearchByLastNameDOB()));
                    break;
                case 2:
                    helper.SingleAppointmentDetails(appointmentDao.ReturnAppointment(helper.PromptForInteger("Enter appointment#")));
                    break;
                case 3:
                    DateTime targetDayBOS = helper.PromptForDate("Enter date").AddHours(8);
                    DateTime targetDayEOS = targetDayBOS.AddHours(9);
                    helper.ListAppointmentsByDay(appointmentDao.ReturnAllApptsByDate(targetDayBOS,targetDayEOS));
                    break;
                case 4:
                    targetDayBOS = helper.PromptForDate("Enter date").AddHours(8);
                    targetDayEOS = targetDayBOS.AddHours(8);
                    string doctor = helper.PromptForString("Enter doctor's last name");
                    helper.ListAppointmentsByDay(appointmentDao.ReturnAllApptsByDateAndDoctor(targetDayBOS,targetDayEOS,doctor));
                    break;
            }
            
        }

        private void UpdateAppointmentMenuProcess()
        {
            display.UpdateAppointmentMenu();
        }

        private void DeleteAppointmentMenuProcess()
        {
            display.DeleteAppointmentMenu();
        }
            

        
    }
}
    

