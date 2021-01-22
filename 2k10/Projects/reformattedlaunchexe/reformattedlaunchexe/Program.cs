using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] closeCommands = { "exit", "quit", "stop", "close", "kill", "  " };
        string[] helpCommands = { "help", "?" };
        string[] workCommands = { "PASSWORD" };

        bool exit = false;

        do //begin a loop
        {
            //get user input
            string userCommand = AskForCommand();
            //check to see if work command array contains user input.
            //this comparison is case sensitive
            if (workCommands.Contains(userCommand, StringComparer.Ordinal))
            {
                //if it does, call the method DoCommand.
                DoCommand();
            }

            else if (helpCommands.Contains(userCommand, StringComparer.OrdinalIgnoreCase))
                HelpMessage();

            //otherwise, check to see if we should exit.
            else
            {
                //check to see if close command array contains user input
                //this comparison is case INsensitive
                //meaning that close, CLOSE, or ClOsE will all match
                exit = closeCommands.Contains(userCommand, StringComparer.OrdinalIgnoreCase);
            }

            ErrorMessage(userCommand);
            
        } 
        while (!exit); //continue looping, until the variable exit is true

        //when exit is true, the loop will exit, and the application ends,
        //because this is the end of the Main method.
    }

    //this method asks the user for input
    //the method returns a string
    private static string AskForCommand()
    {
        Console.Write("C:/>");
        string input = Console.ReadLine();
        //since the method returns a string, we return input.
        return input;
    }

    //this method does something, in this case it's just an example
    //the method's return type is "void"
    private static void DoCommand()
    {
        //do whatever you want here.
        //this is just an example:
        Console.WriteLine("Doing some work.....");
        System.Diagnostics.Process.Start("C:/Program Files/TrueCrypt/TrueCrypt.exe");
        Console.WriteLine("Done.");
        Console.WriteLine("Bienvenue Raph!");
        //since the return type was void,
        //we do not return any value
    }
    private static void HelpMessage()
    {
        Console.WriteLine("Type a debug syntax or EXIT to close the debugger.");
    }

    private static void ErrorMessage(string userCommand)
    {
        if (userCommand == "")
            Console.WriteLine("You wrote nothing. Please type HELP for help. (Error #443)");
        else
            Console.WriteLine("'{0}' is not a known syntax. Please type HELP for help. (Error #5)", userCommand);

    }
}