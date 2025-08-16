using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using tavelapp.admin;
using Microsoft.Data.SqlClient;

namespace tavelapp
{
    static class Program
    {
        public static SqlConnection con = new SqlConnection("Data Source=DESKTOP-OG7DERJ\\SQLEXPRESS;Initial Catalog=Booking;Integrated Security=True;Trust Server Certificate=True");
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
