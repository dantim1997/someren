using SomerenModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace SomerenDAL
{
    public class Drink_DAO : Base
    {
        public List<Drink> Db_Get_All_Drinks()
        {
            string query = "SELECT Name FROM [Participant] WHERE Typeof_participant = 'Teacher'";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Drink> ReadTables(DataTable dataTable)
        {
            List<Drink> drinks = new List<Drink>();

            //each row from the database is converted into the drink class
            foreach (DataRow dr in dataTable.Rows)
            {
                Drink drink = new Drink()
                {
                    Name = (String)dr["Name"].ToString(),
                    Drink_ID = (int)dr["Drink_ID"],
                    Number_available = (int)(dr["Number_available"]),
                    Price = (int)dr["Price"],
                    Tax = (int)(dr["Tax"]),
                    Amount_sold = (int)dr["Amount_sold"]
                };
                drinks.Add(drink);
            }
            return drinks;
        }
    }
}
