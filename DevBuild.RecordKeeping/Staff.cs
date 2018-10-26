using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBuild.RecordKeeping {
    class Staff : Person {
        public string School { get; set; }
        public double Pay { get; set; }

        public Staff(string personName, string personAddress, string employingSchool, double personPay) : base(personName, personAddress) {
            School = employingSchool;
            Pay = personPay;
        }

        public override string ToString() {
            return ($"{base.ToString()}\nSchool: {School}\nPay: ${Pay.ToString("#,###.00")}");
        }
    }
}
