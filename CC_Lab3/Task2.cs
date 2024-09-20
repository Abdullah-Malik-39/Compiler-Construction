using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CC_Lab2
{
    public partial class Task2 : Form
    {
        public Task2()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("Input", "Input");
            dataGridView1.Columns.Add("Output", "Output");
            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                ValidateInputAndSetOutput(e.RowIndex);
            }
        }

        private void ValidateInputAndSetOutput(int rowIndex)
        {
            string inputText = dataGridView1.Rows[rowIndex].Cells[0].Value?.ToString();
            if (IsValidScientificNotation(inputText))
            {
                dataGridView1.Rows[rowIndex].Cells[1].Value = "Valid";
            }
            else
            {
                dataGridView1.Rows[rowIndex].Cells[1].Value = "Invalid";
            }
        }
        private bool IsValidScientificNotation(string input)
        {
            string pattern = @"^[+-]?\d+(\.\d+)?[eE][+-]?\d+$";
            return Regex.IsMatch(input, pattern);
        }
    }
}
