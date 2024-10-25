using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var dict = new Dictionary<string, Dictionary<string, string>>
        {
            // State 0 (Idle)
            { "S0", new Dictionary<string, string>
                {
                    { "Start", "S1" },
                    { "Stop", "S2" }  
                }
            },
            // State 1 (Moving)
            { "S1", new Dictionary<string, string>
                {
                    { "Stop", "S2" },    
                    { "Accelerate", "S1" }, 
                    { "Brake", "S2" },    
                    { "Left", "S3" },  
                    { "Right", "S4" } 
                }
            },
            // State 2 (Stopped)
            { "S2", new Dictionary<string, string>
                {
                    { "Start", "S1" }
                }
            },
            // State 3 (ing Left)
            { "S3", new Dictionary<string, string>
                {
                    { "Stop", "S2" },  
                    { "Right", "S4" } 
                }
            },
            // State 4 (ing Right)
            { "S4", new Dictionary<string, string>
                {
                    { "Stop", "S2" },    
                    { "Left", "S3" } 
                }
            },
            { "Se", new Dictionary<string, string>() }
        };

        string initialState = "S0";
        string finalState = "Se"; 
        string input = "Start Stop"; 
        string[] commands = input.Split(' '); 
        string state = initialState; 
        foreach (string command in commands)
        {
            if (dict.ContainsKey(state) && dict[state].ContainsKey(command))
            {
                state = dict[state][command];
            }
            else
            {
                state = finalState;
                break;
            }
        }
        if (state.Equals(finalState))
        {
            Console.WriteLine("ERROR: Invalid command sequence.");
        }
        else
        {
            Console.WriteLine("RESULT OKAY: Successfully processed commands.");
        }
    }
}
