using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBuild.RecordKeeping {
    
    class Person {
        public string Name { get; set; }
        public string Address { get; set; }

        public Person(string personName, string personAddress) {
            Name = personName;
            Address = personAddress;
        }

        public override string ToString() {
            return $"\n{this.GetType().Name}" +
                   $"\nName: {Name}" +
                   $"\nAddress: {Address}";
        }
    }
}
