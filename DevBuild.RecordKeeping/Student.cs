using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBuild.RecordKeeping {
    class Student : Person, IComparable {
        public string   Program { get; set; }
        public int      Year { get; set; }
        public double   Fee { get; set; }

        public Student() { }

        public Student(string personName, string personAddress, string personProgram, int schoolYear, double schoolFee) : base(personName, personAddress) {
            Program = personProgram;
            Year = schoolYear;
            Fee = schoolFee;
        }

        public override string ToString() {
            return ($"{base.ToString()} {Program.PadRight(24)} {Year.ToString().PadRight(3)} {Fee.ToString("$#,###.00").PadRight(15)}");
        }
    }
}
