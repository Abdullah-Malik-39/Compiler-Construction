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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string regNo = txtRegNo.Text;
            string firstName = txtFirstName.Text;
            string lastName = txtFavouriteMovie.Text;
            string favouriteMovie = txtFavouriteMovie.Text;

            string regNoDigits = ExtractDigits(regNo, 2);
            string firstLetter = ExtractLetter(firstName, 1);
            string lastLetter = ExtractLetter(lastName, 1);
            string movieChars = ExtractCharacters(favouriteMovie, 2);

            string specialChars = "!@$%^&*()-_=+<>?";
            string skeleton = regNoDigits + firstLetter + lastLetter + movieChars;

            string password = GeneratePassword(skeleton, specialChars);

            lblPassword.Text = password;
        }

        private string ExtractDigits(string input, int count)
        {
            Match match = Regex.Match(input, @"\d+");
            return match.Success && match.Value.Length >= count ? match.Value.Substring(0, count) : "00";
        }

        private string ExtractLetter(string input, int position)
        {
            return input.Length > position ? input[position].ToString() : "X";
        }

        private string ExtractCharacters(string input, int count)
        {
            return input.Length >= count ? input.Substring(0, count) : new string('X', count);
        }

        private string GeneratePassword(string skeleton, string specialChars)
        {
            Random rnd = new Random();
            string password = skeleton;

            for (int i = 0; i < 2; i++)
            {
                password += specialChars[rnd.Next(specialChars.Length)];
            }

            while (password.Length < 14)
            {
                char nextChar = (char)rnd.Next(33, 126);
                if (nextChar != '#' && !char.IsControl(nextChar))
                {
                    password += nextChar;
                }
            }
            return ShuffleString(password);
        }

        private string ShuffleString(string input)
        {
            char[] array = input.ToCharArray();
            Random rnd = new Random();
            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = rnd.Next(i + 1);
                (array[i], array[j]) = (array[j], array[i]);
            }
            return new string(array);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
