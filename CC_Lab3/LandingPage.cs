using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CC_Lab2
{
    public partial class LandingPage : Form
    {
        public LandingPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task1 taskForm = new Task1();
            taskForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Task2 taskForm = new Task2();
            taskForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Task3 taskForm = new Task3();
            taskForm.Show();
        }
    }
}
