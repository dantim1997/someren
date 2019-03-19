using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using SomerenModel;
using SomerenDAL;
using System.Configuration;
using System.Windows.Forms;
using System.IO;

namespace SomerenLogic
{
    public class Room_Service
    {
        Room_DAO room_db = new Room_DAO();

        public List<Room> GetRooms()
        {
            try
            {
                List<Room> room = room_db.Db_Get_All_Rooms();
                return room;
            }
            catch (Exception e)
            {
                MessageBox.Show("Couldn't find 'rooms' in the database or couldn't connect with the database. \r\n Try again later.");
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
                return new List<Room>();
            }

        }
    }
}
