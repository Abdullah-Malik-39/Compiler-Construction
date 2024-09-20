using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CC_Lab2
{
    public partial class Task1 : Form
    {
        public Task1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inputText = richTextBox1.Text;
            string pattern = @"^[-+]?\d{1,4}(\.\d{1,2})?$";
            bool isMatch = Regex.IsMatch(inputText, pattern);
            if (isMatch)
            {
                label2.Text = "Result: True";
            }
            else
            {
                label2.Text = "Result: False";
            }
            richTextBox1.Text = "";
        }
    }
}
