using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBuild.RecordKeeping {
    class ArchivedStudent : Student {

        public double FinalScore { get; set; }

        public ArchivedStudent() { }

        public ArchivedStudent(string name, string address, string program, int year, double fee, double finalScore) : base(name, address, program, year, fee) {
            FinalScore = finalScore;
        }

        public override string ToString() {
            return ($"{base.ToString()} {FinalScore}/100");// {Program.PadRight(40)} {Year.ToString().PadRight(3)} {Fee.ToString("$#,###.00").PadRight(15)}");
        }
    }
}
