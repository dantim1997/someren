using System;
using SomerenModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SomerenDAL
{
    public class Sale_report_DAO: Base
    {
        public List<Sales_report> Db_Get_All_Sales()
        {
            string query = "SELECT D.Name, SUM(R.Amount) as Amount, D.Price, COUNT(*) as Customers "
                +"FROM Register AS R "
                +"JOIN Drink AS D ON R.Drink_ID = D.Drink_ID "
                +"JOIN Participant as P on R.Student_Id = P.Participant_ID "
                +"group by D.name, D.Price";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        public List<Sales_report> Db_Get_By_Date_Range(DateTime startDate, DateTime endDate)
        {
            string query = "SELECT D.Name, SUM(R.Amount) as Amount, D.Price, COUNT(*) as Customers "
                + "FROM Register AS R "
                + "JOIN Drink AS D ON R.Drink_ID = D.Drink_ID "
                + "JOIN Participant as P on R.Student_Id = P.Participant_ID "
                + "where Date_created  between convert(datetime, '"+startDate.Year+"/"+startDate.Month+"/"+startDate.Day+ "') and convert(datetime, '" + endDate.Year + "/" + endDate.Month + "/" + endDate.Day + "')"
                + "group by D.name, D.Price";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Sales_report> ReadTables(DataTable dataTable)
        {
            List<Sales_report> registers = new List<Sales_report>();

            //each row from the database is converted into the register class
            foreach (DataRow dr in dataTable.Rows)
            {
                string name = (String)dr["Name"];
                double amount = (int)dr["Amount"];
                double price = (double)dr["Price"];
                int countCustumers = (int)dr["Customers"];

                Sales_report register = new Sales_report()
                {
                    Name = name,
                    Amount_sold = Convert.ToInt32( amount),
                    Amount_customers = countCustumers,
                    Market = price* amount
                };

                registers.Add(register);
            }
            return registers;
        }
    }
}
