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
    public partial class UserRecord : Form
    {
        public UserRecord()
        {
            InitializeComponent();
            
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            HotelRecord r = new HotelRecord();
            r.ShowDialog();
            this.Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            BusRecord b = new BusRecord();
            b.ShowDialog();
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Planerecord p = new Planerecord();
            p.ShowDialog();
            this.Close();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            CarRecord c = new CarRecord();
            c.ShowDialog();
            this.Close();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Company c = new Company();
            c.ShowDialog();
            this.Close();
        }
    }
}
