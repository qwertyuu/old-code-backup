using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LoginTest
{
    class Program
    {
        static void Main(string[] args)
        {
            bool quit = false;
            while (!quit)
            {
                Console.Clear();
                Console.Write("1 pour Login, 2 pour sign-up et 3 pour se désinscrir: ");
                char uInput = Console.ReadKey(false).KeyChar;
                GetDB();
                if (char.IsNumber(uInput))
                {
                    Console.WriteLine();
                    switch (uInput)
                    {
                        case '1':
                            Login();
                            break;
                        case '2':
                            Signup();
                            break;
                        case '3':
                            Delete();
                            break;
                        default:
                            break;
                    }
                }
                else if (uInput == (char)27)
                {
                    quit = true;
                }
            }
        }

        private static void Delete()
        {
            GetDB();
            string toVerify = fileStreamed.ToString();
            bool login = false;
            bool toBreak = false;
            while (!login)
            {
                Console.Write("Nom d'utilisateur: ");
                string uName = CalculateMD5Hash(Console.ReadLine().ToUpper());
                Console.Write("Mot de passe: ");
                bool getPW = false;
                StringBuilder sB = new StringBuilder();
                while (!getPW)
                {
                    char buf = Console.ReadKey(true).KeyChar;
                    if (buf == '\r')
                    {
                        Console.WriteLine();
                        getPW = true;
                    }
                    else if (buf == '\b')
                    {
                        sB.Remove(sB.Length - 1, 1);
                        Console.Write("\b \b");
                    }
                    else if (buf == (char)27)
                    {
                        toBreak = true;
                        break;
                    }
                    else
                    {
                        sB.Append(buf);
                        Console.Write('*');
                    }
                }
                if (toBreak)
                {
                    break;
                }
                string pWord = CalculateMD5Hash(sB.ToString().ToUpper());
                string uHash = CalculateMD5Hash(uName + pWord);
                string[] streamBuf = toVerify.Split('\n');
                bool logs = false;
                int index = 0;
                foreach (var item in streamBuf)
                {
                    if (uHash == item)
                    {
                        logs = true;
                        break;
                    }
                    index++;
                }
                if (logs)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Votre compte sera supprimé, {0}.", streamBuf[index + 1]);
                    File.Delete(Directory.GetCurrentDirectory() + @"\hashlist.db");
                    using (StreamWriter sR = new StreamWriter(Directory.GetCurrentDirectory() + @"\hashlist.db", true, Encoding.Unicode))
                    {
                        for (int i = 0; i < streamBuf.Length; i++)
                        {
                            if (!(i == index || i == index + 1 || streamBuf[i] == string.Empty))
                            {
                                sR.WriteLine(streamBuf[i]);
                            }
                        }
                    }
                    Console.ResetColor();
                    System.Threading.Thread.Sleep(2500);
                    GetDB();
                    login = true;
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Erreur, veuillez réessayer.");
                    Console.ResetColor();
                }
            }
        }

        private static void Login()
        {
            string toVerify = fileStreamed.ToString();
            bool login = false;
            while (!login)
            {
                Console.Write("Nom d'utilisateur: ");
                string uName = CalculateMD5Hash(Console.ReadLine().ToUpper());
                Console.Write("Mot de passe: ");
                bool toBreak = false;
                bool getPW = false;
                StringBuilder sB = new StringBuilder();
                while (!getPW)
                {
                    char buf = Console.ReadKey(true).KeyChar;
                    if (buf == '\r')
                    {
                        Console.WriteLine();
                        getPW = true;
                    }
                    else if (buf == '\b')
                    {
                        sB.Remove(sB.Length - 1, 1);
                        Console.Write("\b \b");
                    }
                    else if (buf == (char)27)
                    {
                        toBreak = true;
                        break;
                    }
                    else
                    {
                        sB.Append(buf);
                        Console.Write('*');
                    }
                }
                if (toBreak)
                {
                    break;
                }
                string pWord = CalculateMD5Hash(sB.ToString().ToUpper());
                string uHash = CalculateMD5Hash(uName + pWord);
                string[] streamBuf = toVerify.Split('\n');
                bool logs = false;
                int index = 0;
                foreach (var item in streamBuf)
                {
                    if (uHash == item)
                    {
                        logs = true;
                        break;
                    }
                    index++;
                }
                if (logs)
                {
                    Console.Clear();
                    Console.CursorVisible = false;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Bienvenu, {0}!", streamBuf[index + 1]);
                    Console.ResetColor();
                    System.Threading.Thread.Sleep(2000);
                    Console.CursorVisible = true;
                    login = true;
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Erreur, veuillez réessayer.");
                    Console.ResetColor();
                }
            }
        }
        static StringBuilder fileStreamed = new StringBuilder();

        private static void  GetDB()
        {
            if (!File.Exists(Directory.GetCurrentDirectory() + @"\hashlist.db"))
            {
                File.Create(Directory.GetCurrentDirectory() + @"\hashlist.db").Close();
            }
            using (StreamReader w = new StreamReader(Directory.GetCurrentDirectory() + @"\hashlist.db", Encoding.Unicode, false))
            {
                fileStreamed.Clear();
                string buf;
                while ((buf = w.ReadLine()) != null)
                {
                    fileStreamed.Append(buf);
                    fileStreamed.Append('\n');
                }
            }
        }

        private static void Signup()
        {
            Console.Write("Quel est votre nom? ");
            string uName = Console.ReadLine();
            Console.Write("Quel sera votre identifiant? ");
            string userName = CalculateMD5Hash(Console.ReadLine().ToUpper());
            Console.Write("Quel sera votre mot de passe? ");
            bool getPW = false;
            StringBuilder sB = new StringBuilder();
            while (!getPW)
            {
                char buf = Console.ReadKey(true).KeyChar;
                if (buf == '\r')
                {
                    Console.WriteLine();
                    getPW = true;
                }
                else if (buf == '\b')
                {
                    sB.Remove(sB.Length - 1, 1);
                    Console.Write("\b \b");
                }
                else
                {
                    sB.Append(buf);
                    Console.Write('*');
                }
            }
            string pWord = CalculateMD5Hash(sB.ToString().ToUpper());
            string uHash = CalculateMD5Hash(userName + pWord);
            using (StreamWriter sW = new StreamWriter(Directory.GetCurrentDirectory() + @"\hashlist.db", true, Encoding.Unicode))
            {
                sW.WriteLine(uHash);
                sW.WriteLine(uName);
            }
            GetDB();
            Console.Clear();
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Votre compte a été créé avec succès, {0}!", uName);
            Console.ResetColor();
            System.Threading.Thread.Sleep(2500);
            Console.CursorVisible = true;
        }
        public static string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
