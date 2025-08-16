using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using tavelapp.admin;

namespace tavelapp
{
    public partial class login_registration: Form
    {
        public static string e_mail, password;
        public login_registration()
        {
            InitializeComponent();
            
            //guna2ControlBox1.Visible = true;
        }

        private void login_registration_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
           
            //Comman
            SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHere Email = '" + txtemial.Text + "' AND Password = '" + txtpassword.Text + "'", Program.con);

            //Adopter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataTable
            DataTable dt = new DataTable();

            //Fill
            da.Fill(dt);
            //if
            if (dt.Rows.Count > 0)
            {
                e_mail = txtemial.Text;
                password = txtpassword.Text;
                    Home home = new Home();
                    this.Hide();
                    home.ShowDialog();
            }
            else
            {
                MessageBox.Show("Email or Password incorrect");
            }

            

        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void guna2ControlBox1_Click_1(object sender, EventArgs e)
        {

        }
        bool expand = false;
        private void transition_Tick(object sender, EventArgs e)
        {
            if (expand == false)
            {
                panel1.Width += 50;
                if (panel1.Width >= 799)
                {
                    panel1.Location = new Point(500, 0);
                    panel1.Width -= 30;
                   
                    if (panel1.Width <= 252) {
                        transition.Stop();
                       
                    }
                    
                }
                
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            transition.Start();
            linkLabel2.Visible = false;
            CheckBox.Visible = false;
            labelLogin.Visible = false;
            labelPass.Visible = false;
            labelmail.Visible = false;
            Btnlogin.Visible = false;
            txtemial.Visible = false;
            txtpassword.Visible = false;
            label3.Visible = false;
            linkLabelSignup.Visible = false;
            labelRegister.Visible = true;
            labelName.Visible = true;
            labelCpass.Visible = true;
            labelEmailregister.Visible = true;
            labelRpass.Visible = true;
            txtRemail.Visible = true;
            txtName.Visible = true;
            txtRpass.Visible = true;
            txtcPass.Visible = true;
            labelhaveaccount.Visible = true;
            linkLabel1.Visible = true;
            btnsignup.Visible = true;
            CheckBox1.Visible = true;
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        bool expand1 = false; // means panel is expanded and needs to slide back

        private void reverse_Tick(object sender, EventArgs e)
        {
            // Move the panel left by 20 pixels and reduce width
            if (expand1==false)
            {
                panel1.Left += 20; // Moves panel to the left (X position)
                panel1.Width -= 20; // Shrinks width as it slides

                if (panel1.Width <= 250)
                {
                    panel1.Width = 250; // Snap to final width
                    panel1.Location = new Point(0, 0);
                    expand1 = false;
                    reverse.Stop();
                }
            }
        }


        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {

            login_registration log = new login_registration();
            log.ShowDialog();
            this.Close();
            //reverse.Start();
            //panel1.Location = new Point(0, 0);
            //CheckBox.Visible = true;
            //labelLogin.Visible = true;
            //labelPass.Visible = true;
            //labelmail.Visible = true;
            //Btnlogin.Visible = true;
            //txtemial.Visible = true;
            //txtpassword.Visible = true;
            //label3.Visible = true;
            //linkLabelSignup.Visible = true;
            //labelRegister.Visible = false;
            //labelName.Visible = false;
            //labelCpass.Visible = false;
            //labelEmailregister.Visible = false;
            //labelRpass.Visible = false;
            //txtRemail.Visible = false;
            //txtName.Visible = false;
            //txtRpass.Visible = false;
            //txtcPass.Visible = false;
            //labelhaveaccount.Visible = false;
            //linkLabel1.Visible = false;
            //btnsignup.Visible = false;

        }

        private void btnsignup_Click(object sender, EventArgs e)
        {
            try
            {
                //Required Field
                if (txtName.Text == "" || txtRemail.Text == "")
                {
                    MessageBox.Show("Please Fill all required Fields Properly..", "Incomplete Form");
                    return;
                }


                //Password Matching
                if (txtRpass.Text != txtcPass.Text)
                {
                    MessageBox.Show("Password do not match. Please Try Again", "Incomplete Form");
                    return;
                }


                //Email Validation
                if (!Regex.IsMatch(txtRemail.Text, "^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\\.[a-zA-Z0-9-.]+$"))
                {
                    MessageBox.Show("Email is not in correct format", "Incomplete Form");
                    return;
                }

                //Password Strenth
                if (!Regex.IsMatch(txtRpass.Text, "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$"))
                {
                    MessageBox.Show("Password must contain uppercase, lowercase, digit, special character, and be at least 8 characters long.", "Weak Password");
                    return;
                }
                SqlCommand cmd = new SqlCommand($"INSERT INTO Users VALUES ('{txtName.Text}','{txtRemail.Text}','{txtRpass.Text}','Image')", Program.con);

                Program.con.Open();
                cmd.ExecuteNonQuery();
                Program.con.Close();




                //Confirmation
                MessageBox.Show("Account Registered", "Success");
                login_registration login = new login_registration();
                login.ShowDialog();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"E mail already exist " , "Error");
            }


        }

        private void txtRpass_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtRpass.Text, "^(?=.[A-Za-z])(?=.\\d)(?=.[@$!%?&])[A-Za-z\\d@$!%*?&]{8,}$"))
            {
                //lblpassword.Text = "Weak Password";
                //lblpassword.ForeColor = System.Drawing.Color.Red;
                txtRpass.BackColor = Color.Red;
            }
            else
            {
                //lblpassword.Text = "Strong Password";
                //lblpassword.ForeColor = System.Drawing.Color.Green;


            }

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txtemial.Text=="Bilal@admin"&& txtpassword.Text=="Admin") {
                Company cp = new Company();
                this.Hide();
                cp.Show();
            }
            else
            {
                MessageBox.Show("You are not Amin","Message");

            }
            
        }

        private void labelRegister_Click(object sender, EventArgs e)
        {

        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtcPass.UseSystemPasswordChar = !CheckBox1.Checked;
            txtRpass.UseSystemPasswordChar = !CheckBox1.Checked;
        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
           
                txtpassword.UseSystemPasswordChar = !CheckBox.Checked; 
        }
    }
}
