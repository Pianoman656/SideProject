using System;
using System.Collections.Generic;
using System.Text;
using DoctorPatient.CLI;
using DoctorPatient.DAO;

namespace DoctorPatient.CLI
{
    public class SchedulingApp
    {
        UIDisplay display = new UIDisplay();
        ConsoleService service = new ConsoleService();
        public void Run()
        {
            while (true)
            {
                display.MainMenu();

                int choice = service.PromptForInteger("Please enter a menu number: ", 0, 4);
                if (choice == 1)
                {
                    display.CreateApptMenu();
                    string yesNo = service.PromptForString("Existing patient? Y/N").ToUpper();
                    //if yesNo = Y , call createappointment
                    
                    //if yesNo = N,  call 'createpatient' with string N
                    //use N to call 'createappt' AFTER 'createpatient'
       
                   
                }
                else if (choice == 2)
                {
                    display.SearchMenu();
                    string lastName = service.PromptForString("Please enter the last name of the patient to search: ").ToLower();
                    //call returnpatient with the string lastName passed in as a parameter 
                }
                else if (choice == 3)
                {
                    display.UpdateMenu();
                    string lastName = service.PromptForString("Please enter the last name of the patient to update: ").ToLower();
                    //call returnpatient with the string lastName passed in as a parameter 
                }
                else if (choice == 4)
                {
                    display.DeleteMenu();
                    string lastName = service.PromptForString("Please enter the last name of the patient to remove from the system: ").ToLower();
                    //call returnpatient with the string lastName passed in as a parameter 
                }
                else if(choice == 5)
                {
                    display.PatientMenu();
                    //navigate to patient edit
                }
                else if(choice == 6)
                {
                    display.DoctorMenu
                }
                else 
                {
                    break;
                }
            }
        }
    }
}
    

