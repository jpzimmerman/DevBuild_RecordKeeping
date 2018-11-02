using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBuild.RecordKeeping {
    class StudentScoreComparer : IComparer<object> {
        public int Compare(object x, object y) {
            if (x is Student && y is Student) {
                ArchivedStudent a = (ArchivedStudent)x;
                ArchivedStudent b = (ArchivedStudent)y;

                if (a?.FinalScore > b?.FinalScore) { return 1; }
                else if (a?.FinalScore < b?.FinalScore) { return -1; }
                else return 0;
            }
            else return 0; 
        }
    }
}