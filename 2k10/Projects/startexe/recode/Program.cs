using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] closeCommands = { "exit", "quit", "stop", "close", "kill" };
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
            //otherwise, check to see if we should exit.
            else
            {
                //check to see if close command array contains user input
                //this comparison is case INsensitive
                //meaning that close, CLOSE, or ClOsE will all match
                exit = closeCommands.Contains(userCommand, StringComparer.OrdinalIgnoreCase);
            }
        } while (!exit); //continue looping, until the variable exit is true

        //when exit is true, the loop will exit, and the application ends,
        //because this is the end of the Main method.
    }

    //this method asks the user for input
    //the method returns a string
    private static string AskForCommand()
    {
        Console.WriteLine("Enter Command: ");
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
        Console.WriteLine("Done.");
        //since the return type was void,
        //we do not return any value
    }
}