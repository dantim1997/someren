using SomerenModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SomerenDAL
{
    public class Room_DAO : Base
    {
        public List<Room> Db_Get_All_Rooms()
        {
            //set the query for room
            string query = "SELECT Room_Id, Capacity, Type FROM Room";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Room> ReadTables(DataTable dataTable)
        {
            List<Room> rooms = new List<Room>();

            //each row from the database is converted into the room class
            foreach (DataRow dr in dataTable.Rows)
            {
                Room room = new Room()
                {
                    Number = (int)dr["Room_Id"],
                    Capacity = (int)(dr["Capacity"]),
                    Type = (bool)(dr["Type"])
                };
                rooms.Add(room);
            }
            return rooms;
        }
    }
}
