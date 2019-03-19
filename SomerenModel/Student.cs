using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Student
    {
        public String Name { get; set; } // Firstname of student
        public String LastName { get; set; }    // Lastname of student
        public int Number { get; set; } // StudentNumber, e.g. 474791    
        public DateTime BirthDate { get; set; } // Birthdate of student e.g. 17-02-2000

    }
}
