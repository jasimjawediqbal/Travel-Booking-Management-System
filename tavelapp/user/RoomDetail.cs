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
    public partial class RoomDetail : Form
    {
        public string status;
        int Rid;
        int UserID;

        public RoomDetail(int r)
        {
            Rid = r;
            InitializeComponent();
             loadData(r);
            getid();
           
        }
        void loadData(int r)
        {
            SqlCommand cmd = new SqlCommand($"SELECT R.*, H.HotelName FROM Room R JOIN Hotel H ON R.HotelID = H.HotelID WHERE R.HotelID = '{r}'", Program.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            lblno.Text= "Room NO: "+ dt.Rows[0][2].ToString();
            lblHName.Text = dt.Rows[0]["HotelName"].ToString();
            lbltype.Text ="Room type :"+ dt.Rows[0][3].ToString();
            lblprice.Text ="Rent per Day: "+ dt.Rows[0][4].ToString();
            llbdiscrption.Text = "Discription :" + dt.Rows[0][7].ToString();
            status = dt.Rows[0][5].ToString();
            
            pic.Image = Image.FromFile(Path.Combine(Directory.GetCurrentDirectory(), dt.Rows[0][6].ToString()));


        }

        void getid()
        {
            SqlCommand cmd = new SqlCommand($"select * from  Users where Email = '{login_registration.e_mail}' and Password = '{login_registration.password}' ", Program.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            UserID = int.Parse(dt.Rows[0][0].ToString());
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

        private void Btnreserve_Click_1(object sender, EventArgs e)
        {
            if (status != "Reserved")
            {
                getid();

                SqlCommand cmd2 = new SqlCommand($"INSERT INTO HotelBooking (UserID, RoomID) VALUES ('{UserID}', '{Rid}')", Program.con);
                Program.con.Open();
                cmd2.ExecuteNonQuery();
                Program.con.Close();

                SqlCommand cmd = new SqlCommand($"UPDATE Room SET Status = 'Reserved' where RoomID = '{Rid}'", Program.con);
                Program.con.Open();
                cmd.ExecuteNonQuery();
                Program.con.Close();
                MessageBox.Show("Room Reserved");


            }
            else
            {
                MessageBox.Show("Already reserved");
                //button.Enabled = false;
            }

        }
    }
    }
