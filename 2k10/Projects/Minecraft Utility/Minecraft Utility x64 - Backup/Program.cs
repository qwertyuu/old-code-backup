using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;


namespace Minecraft_Utility
{
    class Program
    {
        static void Main(string[] args)
        {
            DoTitle();
            bool debug = false;
            if (DoDebug() == true)
                debug = true;
            string workingDir = GetPath();
            if (!IsExist(workingDir))
                do
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Le fichier 'minecraft_server.jar' n'a pas été trouvé!,");
                    workingDir = DoWhereIs();
                } while (!IsExist(workingDir));
            if (IsExist(workingDir))
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Le fichier 'minecraft_server.jar' a été trouvé!");
                Console.ResetColor();
            }
            bool exit = false;
            bool ret = false;
            do
            {

                TextWriter tw = new StreamWriter(workingDir + "/server.properties");
                tw.WriteLine("enable-query=false");
                tw.WriteLine("enable-rcon=false");
                tw.WriteLine("server-ip=");
                tw.WriteLine("max-build-height=256");
                tw.WriteLine("snooper-enabled=true");
                tw.WriteLine("texture-pack=");
                if (debug == true)
                {
                    DoDebug(tw);
                    LaunchServerDebug(workingDir);
                    break;
                }



                do
                {
                    Console.Write("Nether? (0 - 1): ");
                    string userCommand = AskForInput();
                    if (userCommand == "1")
                    {
                        tw.WriteLine("allow-nether=true");
                        ret = true;
                    }
                    else if (userCommand == "0")
                    {
                        tw.WriteLine("allow-nether=false");
                        ret = true;
                    }
                } while (!ret);
                ret = false;
                do
                {
                    Console.Write("Nom du Level?: ");
                    string userCommand = AskForInput();
                    tw.WriteLine("level-name=" + userCommand);
                    ret = true;
                } while (!ret);
                ret = false;
                do
                {
                    Console.Write("Pouvoir voler? (0 - 1): ");
                    string userCommand = AskForInput();
                    if (userCommand == "1")
                    {
                        tw.WriteLine("allow-flight=true");
                        ret = true;
                    }
                    else if (userCommand == "0")
                    {
                        tw.WriteLine("allow-flight=false");
                        ret = true;
                    }

                } while (!ret);
                ret = false;
                do
                {
                    Console.Write("Port du serveur? (d pour port par défaut): ");
                    string userCommand = AskForInput();


                    if (DoIsNumber(userCommand) == true)
                    {
                        tw.WriteLine("server-port=" + userCommand);
                        ret = true;
                    }
                    if (userCommand == "d")
                    {
                        tw.WriteLine("server-port=25565");
                        ret = true;
                    }
                } while (!ret);
                ret = false;
                do
                {
                    Console.Write("Type de monde? (1 = normal, 2 = plat, 3 = biomes larges.): ");
                    string userCommand = AskForInput();
                    if (userCommand == "1")
                    {
                        tw.WriteLine("level-type=DEFAULT");
                        ret = true;
                    }
                    else if (userCommand == "2")
                    {
                        tw.WriteLine("level-type=FLAT");
                        ret = true;
                    }
                    else if (userCommand == "3")
                    {
                        tw.WriteLine("level-type=LARGEBIOMES");
                        ret = true;
                    }

                } while (!ret);
                ret = false;
                do
                {
                    Console.Write("Seed de la map?: ");
                    string userCommand = AskForInput();
                    tw.WriteLine("level-seed=" + userCommand);
                    ret = true;
                } while (!ret);
                ret = false;
                do
                {
                    Console.Write("NPCs? (0 - 1): ");
                    string userCommand = AskForInput();
                    if (userCommand == "0")
                    {
                        tw.WriteLine("spawn-npcs=false");
                        ret = true;
                    }
                    else if (userCommand == "1")
                    {
                        tw.WriteLine("spawn-npcs=true");
                        ret = true;
                    }
                } while (!ret);
                ret = false;
                do
                {
                    Console.Write("Whitelist? (0 - 1): ");
                    string userCommand = AskForInput();
                    if (userCommand == "0")
                    {
                        tw.WriteLine("white-list=false");
                        ret = true;
                    }
                    else if (userCommand == "1")
                    {
                        tw.WriteLine("white-list=true");
                        ret = true;
                    }
                } while (!ret);
                ret = false;
                do
                {
                    Console.Write("Animaux? (0 - 1): ");
                    string userCommand = AskForInput();
                    if (userCommand == "0")
                    {
                        tw.WriteLine("spawn-animals=false");
                        ret = true;
                    }
                    else if (userCommand == "1")
                    {
                        tw.WriteLine("spawn-animals=true");
                        ret = true;
                    }
                } while (!ret);
                ret = false;
                do
                {
                    Console.Write("Hardcore? (0 - 1): ");
                    string userCommand = AskForInput();
                    if (userCommand == "0")
                    {
                        tw.WriteLine("hardcore=false");
                        ret = true;
                    }
                    else if (userCommand == "1")
                    {
                        tw.WriteLine("hardcore=true");
                        ret = true;
                    }
                } while (!ret);
                ret = false;
                do
                {
                    Console.Write("Cracké? (0 - 1): ");
                    string userCommand = AskForInput();
                    if (userCommand == "0")
                    {
                        tw.WriteLine("online-mode=true");
                        ret = true;
                    }
                    else if (userCommand == "1")
                    {
                        tw.WriteLine("online-mode=false");
                        ret = true;
                    }
                } while (!ret);
                ret = false;
                do
                {
                    Console.Write("PVP? (0 - 1): ");
                    string userCommand = AskForInput();
                    if (userCommand == "0")
                    {
                        tw.WriteLine("pvp=false");
                        ret = true;
                    }
                    else if (userCommand == "1")
                    {
                        tw.WriteLine("pvp=true");
                        ret = true;
                    }
                } while (!ret);
                ret = false;
                do
                {
                    Console.Write("Difficultée? (0 = peaceful, 1 = easy, 2 = normal, 3 = hard.): ");
                    string userCommand = AskForInput();
                    if (userCommand == "0")
                    {
                        tw.WriteLine("difficulty=0");
                        ret = true;
                    }
                    else if (userCommand == "1")
                    {
                        tw.WriteLine("difficulty=1");
                        ret = true;
                    }
                    else if (userCommand == "2")
                    {
                        tw.WriteLine("difficulty=2");
                        ret = true;
                    }
                    else if (userCommand == "3")
                    {
                        tw.WriteLine("difficulty=3");
                        ret = true;
                    }
                } while (!ret);
                ret = false;
                do
                {
                    Console.Write("Mode de jeu? (0 = survie, 1 = creative, 2 = aventure): ");
                    string userCommand = AskForInput();
                    if (userCommand == "0")
                    {
                        tw.WriteLine("gamemode=0");
                        ret = true;
                    }
                    else if (userCommand == "1")
                    {
                        tw.WriteLine("gamemode=1");
                        ret = true;
                    }
                    else if (userCommand == "2")
                    {
                        tw.WriteLine("gamemode2");
                        ret = true;
                    }
                } while (!ret);
                ret = false;
                do
                {
                    Console.Write("Nombre de joueurs max?: ");
                    string userCommand = AskForInput();


                    if (DoIsNumber(userCommand) == true)
                    {
                        tw.WriteLine("max-players=" + userCommand);
                        ret = true;
                    }

                } while (!ret);
                ret = false;
                do
                {
                    Console.Write("Monstres? (0 - 1): ");
                    string userCommand = AskForInput();
                    if (userCommand == "0")
                    {
                        tw.WriteLine("spawn-monsters=false");
                        ret = true;
                    }
                    else if (userCommand == "1")
                    {
                        tw.WriteLine("spawn-monsters=true");
                        ret = true;
                    }
                } while (!ret);
                ret = false;
                do
                {
                    Console.Write("Distance de vision? (d pour distance par défaut): ");
                    string userCommand = AskForInput();


                    if (DoIsNumber(userCommand) == true)
                    {
                        tw.WriteLine("view-distance=" + userCommand);
                        ret = true;
                    }

                    if (userCommand == "d")
                    {
                        tw.WriteLine("view-distance=6");
                        ret = true;
                    }
                } while (!ret);
                ret = false;
                do
                {
                    Console.Write("Générer les structures? (0 - 1): ");
                    string userCommand = AskForInput();
                    if (userCommand == "0")
                    {
                        tw.WriteLine("generate-structures=false");
                        ret = true;
                    }
                    else if (userCommand == "1")
                    {
                        tw.WriteLine("generate-structures=true");
                        ret = true;
                    }
                } while (!ret);
                ret = false;
                do
                {
                    Console.Write("Message du jour?: ");
                    string userCommand = AskForInput();
                    tw.WriteLine("motd=" + userCommand);
                    ret = true;
                } while (!ret);
                tw.Close();
                ret = false;
                do
                {
                    Console.Write("Changer la liste des administrateurs (OP) du serveur? (0 - 1): ");
                    string userCommand = AskForInput();
                    if (userCommand == "1")
                    {
                        DoChangeAdmin();
                        ret = true;
                    }
                    if (userCommand == "0")
                        ret = true;

                } while (!ret);
                ret = false;
                do
                {
                    Console.Write("Utiliser Java 32 ou 64 bit? (0 = 32, 1 = 64, d = défaut): ");
                    string userCommand = AskForInput();
                    if (userCommand == "0" || userCommand == "d")
                    {
                        LaunchServer32(workingDir);
                        ret = true;
                    }
                    else if (userCommand == "1")
                    {
                        bool ret1 = false;
                        do
                        {
                            Console.Write("Java Heap Size? (en GB): ");
                            userCommand = AskForInput();
                            if (DoIsNumber(userCommand))
                               ret1 = true;
                        } while (!ret1);
                        LaunchServer64(workingDir, userCommand);
                        ret = true;
                    }
                } while (!ret);
                exit = true;
            }
            while (!exit);
        }

        private static void LaunchServerDebug(string workingDir)
        {
            string path1 = workingDir.Replace("\\", "\\");
            string path = workingDir.Replace('\\', '/');
            var processInfo = new ProcessStartInfo();
            Directory.SetCurrentDirectory(path + "/");
            Process proc;
            processInfo.FileName = @"C:\Program Files\Java\jre7\bin\java.exe";
            processInfo.Arguments = "-Xmx4096M -Xms4096M " + "-jar " + '"' + path1 + "/minecraft_server.jar" + '"';
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = true;
            if ((proc = Process.Start(processInfo)) == null)
            {
                throw new InvalidOperationException("??");
            }
            proc.Close();
        }

        private static bool IsExist(string workingDir)
        {
            if (File.Exists(workingDir + "/minecraft_server.jar"))
                return true;
            return false;
        }

        private static void DoChangeAdmin()
        {
            bool exit = false;
            do
            {
                StreamReader re = File.OpenText("saved.txt");
                string inputText = re.ReadLine();
                System.IO.FileInfo file = new System.IO.FileInfo(inputText);
                file.Directory.Create();
                TextWriter tw = new StreamWriter(file + "/ops.txt");
                Console.Write("Combien d'admins?: ");
                string userCommand = AskForInput();
                int num;
                if (int.TryParse(userCommand, out num))
                {
                    if (num > 1)
                    {
                        for (int nbAdmins = 1; nbAdmins < num + 1; nbAdmins++)
                        {
                            if (nbAdmins == 1)
                                Console.Write("Pseudo du {0}er Admin: ", nbAdmins);
                            else if (nbAdmins > 1)
                                Console.Write("Pseudo du {0}ième Admin: ", nbAdmins);
                            tw.WriteLine(AskForInput());
                            exit = true;
                        }
                    }
                    else if (num == 1)
                    {
                        Console.Write("Pseudo de l'Admin: ");
                        tw.WriteLine(AskForInput());
                        exit = true;
                    }
                }
                tw.Close();
            } while (!exit);

        }

        private static void LaunchServer64(string workingDir, string userCommand)
        {
            int num;
            num = (int.Parse(userCommand) * 1024);
            string path1 = workingDir.Replace("\\", "\\");
            string path = workingDir.Replace('\\', '/');
            var processInfo = new ProcessStartInfo();
            Directory.SetCurrentDirectory(path + "/");
            Process proc;
            processInfo.FileName = @"C:\Program Files\Java\jre7\bin\java.exe";
            processInfo.Arguments = "-Xmx" + num + "M -Xms" + num + "M " + "-jar " + '"' + path1 + "/minecraft_server.jar" + '"';
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = true;
            if ((proc = Process.Start(processInfo)) == null)
            {
                throw new InvalidOperationException("??");
            }
            proc.Close();
        }

        private static void LaunchServer32(string workingDir)
        {
            string path1 = workingDir.Replace("\\", "\\");
            string path = workingDir.Replace('\\', '/');
            var processInfo = new ProcessStartInfo();
            Directory.SetCurrentDirectory(path + "/");
            Process proc;
            processInfo.FileName = @"java";
            processInfo.Arguments = "-jar " + '"' + path1 + "/minecraft_server.jar" + '"';
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = true;
            if ((proc = Process.Start(processInfo)) == null)
            {
                throw new InvalidOperationException("??");
            }
            proc.Close();
        }

        private static bool DoIsNumber(string userCommand)
        {
            int num;
            if (int.TryParse(userCommand, out num))
            {
                return true;
            }
            return false;
        }


        private static string GetPath()
        {
            if (File.Exists(@"saved.txt"))
            {
                StreamReader re = File.OpenText("saved.txt");
                string input = null;
                while ((input = re.ReadLine()) != null)
                {
                    bool kill = false;
                    do
                    {
                        Console.WriteLine();
                        Console.WriteLine("Utiliser l'ancien Serveur à:");
                        Console.Write("'{0}' ? (0 - 1): ", input);
                        string reponse = Console.ReadLine();
                        if (reponse == "1")
                        {
                            re.Close();
                            return input;
                        }
                        if (reponse == "0")
                        {
                            re.Close();
                            kill = true;
                        }
                    } while (!kill);
                    break;

                }

            }
            return DoWhereIs();

        }
        private static string DoWhereIs()
        {
            Console.Write("Où est minecraft_server.jar?:");
            Console.ResetColor();
            Console.Write(" ");
            string inputText = Console.ReadLine();
            System.IO.FileInfo file = new System.IO.FileInfo(inputText);
            file.Directory.Create(); // If the directory already exists, this method does nothing.

            TextWriter saveData = new StreamWriter("saved.txt");
            saveData.WriteLine(file);

            saveData.Close();
            return file.ToString();
        }
        private static void DoTitle()
        {
            Console.Clear();
            string mainTitle = "Minecraft Server Utility";
            int mainTitleLenght = mainTitle.Length;
            int leftOffSet = (Console.WindowWidth / 2 - (mainTitleLenght / 2));
            int leftOffSet2 = (Console.WindowWidth / 2 - (20 / 2));
            Console.SetCursorPosition(leftOffSet, 1);
            Console.WriteLine(mainTitle);
            Console.SetCursorPosition(leftOffSet2, 3);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("--==By ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Qwertyuu");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("==--");
            Console.ResetColor();
            Console.SetCursorPosition(0, 6);


        }
        private static bool DoDebug()
        {
            Console.Write("Appuyer sur enter pour commencer! ");
            if (AskForInput() == "debug")
            {
                return true;
            }
            return false;
        }

        private static void DoDebug(TextWriter tw)
        {
            tw.WriteLine(@"#DEBUG PROPERTIES FILE
            allow-nether=true
            level-name=test
            allow-flight=false
            server-port=25565
            level-type=DEFAULT
            level-seed=404
            spawn-npcs=true
            white-list=false
            spawn-animals=true
            hardcore=false
            online-mode=false
            pvp=false
            difficulty=2
            gamemode=0
            max-players=10
            spawn-monsters=true
            view-distance=6
            generate-structures=true
            motd=");
            tw.Close();

        }
        private static string AskForInput()
        {
            string input = Console.ReadLine();
            return input;
        }
    }
}