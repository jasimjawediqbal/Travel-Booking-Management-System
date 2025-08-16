using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.Expando;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Guna.UI2.WinForms;
using Microsoft.Data.SqlClient;
using tavelapp.admin;

namespace tavelapp
{
    public partial class PlaneTicket : Form
    {
        int UserID;
        public PlaneTicket(string From ,string to, string date)
        {
            InitializeComponent();
            loadData(From,to,date);
            getid();
            flowLayoutPanel.Width = 50;
            btncar.Visible = true;
            btnHotel.Visible = true;
            btnprofile.Visible = true;
        }
        void getid()
        {
            SqlCommand cmd = new SqlCommand($"select * from  Users where Email = '{login_registration.e_mail}' and Password = '{login_registration.password}' ", Program.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            UserID = int.Parse(dt.Rows[0][0].ToString());
        }
        void loadData(string form,string to, string date)
        {
            SqlCommand cmd = new SqlCommand($"select * from Plane ", Program.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                flowLayoutPanel1.Controls.Add(CreatePanel(dt.Rows[i][7].ToString(), dt.Rows[i][5].ToString(), dt.Rows[i][6].ToString(),  dt.Rows[i][0].ToString()));

            }
        }
        private Panel CreatePanel(string no, string Price ,string status,string Pid)
        {
            Panel panel = new Panel()
            {
                BackColor = Color.FromArgb(212, 241, 244),
                BorderStyle = BorderStyle.FixedSingle,
                Height = 170,
                Width = 150,

            };



            Label label = new Label()
            {
                Text =no,
                Font=new Font(Font.FontFamily, 40),
                //Height = 150,
                //Width = 100,
                AutoSize=true,
                Top = 30,
                Left = 25,

            };
            

            Label label2 = new Label()
            {
                Text = "Ticket Price:"+ Price,
                Width = 120,
                Height = 15,
                Top = 100,
                Left = 5,

            };

            Guna2Button button = new Guna2Button()
            {
                Text = "SEE DETAILS",
                FillColor = Color.FromArgb(0, 151, 167),
                AutoRoundedCorners = true,
                ForeColor= Color.White,
                BorderColor = Color.FromArgb(0, 151, 167),
                Width = 120,
                Height = 25,
                Top = 120,
                Left = 5,

            };
            button.BorderThickness=1;
            button.HoverState.FillColor = Color.White;                        
            button.HoverState.ForeColor = Color.Black;                         
            button.HoverState.BorderColor = Color.FromArgb(0, 151, 167);

            button.Click += (sender, id) =>
            {

                if (status != "Reserved")
                {
                    getid();
                    SqlCommand cmd = new SqlCommand($"INSERT INTO PlaneBooking (UserID, FlightID) VALUES ('{UserID}', '{Pid}')", Program.con);
                    Program.con.Open();
                    cmd.ExecuteNonQuery();
                    Program.con.Close();

                    SqlCommand cmd2 = new SqlCommand($"UPDATE Plane SET Status = 'Reserved' WHERE FlightID = '{Pid}'", Program.con);
                    Program.con.Open();
                    cmd2.ExecuteNonQuery();
                    Program.con.Close();

                    MessageBox.Show("Ticket Reserved");



                }
                else
                {
                    MessageBox.Show("Already reserved");
                    //button.Enabled = false;
                }



            };






            
            panel.Controls.Add(label);
            panel.Controls.Add(label2);
            panel.Controls.Add(button);

            return panel;

        }

        private void Home_Load(object sender, EventArgs e)
        {
            

        }
        bool sidebarExpand = false;
        private void transition_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand==true)
            {
                flowLayoutPanel.Width -= 5;
                if (flowLayoutPanel.Width <= 50)
                {
                    sidebarExpand = false;
                    transition.Stop();
                }
            }
            else
            {
                flowLayoutPanel.Width += 5;
                if (flowLayoutPanel.Width >= 140)
                {
                    sidebarExpand = true;
                    transition.Stop();
                }

            }

            }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            transition.Start();
            btncar.Visible = true;
            btnHotel.Visible = true;
            btnprofile.Visible = true;
        }

        private void flowLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnHotel_Click(object sender, EventArgs e)
        {

        }

        private void btnprofile_Click(object sender, EventArgs e)
        {
            profile p = new profile();
            this.Hide();
            p.ShowDialog();
            this.Show();
        }

        private void btncar_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            login_registration.e_mail = "";
            login_registration.password = "";
            login_registration login = new login_registration();
            login.ShowDialog();
            this.Close();
        }
        bool mexpand = false;
        private void TiketExpand_Tick(object sender, EventArgs e)
        {
            if (mexpand == true)
            {
                PlnTicket.Height -= 1;
                if (PlnTicket.Height <= 40)
                {
                    mexpand = false;
                    TiketExpand.Stop();
                }
            }
            else
            {
                PlnTicket.Height += 1;
                if (PlnTicket.Height >= 156)
                {
                    mexpand = true;
                    TiketExpand.Stop();
                }

            }
        }

        private void btnticket_Click(object sender, EventArgs e)
        {
            TiketExpand.Start();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Do you want to Close the Application", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }
