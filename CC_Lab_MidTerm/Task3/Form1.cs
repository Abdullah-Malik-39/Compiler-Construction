using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task3
{
    public partial class Form1 : Form
    {
        private Dictionary<string, Dictionary<string, string>> stateMachine;
        private string initialState = "S0";
        private string finalState = "Se";

        public Form1()
        {
            InitializeComponent();
            InitializeStateMachine();
        }

        private void InitializeStateMachine()
        {
            // Initialize the state machine dictionary
            stateMachine = new Dictionary<string, Dictionary<string, string>>
            {
                { "S0", new Dictionary<string, string> { { "Start", "S1" }, { "Stop", "S2" } } },
                { "S1", new Dictionary<string, string> { { "Stop", "S2" }, { "Accelerate", "S1" }, { "Brake", "S2" }, { "Left", "S3" }, { "Right", "S4" } } },
                { "S2", new Dictionary<string, string> { { "Start", "S1" } } },
                { "S3", new Dictionary<string, string> { { "Stop", "S2" }, { "Right", "S4" } } },
                { "S4", new Dictionary<string, string> { { "Stop", "S2" }, { "Left", "S3" } } },
                { "Se", new Dictionary<string, string>() }
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = txtCommands.Text; // Get commands from the text box
            string[] commands = input.Split(' '); // Split commands by space
            string state = initialState; // Start with initial state

            foreach (string command in commands)
            {
                if (stateMachine.ContainsKey(state) && stateMachine[state].ContainsKey(command))
                {
                    state = stateMachine[state][command]; // Move to the next state
                }
                else
                {
                    state = finalState; // Invalid command sequence, go to error state
                    break;
                }
            }

            // Display the result based on the final state
            if (state.Equals(finalState))
            {
                lblResult.Text = "ERROR: Invalid command sequence.";
            }
            else
            {
                lblResult.Text = "RESULT OKAY: Successfully processed commands.";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


    }
}
