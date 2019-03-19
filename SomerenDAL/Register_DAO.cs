using SomerenModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace SomerenDAL
{
    public class Register_DAO : Base
    {
        public List<Register> Db_Get_All_Registers()
        {
            string query = "SELECT Name FROM [Participant] WHERE Typeof_participant = 'Teacher'";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Register> ReadTables(DataTable dataTable)
        {
            List<Register> registers = new List<Register>();

            //each row from the database is converted into the register class
            foreach (DataRow dr in dataTable.Rows)
            {
                Register register = new Register()
                {
                    Register_ID = (int)dr["Register_ID"],
                    Student_ID = (int)dr["Student_ID"],
                    Drink_ID = (int)dr["Drink_ID"],
                    Date_created = (DateTime)dr["Date_created"],
                };
                registers.Add(register);
            }
            return registers;
        }
    }
}
