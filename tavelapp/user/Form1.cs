using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace tavelapp
{
    public partial class Form1: Form
    {
        private List<string> taglines = new List<string>()
        {
            "Explore the world with us!",
            "Your journey begins here.",
            "Travel smart. Travel far.",
            "Adventure is calling!",
            "Wander. Discover. Repeat.",
            "Making memories one trip at a time.",
            "Escape the ordinary.",
            "Fly. Roam. Discover."
        };

        private int taglineIndex = 0;
        public Form1()
        {
            InitializeComponent();
            timer.Start();

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (progressbar.Value < 100)
            {
                progressbar.Value += 1;
                if (progressbar.Value % 20 == 0 && taglineIndex < taglines.Count)
                {
                    guna2Transition1.HideSync(label);
                    label.Text = taglines[taglineIndex];
                    taglineIndex++;
                    guna2Transition1.ShowSync(label);
                }
            }
            else
            {
               
                timer.Stop();
                
                login_registration obj = new login_registration(); // Replace 'Form2' with your actual form name
                obj.Show();
                this.Hide();

            }

        }

        private void progressbar_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
