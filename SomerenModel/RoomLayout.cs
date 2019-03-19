using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class RoomLayout
    {
        public int Room_Id { get; set; }    // Number of room, e.g. 215
        public List<Student> Students { get; set; } // List of all students
        public int Count { get; set; }  // Number of participants in the room
        public int Capacity { get; set; }   // Number of spots available in the room
    }
}
