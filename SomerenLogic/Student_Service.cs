using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SomerenLogic
{
    public class Student_Service
    {
        Student_DAO student_db = new Student_DAO();

        public List<Student> GetStudents()
        {
            try
            {
                List<Student> student = student_db.Db_Get_All_Students();
                return student;
            }
            catch (Exception e)
            {
                MessageBox.Show("Couldn't find 'students' in the database or couldn't connect with the database. \r\n Try again later.");
                string file = "Logfile.txt";

                // Checks if the file exists
                if (!File.Exists("Logfile.txt"))
                {
                    StreamWriter writer = new StreamWriter(file);
                    writer.Close();
                }

                // retrieves previous errors and adds a new one
                string errors = File.ReadAllText(file);
                StreamWriter writer2 = new StreamWriter(file);
                writer2.WriteLine(errors + "\r\n" + e);
                writer2.Close();
                return new List<Student>();
            }

        }

    }
}
