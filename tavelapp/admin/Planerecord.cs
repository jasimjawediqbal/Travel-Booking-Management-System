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

namespace tavelapp.admin
{
    public partial class Planerecord : Form
    {
        public Planerecord()
        {
            InitializeComponent();
            loadData();
        }
        void loadData()
        {
            SqlCommand cmd = new SqlCommand("select * from PlaneBooking", Program.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataGridView.DataSource = dt;
            DataGridView.DataSource = dt;
            DataGridView.AutoGenerateColumns = true;

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            UserRecord r = new UserRecord();
            r.ShowDialog();
            this.Close();
        }
    }
}
