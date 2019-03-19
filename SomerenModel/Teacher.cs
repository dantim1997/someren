using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Teacher
    {
        public String Name { get; set; } // Firstname of teacher
        public int Number { get; set; } // LecturerNumber, e.g. 47198

        public String LastName { get; set; }    // Lastname of teacher 
        public bool Attendant { get; set; }  // If teacher is Attendant
    }
}
