using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevBuild.Utilities;

namespace DevBuild.RecordKeeping {
    class RecordsRepository {
        

        public static string[] AddRecordSubMenuOptions { get; set; } = { };
        /// <summary>
        /// This method allows a user to enter a new student/staff record and add it to our master list of people
        /// </summary>
        /// <param name="masterList">reference to the List of people displayed in our main menu options</param>
        public static void AddRecord(ref List<Person> masterList) {
            if (AddRecordSubMenuOptions.Length < 1) { Console.WriteLine("No options to display"); return; }

            MenuHandling.PrintMenuOptions(AddRecordSubMenuOptions, menuMode: true, messagePrompt: "Is this new record for a: ");
            var userSelection = UserInput.SelectMenuOption(AddRecordSubMenuOptions.Length);
            var personName = UserInput.PromptUntilValidEntry("Please person's name: ", InformationType.Name);
            var personAddress = UserInput.PromptUntilValidEntry("Please enter person's address: ");

            switch (AddRecordSubMenuOptions?[userSelection - 1]) {
                case "Staff member": {
                        var staffSalary = 0.00;
                        var staffSchool = UserInput.PromptUntilValidEntry("Please enter staff member's school: ", InformationType.Alphanumeric);
                        while (!double.TryParse(UserInput.PromptUntilValidEntry("Please enter staff member's salary: ", InformationType.Numeric), out staffSalary)) {
                        }
                        masterList.Add(new Staff(personName, personAddress, staffSchool, staffSalary));
                        break;
                    }
                case "Archived Student":
                case "Student": {
                        var studentProgram = UserInput.PromptUntilValidEntry("Please enter student's program name: ");
                        var studentYear = 0;
                        var studentFee = 0.00;
                        while (!int.TryParse(UserInput.PromptUntilValidEntry("Please enter student's year number: ", InformationType.Numeric), out studentYear)) {
                        }
                        while (!double.TryParse(UserInput.PromptUntilValidEntry("Please enter student's fee: ", InformationType.Numeric), out studentFee)) {
                        }
                        if (AddRecordSubMenuOptions?[userSelection - 1] == "Archived Student") {
                            Console.Write("What was the student's final score? (Enter a number from 0 - 100) ");
                            var studentScore = UserInput.SelectNumberBetween(0, 100);
                            masterList.Add(new ArchivedStudent(personName, personAddress, studentProgram, studentYear, studentFee, studentScore));

                        }
                        else {
                            masterList.Add(new Student(personName, personAddress, studentProgram, studentYear, studentFee));
                        }
                        break;
                    };
                case "Other": {
                        masterList.Add(new Person(personName, personAddress));
                        break;
                    }
                default: {
                        masterList.Add(new Person(personName, personAddress));
                        break;
                    }
            }
        }

        public void UpdateRecord() { }
        
        public static void DeleteRecord(ref List<Person> masterList) {
            MenuHandling.PrintMenuOptions(masterList.ToArray(), menuMode: true);
            Console.WriteLine($"{masterList.Count + 1}.) Go back");
            uint userSelection = UserInput.SelectMenuOption(masterList.Count + 1);
            if (userSelection == masterList.Count + 1) {
                return;
            }
            else {
                YesNoAnswer yesOrNo = UserInput.GetYesOrNoAnswer("Are you sure? (y/n) ");
                switch (yesOrNo) {
                    case YesNoAnswer.Yes: masterList.RemoveAt((int)userSelection - 1); break;
                    case YesNoAnswer.No: break;
                }
            }
        }

    }
}
