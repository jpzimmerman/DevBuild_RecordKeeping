using System;
using System.Collections.Generic;
using System.Linq;

namespace DevBuild.RecordKeeping {
    
    class Person: IComparable {
        public static string[] commonHonorifics = { "Mx", "Ms.", "Dr.", "Mr.", "Mrs.", "M." };

        public string Name { get; set; } = "";

        public string   Address { get; set; } = "";
        public string   FirstName { get; } = "";
        public string   LastName  { get; } = "";
        private readonly string _honorific = "";

        public Person() { }

        public Person(string personName, string personAddress) {
            Name = personName.Trim();
            string[] splitName = personName.Split(' ');
            if (splitName.Length > 1) {
                if (commonHonorifics.Contains<string>(splitName[0])) { _honorific = splitName[0]; }
                FirstName = String.IsNullOrEmpty(_honorific) ? splitName[0] : splitName[1];
                LastName = splitName[splitName.Length - 1];
            }
            else {
                FirstName = personName;
                LastName = "[Unknown Last Name]";
            }

            Address = personAddress;
        }

        public string Honorific { get { return _honorific; } }

        public override string ToString() {
            return /*this.GetType().bName.PadRight(15)*/$"{(LastName + ",").PadRight(10)}{(String.IsNullOrEmpty(_honorific)? "" : _honorific + " ")}{FirstName.PadRight(10)} {Address.PadRight(40)}";
        }

        public int CompareTo(object obj) { 
            int lastNameResult = LastName.CompareTo((obj as Person).LastName);
            return (lastNameResult == 0 ? FirstName.CompareTo((obj as Person).FirstName) : lastNameResult);
        }
    }
}