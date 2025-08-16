using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.Expando;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Guna.UI2.WinForms;
using Microsoft.Data.SqlClient;

namespace tavelapp
{
    public partial class RoomBooking : Form
    {
        
        public RoomBooking(int r)
        {
            InitializeComponent();
             loadData(r);
            flowLayoutPanel.Width = 50;
            btncar.Visible = true;
            btnHotel.Visible = true;
            btnprofile.Visible = true;
        }
        void loadData(int r)
        {
            SqlCommand cmd = new SqlCommand($"select * from Room where HotelID = '{r}'", Program.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                flowLayoutPanel1.Controls.Add(CreatePanel(dt.Rows[i][2].ToString(), dt.Rows[i][4].ToString(), dt.Rows[i][6].ToString(), dt.Rows[i][5].ToString(), dt.Rows[i][0].ToString()));

            }
        }
        private Panel CreatePanel(string no, string Price, string Img,string status ,string Rid)
        {
            Panel panel = new Panel()
            {
                BackColor = Color.FromArgb(212, 241, 244),
                BorderStyle = BorderStyle.FixedSingle,
                Height = 250,
                Width = 150,

            };



            PictureBox pictureBox = new PictureBox()
            {
                Image = Image.FromFile(Path.Combine(Directory.GetCurrentDirectory(), Img)),
                Height = 150,
                Width = 120,
                Top = 5,
                Left = 10,
                SizeMode = PictureBoxSizeMode.StretchImage

            };

            Label label = new Label()
            {
                Text ="Room NO:"+ no,
                Height = 15,
                Width = 120,
                Top = 160,
                Left = 5,

            };

            Label label2 = new Label()
            {
                Text = "Rent per Day:"+ Price,
                Width = 120,
                Height = 15,
                Top = 180,
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
                Top = 200,
                Left = 5,

            };
            button.BorderThickness=1;
            button.HoverState.FillColor = Color.White;                        
            button.HoverState.ForeColor = Color.Black;                         
            button.HoverState.BorderColor = Color.FromArgb(0, 151, 167);

            button.Click += (sender, id) =>
            {
                RoomDetail roomd = new RoomDetail(int.Parse(Rid));
                this.Hide();
                roomd.ShowDialog();
                this.Show();

               
            };






            panel.Controls.Add(pictureBox);
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
            HotelBooking hb = new HotelBooking();
            this.Hide();
            hb.ShowDialog();
            this.Show();
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
            CarBooking car = new CarBooking();
            this.Hide();
            car.ShowDialog();
            this.Show();
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

        private void btnBus_Click(object sender, EventArgs e)
        {
            BusTicketFilter bus = new BusTicketFilter();
            this.Hide();
            bus.ShowDialog();
            this.Show();
        }

        private void btnplane_Click(object sender, EventArgs e)
        {
            PlaneTicketFilter plane = new PlaneTicketFilter();
            this.Hide();
            plane.ShowDialog();
            this.Show();
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
