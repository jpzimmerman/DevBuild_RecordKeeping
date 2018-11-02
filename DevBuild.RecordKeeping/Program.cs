using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevBuild.Utilities;

namespace DevBuild.RecordKeeping {
    class Program {

        public static string[] mainMenuOptions = { "List Records", "Sort List by Score", "Add Record", "Update Record", "Delete Record", "Exit" };
        public static string[] addRecordSubMenuOptions = { "Student", "Archived Student", "Staff member", "Other" };

        static void Main(string[] args) {
            RecordsRepository.AddRecordSubMenuOptions = addRecordSubMenuOptions;

            List<Person> folks = new List<Person>() {new Person("Jim Flanagan", "1050 Woodward Avenue, Detroit, MI 48226"),
                                                     new Person("Chip Davis", "561 Continental, Dearborn, MI 48126"),
                                                     new Student("Katherine Harper", "1181 Forester Ave, Aurora, OH 44204", "Electrical Engineering", 3, 24000.00)};

            while (true) {
                Console.Write("***********************************************************\n" +
                  "*             Dev.Build(2.0) - Records System             *\n" +
                  "***********************************************************\n\n");
                folks.Sort();
                MenuHandling.PrintMenuOptions(mainMenuOptions, menuMode: true);
                var userSelection = UserInput.SelectMenuOption(mainMenuOptions.Length);

                switch (mainMenuOptions[userSelection - 1]) {
                    case "List Records": MenuHandling.PrintMenuOptions(folks.ToArray(), menuMode: true); break;
                    case "Sort List by Score": folks.Sort(new StudentScoreComparer());  break;
                    case "Add Record": RecordsRepository.AddRecord(ref folks); Console.Clear(); break;
                    case "Update Record": break;
                    case "Delete Record": RecordsRepository.DeleteRecord(ref folks); Console.Clear(); break;
                    case "Exit": return;
                    default: break;
                }
            }
        }
    }
}
