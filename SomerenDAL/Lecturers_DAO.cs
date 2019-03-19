using SomerenModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SomerenDAL
{
    public class Lecturers_DAO : Base
    {
        public List<Teacher> Db_Get_All_Lectures()
        {
            string query = "SELECT Participant_ID, First_name, Last_name, Attendant FROM [Participant] WHERE Typeof_participant = 'Teacher'";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Teacher> ReadTables(DataTable dataTable)
        {
            List<Teacher> teachers = new List<Teacher>();

            //each row from the database is converted into the teacher class
            foreach (DataRow dr in dataTable.Rows)
            {
                Teacher teacher = new Teacher()
                {
                    Number = (int)dr["Participant_ID"],
                    Name = (String)(dr["First_name"].ToString()),
                    LastName = (String)(dr["Last_name"].ToString()),
                    Attendant = (bool)(dr["Attendant"])
                };
                teachers.Add(teacher);
            }
            return teachers;
        }
    }
}
