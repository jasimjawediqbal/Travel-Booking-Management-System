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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Guna.UI2.WinForms;
using Microsoft.Data.SqlClient;
using tavelapp.admin;

namespace tavelapp
{
    public partial class profile : Form
    {
        public string ImageName = "No img";
        public  static int id;
        public profile()
        {
            InitializeComponent();
            loadData();
            Hotel();
            car();
            Bus();
            air();

        }
        void loadData()
        {
            SqlCommand cmd = new SqlCommand($"SELECT * from Users where Email ='{login_registration.e_mail}'and Password = '{login_registration.password}' ", Program.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ImgPreview.Image = Image.FromFile(Path.Combine(Directory.GetCurrentDirectory(), dt.Rows[0][4].ToString()));
            id =int.Parse( dt.Rows[0][0].ToString());
            txtemail.Text = dt.Rows[0][2].ToString();
            txtname.Text = dt.Rows[0][1].ToString();
            txtpassword.Text = dt.Rows[0][3].ToString();
        }
        

        private void Home_Load(object sender, EventArgs e)
        {
            

        }
        void car()
        {
            SqlCommand cmd = new SqlCommand($@"
    SELECT 
        C.CarName,
        C.RentPerDay,
        U.FullName AS UserName
    FROM 
        CarBooking CB
    JOIN 
        Users U ON CB.UserID = U.UserID
    JOIN 
        Cars C ON CB.CarID = C.CarID
    WHERE 
        U.UserID = '{id}'
", Program.con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                flowLayoutHotel.Controls.Add(Createcar(dt.Rows[i]["CarName"].ToString(), dt.Rows[i]["RentPerDay"].ToString()));

            }


        }
        private Panel Createcar(string CName, string Rent)
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
                Text = CName,
                Font = new Font(Font.FontFamily, 20),
                //Height = 150,
                //Width = 100,
                AutoSize = true,
                Top = 30,
                Left = 25,

            };


            Label label2 = new Label()
            {
                Text = "Rent per Day::" + Rent,
                Width = 120,
                Height = 15,
                Top = 100,
                Left = 5,

            };
            panel.Controls.Add(label);
            panel.Controls.Add(label2);
            return panel;
        }
        void Hotel()
        {
            SqlCommand cmd = new SqlCommand($@"
    SELECT 
        H.HotelName,
        R.RoomNumber,
        U.FullName AS UserName
    FROM 
        HotelBooking HB
    JOIN 
        Users U ON HB.UserID = U.UserID
    JOIN 
        Room R ON HB.RoomID = R.RoomID
    JOIN 
        Hotel H ON R.HotelID = H.HotelID
    WHERE 
        U.UserID = '{id}'
", Program.con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                flowLayoutHotel.Controls.Add(CreateHotel(dt.Rows[i]["HotelName"].ToString(), dt.Rows[i]["RoomNumber"].ToString()));

            }

        }

        private Panel CreateHotel(string hotel, string Room)
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
                Text = hotel,
                Font = new Font(Font.FontFamily, 20),
                //Height = 150,
                //Width = 100,
                AutoSize = true,
                Top = 30,
                Left = 25,

            };


            Label label2 = new Label()
            {
                Text = "Room NO::" + Room,
                Width = 120,
                Height = 15,
                Top = 100,
                Left = 5,

            };         
            panel.Controls.Add(label);
            panel.Controls.Add(label2);            
            return panel;
        }
        void Bus()
        {
            SqlCommand cmd = new SqlCommand($@"
    SELECT 
        B.SeatNO,
        B.DepartureDate,
        B.FromLocation,
        B.ToLocation,
        U.FullName AS UserName
    FROM 
        BusBooking BB
    JOIN 
        Users U ON BB.UserID = U.UserID
    JOIN 
        Bus B ON BB.BusID = B.BusID
    WHERE 
        U.UserID = '{id}'
", Program.con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                flowLayoutHotel.Controls.Add(CreateBus(dt.Rows[i]["SeatNumber"].ToString(), dt.Rows[i]["BookingDate"].ToString(), dt.Rows[i]["FromLocation"].ToString(), dt.Rows[i]["ToLocation"].ToString()));

            }


        }
        private Panel CreateBus(string seat, string date,string from ,string to)
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
                Text = seat,
                Font = new Font(Font.FontFamily, 20),
                //Height = 150,
                //Width = 100,
                AutoSize = true,
                Top = 30,
                Left = 25,

            };


            Label label2 = new Label()
            {
                Text = "Room NO::" + date,
                Width = 120,
                Height = 15,
                Top = 100,
                Left = 5,

            };
            Label label3 = new Label()
            {
                Text = "From" + from + "To" + to,
                Width = 120,
                Height = 15,
                Top = 115,
                Left = 5,

            };
            panel.Controls.Add(label);
            panel.Controls.Add(label2);
            panel.Controls.Add(label3);
            return panel;
        }

        void air()
        {
            SqlCommand cmd = new SqlCommand($@"
    SELECT 
        P.SeatNO,
        P.DepartureDate,
        P.FromLocation,
        P.ToLocation,
        U.FullName AS UserName
    FROM 
        PlaneBooking PB
    JOIN 
        Users U ON PB.UserID = U.UserID
    JOIN 
        Plane P ON PB.FlightID = P.FlightID
    WHERE 
        U.UserID = '{id}'
", Program.con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                flowLayoutHotel.Controls.Add(Createair(dt.Rows[i]["SeatNumber"].ToString(), dt.Rows[i]["BookingDate"].ToString(), dt.Rows[i]["FromLocation"].ToString(), dt.Rows[i]["ToLocation"].ToString()));

            }

        }

        private Panel Createair(string seat, string date, string from, string to)
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
                Text = seat,
                Font = new Font(Font.FontFamily, 20),
                //Height = 150,
                //Width = 100,
                AutoSize = true,
                Top = 30,
                Left = 25,

            };


            Label label2 = new Label()
            {
                Text = "Room NO::" + date,
                Width = 120,
                Height = 15,
                Top = 100,
                Left = 5,

            };
            Label label3 = new Label()
            {
                Text = "From" + from +"To" + to,
                Width = 120,
                Height = 15,
                Top = 115,
                Left = 5,

            };
            panel.Controls.Add(label);
            panel.Controls.Add(label2);
            panel.Controls.Add(label3);
            return panel;
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

        private void picedit_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.tiff;*.webp";


            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ImgPreview.Image = Image.FromFile(ofd.FileName);
                ImageName = Path.GetFileName(ofd.FileName);
                string SavePath = Path.Combine(Directory.GetCurrentDirectory(), ImageName);
                File.Copy(ofd.FileName, SavePath, true);
                SqlCommand cmd = new SqlCommand($"UPDATE Users SET picture = '{ImageName}' where Email = '{login_registration.e_mail}' ", Program.con);
                Program.con.Open();
                cmd.ExecuteNonQuery();
                Program.con.Close();
            };
                        
        }

        private void Btnupdate_Click(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtpassword.Text, "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$"))
            {
                MessageBox.Show("Password must contain uppercase, lowercase, digit, special character, and be at least 8 characters long.", "Weak Password");
                return;
            }
            SqlCommand cmd = new SqlCommand($"UPDATE Users SET Password = '{txtpassword.Text}' where UserID = '{id}' ", Program.con);
            Program.con.Open();
            cmd.ExecuteNonQuery();
            Program.con.Close();

        }
    }
    }
