using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Task1
{
    public partial class Form1 : Form
    {
        private Dictionary<string, Dictionary<string, string>> dfa;
        private string initialState = "S0";
        private string finalState = "S1";
        private HashSet<string> reservedWords = new HashSet<string>
        {
            "auto", "break", "case", "char", "const", "continue", "default", "do", "double",
            "else", "enum", "extern", "float", "for", "goto", "if", "int", "long", "register",
            "return", "short", "signed", "sizeof", "static", "struct", "switch", "typedef",
            "union", "unsigned", "void", "volatile", "while", "_Packed", "_Alignas", "_Alignof",
            "_Atomic", "_Bool", "_Complex", "_Generic", "_Imaginary", "_Noreturn", "_Static_assert",
            "_Thread_local", "inline", "restrict"
        };

        public Form1()
        {
            InitializeComponent();
            InitializeDFA();
        }

        private void InitializeDFA()
        {
            dfa = new Dictionary<string, Dictionary<string, string>>
            {
                { "S0", new Dictionary<string, string> { { "letter", "S1" }, { "_", "S1" } } },
                { "S1", new Dictionary<string, string> { { "letter", "S1" }, { "digit", "S1" }, { "_", "S1" } } }
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = txtVariableName.Text;
            if (reservedWords.Contains(input))
            {
                lblResult.Text = "Invalid: Reserved keyword in C.";
                return;
            }

            string state = initialState; 
            foreach (char c in input)
            {
                string charType = GetCharType(c);
                if (dfa.ContainsKey(state) && dfa[state].ContainsKey(charType))
                {
                    state = dfa[state][charType]; 
                }
                else
                {
                    state = "Invalid";  
                    break;
                }
            }

            if (state == finalState)
            {
                lblResult.Text = "Valid C variable name.";
            }
            else
            {
                lblResult.Text = "Invalid C variable name.";
            }
        }

        private string GetCharType(char c)
        {
            if (char.IsLetter(c)) return "letter";
            if (char.IsDigit(c)) return "digit";
            if (c == '_') return "_";
            return "invalid";
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }
    }
}
