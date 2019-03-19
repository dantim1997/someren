using SomerenModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace SomerenDAL
{
    public class RoomLayout_DAO : Base
    {
        public List<RoomLayout> Db_Get_All_RoomLayouts()
        {
            string query = "SELECT D.Participant_ID, D.Room_ID, D.First_name, D.Last_name, K.Capacity FROM Participant AS D JOIN Room AS K ON K.Room_ID = D.Room_ID";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<RoomLayout> ReadTables(DataTable dataTable)
        {
            List<RoomLayout> rooms = new List<RoomLayout>();

            //each row from the database is converted into the student class
            foreach (DataRow dr in dataTable.Rows)
            {
                if (rooms.Any(p => p.Room_Id == (int)dr["Room_ID"]))
                {
                    Student student = new Student()
                    {
                        Name = (String)(dr["First_name"].ToString()),
                        LastName = (String)(dr["Last_name"].ToString())
                    };
                    rooms.Where(p => p.Room_Id == (int)dr["Room_ID"]).SingleOrDefault().Students.Add(student);
                    rooms.Where(p => p.Room_Id == (int)dr["Room_ID"]).SingleOrDefault().Count++;
                }
                else
                {
                    RoomLayout room = new RoomLayout()
                    {
                        Room_Id = (int)dr["Room_ID"],
                        Capacity = (int)(dr["Capacity"]),
                        Students = new List<Student>(),
                        Count = 1
                    };
                    Student student = new Student()
                    {
                        Number = (int)(dr["Participant_ID"]),
                        Name = (String)(dr["First_name"].ToString()),
                        LastName = (String)(dr["Last_name"].ToString())
                    };
                    room.Students.Add(student);
                    rooms.Add(room);
                }
            }
            return rooms;
        }
    }
}
