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
    public class RoomLayout_Service
    {
        RoomLayout_DAO room_db = new RoomLayout_DAO();

        public List<RoomLayout> GetRooms()
        {
            try
            {
                List<RoomLayout> room = room_db.Db_Get_All_RoomLayouts();

                return room;
            }
            catch (Exception e)
            {
                MessageBox.Show("Couldn't find 'room layouts' in the database or couldn't connect with the database. \r\n Try again later.");
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
                return new List<RoomLayout>();
            }

        }
    }
}
