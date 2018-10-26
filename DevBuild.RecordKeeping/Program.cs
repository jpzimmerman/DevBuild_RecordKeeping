using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevBuild.Utilities;

namespace DevBuild.RecordKeeping {
    class Program {

        public static string[] mainMenuOptions = { "List Records", "Add Record", "Update Record", "Delete Record" };
        public static string[] addRecordSubMenuOptions = { "Student", "Staff member", "Neither" };

        static void Main(string[] args) {
            uint userSelection = 0;

            List<Person> folks = new List<Person>() {   new Person("Jim", "1050 Woodward Avenue, Detroit, MI 48226"),
                                                        new Student("Katherine", "1181 Forester Ave, Aurora, OH 44204", "Electrical Engineering Technology", 3, 24000.00),
                                                        new Staff("Dr. Jack Ledford", "110 Continental Ave, Brighton, NY 14620", "University of Rochester", 92000) };

            while (true) {
                Console.Write("***********************************************************\n" +
                  "*             Dev.Build(2.0) - Records System             *\n" +
                  "***********************************************************\n\n");

                MenuHandling.PrintMenuOptions(mainMenuOptions, menuMode: true);
                userSelection = UserInput.SelectMenuOption(mainMenuOptions.Length);

                switch (mainMenuOptions[userSelection - 1]) {
                    case "List Records": MenuHandling.PrintMenuOptions(folks.ToArray(), menuMode: true); break;
                    case "Add Record": AddRecord(ref folks); break;
                    case "Update Record": break;
                    case "Delete Record": DeleteRecord(ref folks);  break;
                    default: break;
                }
            }
        }

        public static void AddRecord(ref List<Person> masterList) {
            MenuHandling.PrintMenuOptions(addRecordSubMenuOptions, menuMode: true, messagePrompt: "Is this new record for a: ");
            var userSelection = UserInput.SelectMenuOption(addRecordSubMenuOptions.Length);

            var personName = UserInput.PromptUntilValidEntry("Please person's name: ", InformationType.Name);
            var personAddress = UserInput.PromptUntilValidEntry("Please enter person's address: ");

            switch (addRecordSubMenuOptions[userSelection - 1]) {
                case "Staff member": {
                        var staffSalary = 0.00;
                        var staffSchool = UserInput.PromptUntilValidEntry("Please enter staff member's school: ", InformationType.Alphanumeric);
                        while (!double.TryParse(UserInput.PromptUntilValidEntry("Please enter staff member's salary: ", InformationType.Numeric), out staffSalary)) {
                        }
                        masterList.Add(new Staff(personName, personAddress, staffSchool, staffSalary));
                        break;
                    }
                case "Student": {
                        var studentProgram = UserInput.PromptUntilValidEntry("Please enter student's program name: ");
                        var studentYear = 0;
                        var studentFee = 0.00;
                        while (!int.TryParse(UserInput.PromptUntilValidEntry("Please enter student's year number: ", InformationType.Numeric), out studentYear)) {
                        }
                        while (!double.TryParse(UserInput.PromptUntilValidEntry("Please enter student's year number: ", InformationType.Numeric), out studentFee)) {
                        }
                        masterList.Add(new Student(personName, personAddress, studentProgram, studentYear, studentFee));
                        break;
                    };
                case "Neither": {
                        masterList.Add(new Person(personName, personAddress));
                        break;
                    }
            }
        }

        public void UpdateRecord() { }

        public static void DeleteRecord(ref List<Person> masterList) {
            MenuHandling.PrintMenuOptions(masterList.ToArray(), menuMode: true);
            uint userSelection = UserInput.SelectMenuOption(masterList.Count);
            YesNoAnswer yesOrNo = UserInput.GetYesOrNoAnswer("Are you sure? (y/n) ");
            switch (yesOrNo) {
                case YesNoAnswer.Yes: masterList.RemoveAt((int)userSelection - 1);  break;
                case YesNoAnswer.No: break;
            }

        }
    }
}
