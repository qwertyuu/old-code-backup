using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace random
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 0;
            int[] probabilities = new int[100];
            bool ret = false;
            bool addData = false;
            // Dmande le nombre de shit
            num = AskForInput(ret, num);
            bool useProb = DoUseProb();
            Console.Clear();
            Random random = new Random();
            int randumStuff = random.Next(num);
            if (useProb)
            {
                randumStuff = random.Next(100);
                // Names?
                addData = IsNames(ret, addData);

                // Names!
                if (addData)
                {
                    Console.Clear();
                    string[] names = DoSetNames(num);
                    Console.Clear();
                    probabilities = DoProbNames(probabilities, names);
                    Console.Clear();
                    Console.Write("Le programme est pret. Appuyez sur une touche pour avoir la valeur...");
                    Console.ReadKey();
                    DoNamesProb(num, randumStuff, random, names, probabilities);
                }
                // No names :D
                else
                {
                    Console.Clear();
                    probabilities = DoProb(probabilities, num);
                    Console.Clear();
                    DoNoNamesProb(num, randumStuff, random, probabilities);
                    Console.Clear();
                }
            }
            else if (!useProb)
            {
                // Names?
                addData = IsNames(ret, addData);
                // Names!
                if (addData)
                {
                    //probabilities = DoProbNames(probabilities);
                    string[] names = DoSetNames(num);
                    Console.Write("Le programme est pret. Appuyez sur une touche pour avoir la valeur...");
                    Console.ReadKey();
                    DoNames(num, randumStuff, random, names);
                }
                // No names :D
                else
                    DoNoNames(num, randumStuff, random);
            }
            Console.ReadKey();
        }

        private static void DoNoNamesProb(int num, int randumStuff, Random random, int[] probabilities)
        {
            Console.Write("Le programme est pret. Appuyez sur une touche pour avoir la valeur...");
            Console.ReadKey();
            Console.Clear();
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                int perCent = ((i * 100) / Console.WindowWidth);
                Console.WriteLine("Randomizing... ");
                for (int j = 0; j < i; j++)
                {
                    Console.Write("█");
                }
                for (int j = 0; j < Console.WindowWidth - i; j++)
                {
                    Console.Write("-");
                }
                Console.SetCursorPosition(Console.WindowWidth / 2 - 3, 1);
                Console.WriteLine(perCent + "%");
                Console.SetCursorPosition(0, 2);
                Console.Write("");
                Console.WriteLine((probabilities[randumStuff] + 1));
                randumStuff = random.Next(100);
                System.Threading.Thread.Sleep(30);
                if (i < 99)
                    Console.Clear();
            }
            Console.Clear();
            Console.WriteLine("Randomizing... ");
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("█");
            }
            Console.SetCursorPosition(Console.WindowWidth / 2 - 4, 1);
            Console.WriteLine("100%");
            Console.Write("");
            Console.WriteLine("Tu prends: " + (probabilities[randumStuff] + 1));
        }

        private static void DoNamesProb(int num, int randumStuff, Random random, string[] names, int[] prob)
        {
            Console.Clear();
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                int perCent = ((i * 100) / Console.WindowWidth);
                Console.WriteLine("Randomizing... ");
                for (int j = 0; j < i; j++)
                {
                    Console.Write("█");
                }
                for (int j = 0; j < Console.WindowWidth - i; j++)
                {
                    Console.Write("-");
                }
                Console.SetCursorPosition(Console.WindowWidth / 2, 1);
                Console.WriteLine(perCent + "%");
                Console.SetCursorPosition(0, 2);
                Console.Write("");
                Console.WriteLine(names[prob[randumStuff]]);
                randumStuff = random.Next(100);
                System.Threading.Thread.Sleep(40);
                if (i < 99)
                    Console.Clear();
            }
            Console.Clear();
            Console.WriteLine("Randomizing... ");
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("█");
            }
            Console.SetCursorPosition(Console.WindowWidth / 2, 1);
            Console.WriteLine("100%");
            Console.SetCursorPosition(0, 2);
            Console.Write("");
            Console.WriteLine("Tu prends: " + names[prob[randumStuff]]);
        }

        private static string[] DoSetNames(int num)
        {
            string[] names = new string[num];
            Console.WriteLine(num + " noms à entrer.");
            for (int i = 0; i < num; i++)
            {
                if (i == 0)
                    Console.Write("1er nom: ");
                else
                    Console.Write(i + 1 + "ieme nom: ");
                names[i] = Console.ReadLine();
            }
            return names;
        }

        private static int[] DoProb(int[] probabilities, int num)
        {
            int lastShit = 0;
            for (int i = 0; i < num; i++)
            {
                Console.Write("Probabilités de: " + '"' + "{0}" + '"' + " en pourcentage: ", (i + 1));
                string userCommand = Console.ReadLine();
                if (userCommand.Substring(userCommand.Length - 1) == "%")
                    userCommand = userCommand.Substring(0, userCommand.Length - 1);
                int userCommandInt = int.Parse(userCommand);
                for (int j = lastShit; j <= lastShit + userCommandInt && j < 100; j++)
                {
                    probabilities[j] = i;
                }
                lastShit = userCommandInt + lastShit;
            }
            return probabilities;
        }

        private static int[] DoProbNames(int[] probabilities, string[] names)
        {
            int lastShit = 0;
            for (int i = 0; i < names.Length; i++)
            {
                Console.Write("Probabilités de: " + '"' + "{0}" + '"' + " en pourcentage: ", names[i]);
                string userCommand = Console.ReadLine();
                if (userCommand.Substring(userCommand.Length - 1) == "%")
                    userCommand = userCommand.Substring(0, userCommand.Length - 1);
                int userCommandInt = int.Parse(userCommand);
                for (int j = lastShit; j <= lastShit + userCommandInt && j < 100; j++)
                {
                    probabilities[j] = i;
                }
                lastShit = userCommandInt + lastShit;
            }
            return probabilities;
        }

        private static bool DoUseProb()
        {

            bool sì = false;
            bool ret = false;
            do
            {
                Console.Write("Utiliser les probabilités?: ");
                string userCommand = Console.ReadLine();
                if (userCommand == "1")
                {
                    sì = true;
                    ret = true;
                }
                else if (userCommand == "0")
                    ret = true;
            } while (!ret);
            return sì;
        }

        private static void DoNoNames(int num, int randumStuff, Random random)
        {
            Console.Write("Le programme est pret. Appuyez sur une touche pour avoir la valeur...");
            Console.ReadKey();
            Console.Clear();
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                int perCent = ((i * 100) / Console.WindowWidth);
                Console.WriteLine("Randomizing... ");
                for (int j = 0; j < i; j++)
                {
                    Console.Write("█");
                }
                for (int j = 0; j < Console.WindowWidth - i; j++)
                {
                    Console.Write("-");
                }
                Console.SetCursorPosition(Console.WindowWidth / 2 - 3, 1);
                Console.WriteLine(perCent + "%");
                Console.SetCursorPosition(0, 2);
                Console.Write("");
                Console.WriteLine((randumStuff + 1));
                randumStuff = random.Next(num);
                System.Threading.Thread.Sleep(30);
                if (i < 99)
                    Console.Clear();
            }
            Console.Clear();
            Console.WriteLine("Randomizing... ");
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("█");
            }
            Console.SetCursorPosition(Console.WindowWidth / 2 - 4, 1);
            Console.WriteLine("100%");
            Console.Write("");
            Console.WriteLine("Tu prends: " + (randumStuff + 1));
        }

        private static void DoNames(int num, int randumStuff, Random random, string[] names)
        {
            Console.Clear();
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                int perCent = ((i * 100) / Console.WindowWidth);
                Console.WriteLine("Randomizing... ");
                for (int j = 0; j < i; j++)
                {
                    Console.Write("█");
                }
                for (int j = 0; j < Console.WindowWidth - i; j++)
                {
                    Console.Write("-");
                }
                Console.SetCursorPosition(Console.WindowWidth / 2, 1);
                Console.WriteLine(perCent + "%");
                Console.SetCursorPosition(0, 2);
                Console.Write("");
                Console.WriteLine(names[randumStuff]);
                randumStuff = random.Next(num);
                System.Threading.Thread.Sleep(30);
                if (i < 99)
                    Console.Clear();
            }
            Console.Clear();
            Console.WriteLine("Randomizing... ");
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("█");
            }
            Console.SetCursorPosition(Console.WindowWidth / 2, 1);
            Console.WriteLine("100%");
            Console.SetCursorPosition(0, 2);
            Console.Write("");
            Console.WriteLine("Tu prends: " + names[randumStuff]);
        }

        private static bool IsNames(bool ret, bool addData)
        {
            do
            {
                Console.Write("Utiliser des noms?: ");
                string userCommand = Console.ReadLine();
                if (userCommand == "1")
                {
                    addData = true;
                    ret = false;
                }
                else if (userCommand == "0")
                    ret = false;
                if (addData == true || userCommand != "0" && userCommand != "1")
                    Console.Clear();
            } while (ret);
            return addData;
        }

        private static int AskForInput(bool ret, int num)
        {
            do
            {
                Console.Write("Combien de données?: ");
                string userCommand = Console.ReadLine();
                if (int.TryParse(userCommand, out num) && num > 0)
                {
                    ret = true;
                }
                Console.Clear();
            } while (!ret);
            return num;
        }
    }
}