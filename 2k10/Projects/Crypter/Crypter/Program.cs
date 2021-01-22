using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oyster.Math;

namespace Crypter
{
    class Program
    {
        static void Main(string[] args)
        {
            IntX pass = DoSetPassword();
            int i = 0;
            string userCommand = Console.ReadLine();
            string[] valueStringArray = new string[userCommand.Length];
            foreach (char c in userCommand)
            {
                valueStringArray[i] = GetTheValue(c).ToString();
                i++;
            }
            string stringFromArray = ConvertStringArrayToString(valueStringArray);
            IntX uncryptedMessage = IntX.Parse(stringFromArray);
            IntX cryptedMessage = DoCryptMessage(pass, uncryptedMessage);
            Console.WriteLine(cryptedMessage);
            //DoDecryptMessage(cryptedMessage, pass);
            Console.ReadLine();

        }

        private static IntX DoCryptMessage(IntX pass, IntX uncryptedMessage)
        {
            int last = 0;
            string[] cryptString = new string[uncryptedMessage.ToString().Length/3];
            for (int i = 0; i < uncryptedMessage.ToString().Length/3; i++)
            {
                cryptString[i] = uncryptedMessage.ToString().Substring(last, last + 3);
                IntX[] haha = new IntX[uncryptedMessage.ToString().Length / 3];
            }
            IntX crypt = IntX.Parse("haha");
            return crypt;
        }
        private static IntX DoSetPassword()
        {
            bool muum = false;
            IntX value;
            do
            {
                int i = 0;
                Console.Write("What Password to crypt?: ");
                string passWord = Console.ReadLine();
                string[] valueStringArray = new string[passWord.Length];
                foreach (char c in passWord)
                {
                    valueStringArray[i] = GetTheValue(c).ToString();
                    i++;
                }
                string passString = ConvertStringArrayToString(valueStringArray);
                value = IntX.Parse(passString);
                if (value.ToString().Length >= 10)
                {
                    muum = false;
                    Console.WriteLine("Password too long.");
                }
                else
                {
                    muum = true;
                }
            } while (muum == false);
            return value;
        }
        static string ConvertStringArrayToString(string[] array)
        {
            StringBuilder builder = new StringBuilder();
            foreach (string value in array)
            {
                builder.Append(value);
            }
            return builder.ToString();
        }
        private static int GetTheValue(Char c) 
        {
            if(c >= '0' && c <= '9')
            {
                return (int)c - (int)'0' + 40;
            } 
            else if(c >= 'A' && c <= 'Z') 
            { 
                return (int)c - (int)'A' + 10; 
            }
            else if (c >= 'a' && c <= 'z')
            {
                return (int)c - (int)'a' + 10;
            }
            else if (c == ' ')
            {
                return 37;
            }
            else
            {
                return 36;
            }
        }   

        
    }
}
