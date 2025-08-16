using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Microsoft.Data.SqlClient;

namespace tavelapp.admin
{
    public partial class Company: Form
    {
        public Company()
        {
            InitializeComponent();
            loadData();
        }
        void loadData()
        {
            SqlCommand cmd = new SqlCommand("select * from Companies", Program.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Datagridview.DataSource = dt;

        }
      


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            flowLayoutPanel2.Width = 150;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            Menu.Start();
        }

        private void Car_Load(object sender, EventArgs e)
        {

        }

        private void btnBus_Click(object sender, EventArgs e)
        {
            Bus bus = new Bus();
            this.Hide();
            bus.ShowDialog();
            this.Close();
        }
        bool sidebarExpand = false;
        private void Menu_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand == true)
            {
                
                flowLayoutPanel2.Width -= 3;
                if (flowLayoutPanel2.Width <= 0)
                {
                    panel1.Location = new Point(33, 49);
                    sidebarExpand = false;
                    Menu.Stop();
                }
            }
            else
            {
                panel1.Location = new Point(130, 49);
                flowLayoutPanel2.Width += 3;
                if (flowLayoutPanel2.Width >= 129)
                {
                    sidebarExpand = true;
                    Menu.Stop();
                }

            }
        }
        bool mexpand = false;
        private void Tikettran_Tick(object sender, EventArgs e)
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
            
        }

        private void btnticket_Click_1(object sender, EventArgs e)
        {
            TiketExpand.Start();

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtid.Text != "")
            {
                BtnAdd.Enabled = false;

            }
            if (txtid.Text == "")
            {
                BtnAdd.Enabled = true;
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {

                SqlCommand cmd = new SqlCommand($"INSERT INTO  Companies values ('{txtName.Text}','{DDLType.SelectedItem.ToString()}','{txtDescription.Text}')", Program.con);
                Program.con.Open();
                cmd.ExecuteNonQuery();
                Program.con.Close();
                MessageBox.Show("added", "Message");
                loadData();
                txtName.Text = "";
                txtDescription.Text = "";
                DDLType.SelectedItem = -1;
        }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong", "Error");
            }
}

        private void btndel_Click(object sender, EventArgs e)
        {

            if (txtid.Text != "")
            {
            SqlCommand cmd = new SqlCommand($"Delete from Companies where CompanyID=' {txtid.Text}'", Program.con);
            Program.con.Open();
            cmd.ExecuteNonQuery();
            Program.con.Close();
            MessageBox.Show("DELETED", "Message");
            loadData();
            }
            else
            {
                MessageBox.Show("Please enter the ID ", "Message");
            }
        }

       

        private void Datagridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCar_Click(object sender, EventArgs e)
        {
            Car c = new Car();
            this.Hide();
            c.Show();
            this.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnHotel_Click(object sender, EventArgs e)
        {
            Hotel hotel = new Hotel();
            this.Hide();
            hotel.ShowDialog();
            this.Close();
        }

        private void btnCompany_Click(object sender, EventArgs e)
        {
            Company comp = new Company();
            this.Hide();
            comp.ShowDialog();
            this.Close();
        }

        private void btnplane_Click(object sender, EventArgs e)
        {
            Plane plane = new Plane();
            this.Hide();
            plane.ShowDialog();
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand($"select * from Companies where CompanyID='{txtid.Text}'", Program.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count < 1)
            {
                MessageBox.Show("REcord not found", "Error");
                return;
            }
            txtName.Text = dt.Rows[0][1].ToString();
            DDLType.SelectedItem = dt.Rows[0][1].ToString();
            txtDescription.Text = dt.Rows[0][3].ToString();
            btnEdit.Visible = false;
            btnupdate.Visible = true;
        }

        private void guna2Button1_Click_2(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand( $"UPDATE Companies SET CompanyName = '{txtName.Text}', CompanyType = '{DDLType.SelectedItem.ToString()}', Description = '{txtDescription.Text}' WHERE CompanyID = '{txtid.Text}'",Program.con);
            Program.con.Open();
            cmd.ExecuteNonQuery();
            Program.con.Close();
            MessageBox.Show("Updated", "Message");
            loadData();

        }

        private void btnRoom_Click(object sender, EventArgs e)
        {
            Room r = new Room();
            this.Hide();
            r.ShowDialog();
            this.Close();
        }

        private void guna2Button1_Click_3(object sender, EventArgs e)
        {
            UserRecord u = new UserRecord();
            this.Hide();
            u.ShowDialog();
            this.Close();
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            login_registration r = new login_registration();
            this.Hide();
            r.ShowDialog();
            this.Close();
        }
    }
}
