using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Microsoft.Data.SqlClient;

namespace tavelapp.admin
{
    public partial class Bus: Form
    {
        public string ImageName = "No Image";
        public Bus()
        {
            InitializeComponent();
            loadData();
            loadcompny();
            DDlcompany.SelectedIndex = -1;
        }
        void loadData()
        {
            SqlCommand cmd = new SqlCommand("select * from Bus", Program.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Datagridview.DataSource = dt;

        }
        void loadcompny()
        {
            SqlCommand cmd = new SqlCommand("select * from Companies", Program.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DDlcompany.DataSource = dt;
            DDlcompany.DisplayMember = dt.Columns[1].ToString();
            DDlcompany.ValueMember = dt.Columns[0].ToString();


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
            if (txtid.Text != "") {
                BtnAdd.Enabled = false;

            }
            if(txtid.Text == "")
            {
                BtnAdd.Enabled = true;
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {

                SqlCommand cmd = new SqlCommand($"INSERT INTO Bus VALUES ('{DDlcompany.SelectedValue.ToString()}','{DDLfrom.SelectedItem.ToString()}','{DDLTO.SelectedItem.ToString()}','{txtDate.Text}','{txtprice.Text}','{ddlstatus.SelectedItem.ToString()}','{txtsaetno.Text}')", Program.con);
                Program.con.Open();
                cmd.ExecuteNonQuery();
                Program.con.Close();
                MessageBox.Show("added", "Message");
                loadData();
                txtDate.Text = "";
                txtprice.Text = "";
                txtsaetno.Text = "";
                ddlstatus.SelectedIndex = -1;
                DDlcompany.SelectedIndex = -1;
                DDLfrom.SelectedIndex = -1;
                DDLTO.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Something went wrong: " +ex.Message, "Error");
            }
}

        private void btndel_Click(object sender, EventArgs e)
        {
            if (txtid.Text != "")
            {
               
                    SqlCommand cmd = new SqlCommand($"Delete from Bus where BusID =' {txtid.Text}'", Program.con);
                    Program.con.Open();
                    cmd.ExecuteNonQuery();
                    Program.con.Close();
                    MessageBox.Show("DELETED", "Message");
                    loadData();
                }
            else
            {
                MessageBox.Show("Please enter the ID ","Message");
            }

        }

        private void DDLType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DDlcompany_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            
            SqlCommand cmd = new SqlCommand($"select * from Bus where BusID='{txtid.Text}' ", Program.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count < 1)
            {
                MessageBox.Show("REcord not found", "Error");
                return;
            }
            txtDate.Text = dt.Rows[0][4].ToString();
            txtprice.Text = dt.Rows[0][5].ToString();
            txtsaetno.Text = dt.Rows[0][7].ToString();
            ddlstatus.SelectedItem = dt.Rows[0][6].ToString();
            DDLfrom.SelectedItem = dt.Rows[0][2].ToString();
            DDLTO.SelectedItem = dt.Rows[0][3].ToString();
            btnEdit.Visible = false;
            Btnupdate.Visible = true;

        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click_2(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand($"UPDATE Bus SET CompanyID = '{DDlcompany.SelectedValue.ToString()}', FromLocation = '{DDLfrom.SelectedItem.ToString()}', ToLocation = '{DDLTO.SelectedItem.ToString()}', DepartureDate = '{txtDate.Text}', Price = '{txtprice.Text}', SeatsAvailable = '{ddlstatus.SelectedItem.ToString()}', SeatNO = '{txtsaetno.Text}' WHERE BusID = '{txtid.Text}'", Program.con);
                Program.con.Open();
                cmd.ExecuteNonQuery();
                Program.con.Close();
                loadData();
                MessageBox.Show("updated", "Message");
                btnEdit.Visible = true;
                Btnupdate.Visible = false;
                txtDate.Text = "";
                txtprice.Text = "";
                txtsaetno.Text = "";
                ddlstatus.SelectedIndex = -1;
                DDlcompany.SelectedIndex = -1;
                DDLfrom.SelectedIndex = -1;
                DDLTO.SelectedIndex = -1;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Something went wrong: " + ex.Message, "Error");
            }

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        

        private void guna2TextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void btnplane_Click(object sender, EventArgs e)
        {
            Plane plane = new Plane();
            this.Hide();
            plane.ShowDialog();
            this.Close();
        }

        private void btnHotel_Click(object sender, EventArgs e)
        {
            Hotel hotel = new  Hotel();
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

        private void btnCar_Click(object sender, EventArgs e)
        {
            Car Car = new Car();
            this.Hide();
            Car.ShowDialog();
            this.Close();
        }

        private void txtid_Enter(object sender, EventArgs e)
        {
            
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
    }
}
