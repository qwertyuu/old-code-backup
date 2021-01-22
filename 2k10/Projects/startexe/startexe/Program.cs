using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace startexe
{
    class Program
    {
        static void Main(string[] args)
        {
        RESET:
            string[] closeApp = { "exit", "EXIT", "QUIT", "quit", "FERMER", "close", "kill", "KILL", "CLOSE", "  " };
            Console.WriteLine("C# Syntax Debugger 1.7 BUILD 33");
            Console.WriteLine("");
        BEGIN:
            Console.Write("C:/>");
            string userValue = Console.ReadLine();
            if (userValue == "qw3rtyui0p")
            {
                Process.Start("C:/Program Files/TrueCrypt/TrueCrypt.exe");
                Console.WriteLine("Bonjour Raph! Bienvenue.");
                Console.Clear();
                goto RESET;
            }
            else if (userValue == "")
            {
                Console.WriteLine("You wrote nothing. Please type HELP for help. (Error #443)");
                goto BEGIN;
            }

            else if (userValue == "HELP" || userValue == "help" || userValue == "Help")
            {
                Console.WriteLine("Type a debug syntax or EXIT to close the debugger.");
                goto BEGIN;
            }

            else if (userValue != closeApp[0] && userValue != closeApp[1] && userValue != closeApp[2] && userValue != closeApp[3] && userValue != closeApp[4] && userValue != closeApp[5] && userValue != closeApp[6] && userValue != closeApp[7] && userValue != closeApp[8] && userValue != closeApp[9])
            {
                Console.WriteLine("'{0}' is not a known syntax. Please type HELP for help. (Error #5)", userValue);
                goto BEGIN;
            }
        }
    }
}
