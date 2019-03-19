using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenModel;
using SomerenDAL;
using System.Windows.Forms;
using System.IO;

namespace SomerenLogic
{
    public class Register_Service
    {
        Register_DAO register_db = new Register_DAO();

        public List<Register> GetRegisters()
        {
            try
            {
                List<Register> registers = register_db.Db_Get_All_Registers();
                return registers;
            }
            catch (Exception e)
            {
                MessageBox.Show("Couldn't find 'registers' in the database or couldn't connect with the database. \r\n Try again later.");
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
                return new List<Register>();
            }

        }
    }
}
