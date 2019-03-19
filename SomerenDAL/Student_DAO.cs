using SomerenModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SomerenDAL
{
    public class Student_DAO : Base
    {
        public List<Student> Db_Get_All_Students()
        {
            string query = "SELECT Participant_ID, First_name, Last_name FROM [Participant] WHERE Typeof_participant = 'Student'";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Student> ReadTables(DataTable dataTable)
        {
            List<Student> students = new List<Student>();

            //each row from the database is converted into the student class
            foreach (DataRow dr in dataTable.Rows)
            {
                Student student = new Student()
                {
                    Number = (int)dr["Participant_ID"],
                    Name = (String)(dr["First_name"].ToString()),
                    LastName = (String)(dr["Last_name"].ToString())
                };
                students.Add(student);
            }
            return students;
        }

    }
}
