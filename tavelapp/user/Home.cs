using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.Expando;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tavelapp
{
    public partial class Home: Form
    {
        public Home()
        {
            InitializeComponent();
            flowLayoutPanel.Width = 50;
            btncar.Visible = true;
            btnHotel.Visible = true;
            btnprofile.Visible = true;
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
            HotelBooking hb = new  HotelBooking();
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
    }
    }
