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
            IntX uncryptedMessage = PlainMessageinput();
            IntX cryptedMessage = DoCryptMessage(pass, uncryptedMessage);
            Console.WriteLine(cryptedMessage);
            //DoDecryptMessage(cryptedMessage, pass);
            Console.ReadLine();

        }

        private static IntX PlainMessageinput()
        {
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
            return uncryptedMessage;
        }

        private static IntX DoCryptMessage(IntX pass, IntX uncryptedMessage)
        {
            string toSubstringPass = pass.ToString();
            string toSubstringMessage = uncryptedMessage.ToString();
            string subPass1 = toSubstringPass.Substring(0, toSubstringPass.Length / 2);
            string subPass2 = toSubstringPass.Substring(toSubstringPass.Length / 2);
            string subMessage1 = toSubstringMessage.Substring(0, toSubstringMessage.Length / 2);
            string subMessage2 = toSubstringMessage.Substring(toSubstringMessage.Length / 2);
            //string a = substring1.Substring(0, substring1.Length / 3);
            //string b = substring1.Substring(substring1.Length / 3, substring1.Length / 3 + substring1.Length / 3);
            //string c = substring1.Substring(substring1.Length / 3 + substring1.Length / 3);
            //string d = substring2.Substring(0, substring2.Length / 3);
            //string e = substring2.Substring(substring2.Length / 3, substring2.Length / 3 + substring2.Length / 3);
            //string f = substring2.Substring(substring2.Length / 3 + substring2.Length / 3);
            //IntX a1 = IntX.Parse(a);
            //IntX b1 = IntX.Parse(b);
            //IntX c1 = IntX.Parse(c);
            //IntX d1 = IntX.Parse(d);
            //IntX e1 = IntX.Parse(e);
            //IntX f1 = IntX.Parse(f);
            IntX abc = IntX.Parse(subPass1);
            IntX def = IntX.Parse(subPass2);
            IntX m1 = IntX.Parse(subMessage1);
            IntX m2 = IntX.Parse(subMessage2);
            IntX a1 = 0;
            IntX b1 = 0;
            string message = "haha";
            a1 = abc - m1;
            b1 = def - m2;
            if (a1 < 0 && b1 < 0)
            {
                message = ;
            }
            //string message = '-' + a1.ToString() + b1.ToString();
            IntX crypt = IntX.Parse(message);
            return crypt;
        }
        //private static string DoDecryptMessage(IntX cryptedMessage, IntX pass)
        //{
        //    string toSubstringPass = pass.ToString();
        //    string subPass1 = toSubstringPass.Substring(0, toSubstringPass.Length / 2);
        //    string subPass2 = toSubstringPass.Substring(toSubstringPass.Length / 2);
        //    IntX abc = IntX.Parse(subPass1);
        //    IntX def = IntX.Parse(subPass2);
        //}
        private static IntX DoSetPassword()
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
            IntX value = IntX.Parse(passString);
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
            else
            {
                return 36;
            }
        }   

        
    }
}
