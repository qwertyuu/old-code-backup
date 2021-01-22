using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] closeCommands = { "exit", "quit", "stop", "close", "kill", "  " };
        string[] helpCommands = { "help", "?", "halp" };
        string[] workCommands = { "qw3rtyui0p" };
        string[] clearCommands = { "clear" };
        string[] pingCommands = { "ping", "ping!" };
        string[] pnigCommands = { "pnig", "pnig!" };

        bool hasDebug = false;
        bool exit = false;
        DoTitle();

        do
        {
            Console.WriteLine();
            string userCommand = AskForCommand();
            if (workCommands.Contains(userCommand, StringComparer.Ordinal))
            {

                DoCommand();
                DoTitle();
            }

            else if (userCommand.Length >= 6)
            {

                string exe = userCommand.Substring((userCommand.Length - 4));
                
                if ((DoDebug(userCommand) == true) && (userCommand.Length > 6) && (exe == ".exe"))
                {

                    Console.WriteLine("Working...");
                    if ((RandomNumber() != 0) && (hasDebug == false))
                    {
                        Console.WriteLine("{0} has been debugged successfully!", DoDebug1(userCommand));
                        hasDebug = true;
                    }
                    else if ((RandomNumber() == 0) && (hasDebug == false))
                        Console.WriteLine("The program {0} FAILED to debug. Please try again. (Error #5683)", DoDebug1(userCommand));
                    else
                    {
                        Console.WriteLine("Couldn't fit 'IsHash(int 0)' and 'System.Loopfunction' in 'main.sys'. Has the");
                        Console.WriteLine("program been successfully debugged before? (Error #32)");
                    }
                }

                else if ((DoDebug(userCommand) == true) && (userCommand.Length > 6) && (exe != ".exe"))
                {
                    Console.WriteLine("The specified program '{0}' doesn't seem to be a recognized program.", DoDebug1(userCommand));
                    Console.WriteLine("{0} (Error #3)", HelpString());
                }
                else
                    ErrorMessage(userCommand);
            }

            else if (helpCommands.Contains(userCommand, StringComparer.OrdinalIgnoreCase))
            {
                HelpMessage();
            }
            else if (clearCommands.Contains(userCommand, StringComparer.OrdinalIgnoreCase))
            {
                DoTitle();
            }
            else if (closeCommands.Contains(userCommand, StringComparer.OrdinalIgnoreCase))
            {
                break;
            }

            else if (pingCommands.Contains(userCommand, StringComparer.Ordinal))
            {
                DoPing();
            }

            else if (pnigCommands.Contains(userCommand, StringComparer.Ordinal))
            {
                DoPnig();
            }

            else
                ErrorMessage(userCommand);

        }
        while (!exit);
    }

    private static string DoDebug1(string userCommand)
    {
        string programDebug = userCommand.Substring(6);
        return programDebug;
    }

    private static bool DoDebug(string userCommand)
    {
        string debug = userCommand.Substring(0, 6);
        if (debug == "DEBUG ")
            return true;
        else
            return false;
    }

    private static int RandomNumber()
    {
        Random random = new Random();
        return random.Next(0, 4);
    }

    private static string AskForCommand()
    {
        Console.Write("C:/>");
        string input = Console.ReadLine();
        return input;
    }

    private static void DoPnig()
    {
        Console.Write("    ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.BackgroundColor = ConsoleColor.White;
        Console.Write("Pnog?");
        Console.ResetColor();
        Console.WriteLine();
    }

    private static void DoPing()
    {
        Console.Write("    ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.BackgroundColor = ConsoleColor.White;
        Console.Write("Pong!");
        Console.ResetColor();
        Console.WriteLine();
    }

    private static void DoTitle()
    {
        Console.Clear();
        int leftOffSet = (Console.WindowWidth / 2 - (33 / 2));
        int leftOffSet2 = (Console.WindowWidth / 2 - (20 / 2));
        Console.SetCursorPosition(leftOffSet, 1);
        Console.WriteLine("C# Syntax Debugger 2.0 BUILD 33");
        Console.SetCursorPosition(leftOffSet2, 3);
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Write("--==By ");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("Qwertyuu");
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Write("==--");
        Console.ResetColor();
        Console.SetCursorPosition(0, 5);
    }

    private static void DoCommand()
    {
        System.Diagnostics.Process.Start("C:/Program Files/TrueCrypt/TrueCrypt.exe");
    }

    private static void HelpMessage()
    {
        Console.WriteLine(" Application Help:");
        Console.WriteLine("     1:'Type a debug syntax or EXIT to close the debugger.'");
        Console.WriteLine("     2:'Syntax example: DEBUG Program.exe'");
        Console.WriteLine("     3:'Also, make sure your debug command is in CAPITAL and that the");
        Console.WriteLine("        application's extension is in lowercase.'");
        Console.WriteLine("     4:'Type 'Clear' to reset the debug window and clear all entries.'");
        Console.WriteLine("     5:'Note that the debugger can only debug one program per run. It");
        Console.WriteLine("        needs to be reset to be able to debug another program.");
        Console.WriteLine("        Clearing the debug window will not reset the program.'");
    }
    private static string HelpString()
    {
        return "Please type 'HELP' or '?' for help.";
    }

    private static void ErrorMessage(string userCommand)
    {
        if (userCommand == "" || userCommand == " ")
            Console.WriteLine(" You wrote nothing." + HelpString() + "  (Error #443)");
        else
            Console.WriteLine(" '{0}' is not a known syntax. " + HelpString() + " (Error #5)", userCommand);

    }
}