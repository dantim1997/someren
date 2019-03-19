using SomerenLogic;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SomerenUI
{
    public partial class SomerenUI : Form
    {
        public SomerenUI()
        {
            InitializeComponent();
        }

        private void SomerenUI_Load(object sender, EventArgs e)
        {
            showPanel("Dashboard");
        }

        private void showPanel(string panelName)
        {

            if (panelName == "Dashboard")
            {

                // hide all other panels
                pnl_Students.Hide();
                pnl_Rooms.Hide();
                pnl_Lecturers.Hide();
                pnl_RoomLayout.Hide();
                pnl_Sales_report.Hide();

                // show dashboard
                pnl_Dashboard.Show();
                img_Dashboard.Show();
            }
            else if (panelName == "Students")
            {
                // hide all other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                pnl_Lecturers.Hide();
                pnl_Rooms.Hide();
                pnl_RoomLayout.Hide();
                pnl_Sales_report.Hide();

                // show students
                pnl_Students.Show();



                // fill the students listview within the students panel with a list of students
                SomerenLogic.Student_Service studService = new SomerenLogic.Student_Service();
                List<Student> studentList = studService.GetStudents();

                // clear the listview before filling it again
                listViewStudents.Items.Clear();

                foreach (SomerenModel.Student s in studentList)
                {
                    ListViewItem li = new ListViewItem(s.Number.ToString());
                    li.SubItems.Add(s.Name);
                    li.SubItems.Add(s.LastName);
                    listViewStudents.Items.Add(li);
                }
            }
            else if (panelName == "Rooms")
            {
                // hide all other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                pnl_Students.Hide();
                pnl_Lecturers.Hide();
                pnl_RoomLayout.Hide();
                pnl_Sales_report.Hide();

                // show Rooms
                pnl_Rooms.Show();



                // fill the students listview within the students panel with a list of students
                SomerenLogic.Room_Service roomService = new SomerenLogic.Room_Service();
                List<Room> roomList = roomService.GetRooms();

                // clear the listview before filling it again
                listViewRooms.Items.Clear();

                foreach (SomerenModel.Room r in roomList)
                {
                    string typeOfRoom = "";
                    switch (r.Type)
                    {
                        case true: typeOfRoom = "Teacher"; break;
                        case false: typeOfRoom = "Student"; break;
                    }
                    ListViewItem li = new ListViewItem(r.Number.ToString());
                    li.SubItems.Add(r.Capacity.ToString());
                    li.SubItems.Add(typeOfRoom);
                    listViewRooms.Items.Add(li);
                }
            }
            else if (panelName == "Lecturers")
            {
                // hide all other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                pnl_Students.Hide();
                pnl_Rooms.Hide();
                pnl_RoomLayout.Hide();
                pnl_Sales_report.Hide();

                // show lecturers
                pnl_Lecturers.Show();


                // fill the students listview within the students panel with a list of students
                SomerenLogic.Lecturers_Service lecturerService = new SomerenLogic.Lecturers_Service();
                List<Teacher> teacherList = lecturerService.GetLecturers();

                // clear the listview before filling it again
                listViewLecturers.Items.Clear();

                foreach (SomerenModel.Teacher t in teacherList)
                {
                    ListViewItem li = new ListViewItem(t.Number.ToString());
                    li.SubItems.Add(t.Name);
                    li.SubItems.Add(t.LastName);
                    li.SubItems.Add(t.Attendant.ToString());
                    listViewLecturers.Items.Add(li);
                }
            }
            else if (panelName == "RoomLayout")
            {
                // hide all other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                pnl_Students.Hide();
                pnl_Rooms.Hide();
                pnl_Lecturers.Hide();
                pnl_Sales_report.Hide();

                // show lecturers
                pnl_RoomLayout.Show();

                // fill the students listview within the students panel with a list of students
                SomerenLogic.RoomLayout_Service roomLayout_Service = new SomerenLogic.RoomLayout_Service();
                List<RoomLayout> roomLayout = roomLayout_Service.GetRooms();

                // clear the listview before filling it again
                gv_Roomlayout.Rows.Clear();

                int PreviousRoomId = 0;
                foreach (SomerenModel.RoomLayout r in roomLayout)
                {
                    foreach (Student s in r.Students)
                    {
                        DataGridViewTextBoxCell room_Id = new DataGridViewTextBoxCell();
                        DataGridViewTextBoxCell capacity = new DataGridViewTextBoxCell();
                        DataGridViewTextBoxCell name = new DataGridViewTextBoxCell();
                        // if last id is the same as the room id
                        if (PreviousRoomId != r.Room_Id)
                        {
                            room_Id.Value = r.Room_Id;
                        }
                        else
                        {
                            room_Id.Value = "";
                        }
                        capacity.Value = r.Capacity;
                        name.Value = s.Name;
                        DataGridViewRow row = new DataGridViewRow();
                        row.Cells.Add(room_Id);
                        row.Cells.Add(capacity);
                        row.Cells.Add(name);

                        // if the capacity is the max amount of the room
                        if (r.Capacity == r.Count)
                        {
                            row.DefaultCellStyle.BackColor = Color.Red;
                        }
                        else
                        {
                            row.DefaultCellStyle.BackColor = Color.Green;
                        }
                        PreviousRoomId = r.Room_Id;
                        gv_Roomlayout.Rows.Add(row);
                    }
                }
            }
            else if (panelName == "Sales_report")
            {
                // hide all other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                pnl_Students.Hide();
                pnl_Rooms.Hide();
                pnl_RoomLayout.Hide();
                pnl_Lecturers.Hide();

                // show lecturers
                pnl_Sales_report.Show();

                // fill the students listview within the students panel with a list of students
                SomerenLogic.Sales_report_Service Sales_repor_Service = new SomerenLogic.Sales_report_Service();
                List<Sales_report> soldReportList = Sales_repor_Service.GetDrinks();

                // clear the listview before filling it again
                listViewSoldReport.Items.Clear();

                foreach (SomerenModel.Sales_report t in soldReportList)
                {
                    ListViewItem li = new ListViewItem(t.Name.ToString());
                    li.SubItems.Add(t.Amount_sold.ToString());
                    li.SubItems.Add(t.Market.ToString());
                    li.SubItems.Add(t.Amount_customers.ToString());
                    listViewSoldReport.Items.Add(li);
                }
            }

        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dashboardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            showPanel("Dashboard");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void img_Dashboard_Click(object sender, EventArgs e)
        {
            MessageBox.Show("What happens in Someren, stays in Someren!");
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Students");
        }

        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Rooms");
        }

        private void lecturersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Lecturers");
        }

        private void roomLayoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("RoomLayout");
        }

        private void salesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Sales_report");
        }

        private void btn_GetRapport_Click(object sender, EventArgs e)
        {
            SomerenLogic.Sales_report_Service Sales_repor_Service = new SomerenLogic.Sales_report_Service();
            DateTime from = Convert.ToDateTime(mc_From.SelectionStart);
            lb_DateFrom.Text = from.ToShortDateString();
            DateTime to = Convert.ToDateTime(mc_To.SelectionStart);
            lb_DateTo.Text = to.ToShortDateString();
            if (to > from)
            {
                List<Sales_report> soldReportList = Sales_repor_Service.GetDrinksByDate(from, to);

                // clear the listview before filling it again
                listViewSoldReport.Items.Clear();

                foreach (SomerenModel.Sales_report t in soldReportList)
                {
                    ListViewItem li = new ListViewItem(t.Name.ToString());
                    li.SubItems.Add(t.Amount_sold.ToString());
                    li.SubItems.Add(t.Market.ToString());
                    li.SubItems.Add(t.Amount_customers.ToString());
                    listViewSoldReport.Items.Add(li);
                }
            }
            else
            {
                MessageBox.Show("The From date can't be higher than the To date.");
            }
        }
    }
}
