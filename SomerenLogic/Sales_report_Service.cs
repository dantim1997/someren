using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SomerenLogic
{
    public class Sales_report_Service
    {
        Sale_report_DAO sales_db = new Sale_report_DAO();

        public List<Sales_report> GetDrinks()
        {
            try
            {
                List<Sales_report> sales = sales_db.Db_Get_All_Sales();
                return sales;
            }
            catch (Exception e)
            {
                MessageBox.Show("Couldn't find 'drinks' in the database or couldn't connect with the database. \r\n Try again later.");
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
                return new List<Sales_report>();
            }

        }
        public List<Sales_report> GetDrinksByDate(DateTime startDate, DateTime endTime)
        {
            try
            {
                List<Sales_report> sales = sales_db.Db_Get_By_Date_Range(startDate, endTime);
                return sales;
            }
            catch (Exception e)
            {
                MessageBox.Show("Couldn't find 'drinks' in the database or couldn't connect with the database. \r\n Try again later.");
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
                return new List<Sales_report>();
            }

        }
    }
}
