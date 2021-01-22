using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*
 * Tu t'es laissé une note à ~781
 * - AutoUpdater (Version Pré-release?)
 * - Laisse-toi des notes (surtout où les question types pask t'es cave criss)
 * - Créer un autre type de question (questiontype) avec des default values!!!! (sti dbonne idée criss de tarte)
 */
using System.IO;
using System.Diagnostics;
using System.Net;

namespace Minecraft_Utility
{
    class Program
    {
        static void Main(string[] args)
        {
            DoTitle();
            bool doDoConfig = true;
            int step = 0;
            /*
             * pas laisser ça      >>>>>>      vv
             * en constante,       >>>>>>      vv
             * les changer en variable         vv
             * pour avoir le contrôle          vv
             * sur le nombre de values à       vv
             * loader et à créer dans le       vv
             */// preset creator/loader.       vv
            string[] loadedValues = new string[22];
            bool[] mySettings = new bool[22];
            string[] loadedSettings = new string[44];
            string[] configQuestions = { "Nether? (0 - 1): ", "Nom du Monde?: ", "Pouvoir voler? (0 - 1): ", "Port du serveur? (d pour port par défaut): ", "Type de monde? (1 = normal, 2 = plat, 3 = biomes larges.): ", "Seed de la map?: ", "NPCs? (0 - 1): ", "Whitelist? (0 - 1): ", "Animaux? (0 - 1): ", "Hardcore? (0 - 1): ", "Cracké? (0 - 1): ", "PVP? (0 - 1): ", "Difficultée? (0 = peaceful, 1 = easy, 2 = normal, 3 = hard.): ", "Mode de jeu? (0 = survie, 1 = creative, 2 = aventure): ", "Nombre de joueurs max?: ", "Monstres? (0 - 1): ", "Distance de vision? (d pour distance par défaut): ", "Générer les structures? (0 - 1): ", "Message du jour?: ", "Changer la liste des administrateurs (OP) du serveur? (0 - 1): ", "Utiliser Java 32 ou 64 bit? (0 = 32, 1 = 64, d = défaut): " , "Java Heap Size?: "};
            int[] questionTypes = { 1, 2, 1, 3, 4, 2, 1, 1, 1, 1, 1, 1, 4, 4, 3, 1, 3, 1, 2, 1, 5, 4 };
            for (int i = 0; i < 22; i++)
            {
                mySettings[i] = false;
            }
            bool debug = false;

            if (DoDebug() == true)
                debug = true;
            string workingDir = GetPath();
            if (!IsExist(workingDir))
                do
                {
                    string userCommand = "haha";
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Le fichier 'minecraft_server.jar' n'a pas été trouvé!,");
                    Console.ResetColor();
                    Console.Write("Voulez-vous le télécharger à l'endroit indiqué? (0 - 1): ");
                    userCommand = AskForInput();
                    if (userCommand == "1")
                    {
                        WebClient webClient = new WebClient();
                        webClient.DownloadFile("http://s3.amazonaws.com/MinecraftDownload/launcher/minecraft_server.jar", workingDir + @"\minecraft_server.jar");
                    }
                    else if (userCommand == "0")
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
                string userCommand = "haha";
                Console.Write("Voulez vous seulement lancer le serveur? (0 - 1): ");
                userCommand = AskForInput();
                if (userCommand == "1")
                {
                    doDoConfig = false;
                    do
                    {
                        Console.Write("Utiliser Java 32 ou 64 bit? (0 = 32, 1 = 64, d = défaut): ");
                        userCommand = AskForInput();
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
                    break;
                }
                if (userCommand == "0")
                    ret = true;
            } while (!ret);
            ret = false;
            if (doDoConfig == true)
            {
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

                        string userCommand = "haha";
                        Console.Write("Créer/Loader un preset?(VERSION BETA)(0 - 1): ");
                        userCommand = AskForInput();
                        if (userCommand == "1")
                        {
                            int i = 0;
                            Console.Write("Créer ou Loader? (1 = Créer, 2 = Loader): ");
                            userCommand = AskForInput();
                            if (userCommand == "1")
                            {
                                DoCreatePreset(mySettings, configQuestions);
                                Console.Write("Fichier enregistré! Voulez-vous le loader?(0 - 1): ");
                                userCommand = AskForInput();
                                if (userCommand == "0")
                                    break;
                                else if (userCommand == "1")
                                {
                                    userCommand = "2";
                                    ret = true;
                                }
                                else
                                    ret = false;
                            }
                            if (userCommand == "2")
                            {
                                int k = 0;
                                foreach (string haha in DoLoadPreset())
                                {
                                    loadedSettings[i] = haha;
                                    i++;
                                }
                                for (int j = 0; j < 22; j++)
                                {
                                    bool boolConfig = Convert.ToBoolean(loadedSettings[k]);
                                    mySettings[j] = boolConfig;
                                    loadedValues[j] = loadedSettings[k + 1];
                                    k = k + 2;
                                }
                            }
                            if (loadedSettings[40] != null)
                            {
                                Console.WriteLine("Fichié Loadé!");
                                ret = true;
                            }
                            else if (loadedSettings[40] == null)
                                Console.WriteLine("Whoops");

                        }
                        if (userCommand == "0")
                            ret = true;

                    } while (!ret);
                    ret = false;
                    do
                    {
                        string userCommand = "haha";
                        Console.Write("Nether? (0 - 1): ");
                        if (mySettings[step] == false)
                            userCommand = AskForInput();
                        else if (mySettings[step] == true)
                        {
                            userCommand = loadedValues[step].ToString();
                            Console.WriteLine(userCommand);
                        }
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
                    step++;
                    do
                    {
                        string userCommand = "haha";
                        Console.Write("Nom du Monde?: ");
                        if (mySettings[step] == false)
                            userCommand = AskForInput();
                        else if (mySettings[step] == true)
                        {
                            userCommand = loadedValues[step].ToString();
                            Console.WriteLine(userCommand);
                        }
                        tw.WriteLine("level-name=" + userCommand);
                        ret = true;
                    } while (!ret);
                    ret = false;
                    step++;
                    {
                        do
                        {
                            string userCommand = "haha";
                            Console.Write("Pouvoir voler? (0 - 1): ");
                            if (mySettings[step] == false)
                                userCommand = AskForInput();
                            else if (mySettings[step] == true)
                            {
                                userCommand = loadedValues[step].ToString();
                                Console.WriteLine(userCommand);
                            }
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
                    }
                    ret = false;
                    step++;
                    {
                        do
                        {
                            string userCommand = "haha";
                            Console.Write("Port du serveur? (d pour port par défaut): ");
                            if (mySettings[step] == false)
                                userCommand = AskForInput();
                            else if (mySettings[step] == true)
                            {
                                userCommand = loadedValues[step].ToString();
                                Console.WriteLine(userCommand);
                            }
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
                    }
                    ret = false;
                    step++;
                    {
                        do
                        {
                            string userCommand = "haha";
                            Console.Write("Type de monde? (1 = normal, 2 = plat, 3 = biomes larges.): ");
                            if (mySettings[step] == false)
                                userCommand = AskForInput();
                            else if (mySettings[step] == true)
                            {
                                userCommand = loadedValues[step].ToString();
                                Console.WriteLine(userCommand);
                            }
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
                    }
                    ret = false;
                    step++;
                    {
                        do
                        {
                            string userCommand = "haha";
                            Console.Write("Seed de la map?: ");
                            if (mySettings[step] == false)
                                userCommand = AskForInput();
                            else if (mySettings[step] == true)
                            {
                                userCommand = loadedValues[step].ToString();
                                Console.WriteLine(userCommand);
                            }
                            tw.WriteLine("level-seed=" + userCommand);
                            ret = true;
                        } while (!ret);
                    }
                    ret = false;
                    step++;
                    {
                        do
                        {
                            string userCommand = "haha";
                            Console.Write("NPCs? (0 - 1): ");
                            if (mySettings[step] == false)
                                userCommand = AskForInput();
                            else if (mySettings[step] == true)
                            {
                                userCommand = loadedValues[step].ToString();
                                Console.WriteLine(userCommand);
                            }
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
                    }
                    ret = false;
                    step++;
                    {
                        do
                        {
                            string userCommand = "haha";
                            Console.Write("Whitelist? (0 - 1): ");
                            if (mySettings[step] == false)
                                userCommand = AskForInput();
                            else if (mySettings[step] == true)
                            {
                                userCommand = loadedValues[step].ToString();
                                Console.WriteLine(userCommand);
                            }
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
                    }
                    ret = false;
                    step++;
                    {
                        do
                        {
                            string userCommand = "haha";
                            Console.Write("Animaux? (0 - 1): ");
                            if (mySettings[step] == false)
                                userCommand = AskForInput();
                            else if (mySettings[step] == true)
                            {
                                userCommand = loadedValues[step].ToString();
                                Console.WriteLine(userCommand);
                            }
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
                    }
                    ret = false;
                    step++;
                    {
                        do
                        {
                            string userCommand = "haha";
                            Console.Write("Hardcore? (0 - 1): ");
                            if (mySettings[step] == false)
                                userCommand = AskForInput();
                            else if (mySettings[step] == true)
                            {
                                userCommand = loadedValues[step].ToString();
                                Console.WriteLine(userCommand);
                            }
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
                    }
                    ret = false;
                    step++;
                    {
                        do
                        {
                            string userCommand = "haha";
                            Console.Write("Cracké? (0 - 1): ");
                            if (mySettings[step] == false)
                                userCommand = AskForInput();
                            else if (mySettings[step] == true)
                            {
                                userCommand = loadedValues[step].ToString();
                                Console.WriteLine(userCommand);
                            }
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
                    }
                    ret = false;
                    step++;
                    {
                        do
                        {
                            string userCommand = "haha";
                            Console.Write("PVP? (0 - 1): ");
                            if (mySettings[step] == false)
                                userCommand = AskForInput();
                            else if (mySettings[step] == true)
                            {
                                userCommand = loadedValues[step].ToString();
                                Console.WriteLine(userCommand);
                            }
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
                    }
                    ret = false;
                    step++;
                    {
                        do
                        {
                            string userCommand = "haha";
                            Console.Write("Difficultée? (0 = peaceful, 1 = easy, 2 = normal, 3 = hard.): ");
                            if (mySettings[step] == false)
                                userCommand = AskForInput();
                            else if (mySettings[step] == true)
                            {
                                userCommand = loadedValues[step].ToString();
                                Console.WriteLine(userCommand);
                            }
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
                    }
                    ret = false;
                    step++;
                    {
                        do
                        {
                            string userCommand = "haha";
                            Console.Write("Mode de jeu? (0 = survie, 1 = creative, 2 = aventure): ");
                            if (mySettings[step] == false)
                                userCommand = AskForInput();
                            else if (mySettings[step] == true)
                            {
                                userCommand = loadedValues[step].ToString();
                                Console.WriteLine(userCommand);
                            }
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
                    }
                    ret = false;
                    step++;
                    {
                        do
                        {
                            string userCommand = "haha";
                            Console.Write("Nombre de joueurs max?: ");
                            if (mySettings[step] == false)
                                userCommand = AskForInput();
                            else if (mySettings[step] == true)
                            {
                                userCommand = loadedValues[step].ToString();
                                Console.WriteLine(userCommand);
                            }
                            if (DoIsNumber(userCommand) == true)
                            {
                                tw.WriteLine("max-players=" + userCommand);
                                ret = true;
                            }

                        } while (!ret);
                    }
                    ret = false;
                    step++;
                    {
                        do
                        {
                            string userCommand = "haha";
                            Console.Write("Monstres? (0 - 1): ");
                            if (mySettings[step] == false)
                                userCommand = AskForInput();
                            else if (mySettings[step] == true)
                            {
                                userCommand = loadedValues[step].ToString();
                                Console.WriteLine(userCommand);
                            }
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
                    }
                    ret = false;
                    step++;
                    {
                        do
                        {
                            string userCommand = "haha";
                            Console.Write("Distance de vision? (d pour distance par défaut): ");
                            if (mySettings[step] == false)
                                userCommand = AskForInput();
                            else if (mySettings[step] == true)
                            {
                                userCommand = loadedValues[step].ToString();
                                Console.WriteLine(userCommand);
                            }
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
                    }
                    ret = false;
                    step++;
                    {
                        do
                        {
                            string userCommand = "haha";
                            Console.Write("Générer les structures? (0 - 1): ");
                            if (mySettings[step] == false)
                                userCommand = AskForInput();
                            else if (mySettings[step] == true)
                            {
                                userCommand = loadedValues[step].ToString();
                                Console.WriteLine(userCommand);
                            }
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
                    }
                    ret = false;
                    step++;
                    {
                        do
                        {
                            string userCommand = "haha";
                            Console.Write("Message du jour?: ");
                            if (mySettings[step] == false)
                                userCommand = AskForInput();
                            else if (mySettings[step] == true)
                            {
                                userCommand = loadedValues[step].ToString();
                                Console.WriteLine(userCommand);
                            }
                            tw.WriteLine("motd=" + userCommand);
                            ret = true;
                        } while (!ret);
                    }
                    tw.Close();
                    ret = false;
                    step++;
                    {
                        do
                        {
                            string userCommand = "haha";
                            Console.Write("Changer la liste des administrateurs (OP) du serveur? (0 - 1): ");
                            if (mySettings[step] == false)
                                userCommand = AskForInput();
                            else if (mySettings[step] == true)
                            {
                                userCommand = loadedValues[step].ToString();
                                Console.WriteLine(userCommand);
                            }
                            if (userCommand == "1")
                            {
                                DoChangeAdmin();
                                ret = true;
                            }
                            if (userCommand == "0")
                                ret = true;

                        } while (!ret);
                    }
                    ret = false;
                    step++;
                    {
                        do
                        {
                            string userCommand = "haha";
                            Console.Write("Utiliser Java 32 ou 64 bit? (0 = 32, 1 = 64, d = défaut): ");
                            if (mySettings[step] == false)
                                userCommand = AskForInput();
                            else if (mySettings[step] == true)
                            {
                                userCommand = loadedValues[step].ToString();
                                Console.WriteLine(userCommand);
                            }
                            if (userCommand == "0" || userCommand == "d")
                            {
                                LaunchServer32(workingDir);
                                ret = true;
                            }
                            else if (userCommand == "1")
                            {
                                bool ret1 = false;
                                step = step++;
                                do
                                {
                                    Console.Write("Java Heap Size? (en GB): ");
                                    if (mySettings[step] == false)
                                        userCommand = AskForInput();
                                    else if (mySettings[step] == true)
                                    {
                                        userCommand = loadedValues[step].ToString();
                                        Console.WriteLine(userCommand);
                                    }
                                    if (DoIsNumber(userCommand))
                                        ret1 = true;
                                } while (!ret1);
                                LaunchServer64(workingDir, userCommand);
                                ret = true;
                            }
                        } while (!ret);
                    }
                    exit = true;
                }
                while (!exit);
            }
        }

        public static string[] DoLoadPreset()
        {
            string path = Directory.GetCurrentDirectory();
            string[] filePaths = Directory.GetFiles(path +@"\presets");
            Console.WriteLine("Liste des presets sauvegardés:");
            foreach (string Paths in filePaths)
            {
                int pathLength = path.Length + @"\presets".Length + 1;
                Console.WriteLine(Paths.Substring(pathLength));
            }
            Console.Write("Quel fichier loader dans cette liste?: ");
            string userCommand = AskForInput();
            string[] lines = File.ReadAllLines(path + "\\presets\\" + @userCommand);
            return lines;
        }

        private static void DoCreatePreset(bool[] mySettings, string[] configQuestions)
        {
            bool ret = false;
            bool getValue = false;
            string path = Directory.GetCurrentDirectory();
            Console.Write("Nom du preset?: ");
            string fileName = AskForInput();
            FileInfo file = new FileInfo(path + "\\presets\\" + fileName);
            file.Directory.Create();
            TextWriter tw = new StreamWriter(path + "\\presets\\" + fileName);
            for (int i = 0; i < 22; i++)
            {
                string[] configSettings = { "Nether?: ", "Nom du Monde?: ", "Pouvoir voler?: ", "Port du serveur?: ", "Type de monde?: ", "Seed de la map?: ", "NPCs?: ", "Whitelist?: ", "Animaux?: ", "Hardcore?: ", "Cracké?: ", "PVP?: ", "Difficultée?: ", "Mode de jeu?: ", "Nombre de joueurs max?: ", "Monstres?: ", "Distance de vision?: ", "Générer les structures?: ", "Message du jour?: ", "Changer la liste des administrateurs (OP) du serveur?: ", "Utiliser Java 32 ou 64 bit?: ", "Java Heap Size?: " };


                do
                {
                    Console.Write("Utiliser " + configSettings[i]);
                    string userCommand = AskForInput();
                    if (userCommand == "0")
                    {
                        mySettings[i] = false;
                        tw.WriteLine(mySettings[i]);
                        ret = true;
                        getValue = false;
                    }
                    else if (userCommand == "1")
                    {
                        mySettings[i] = true;
                        tw.WriteLine(mySettings[i]);
                        ret = true;
                        getValue = true;
                    }
                } while (!ret);
                if (getValue == true)
                {
                    do
                    {
                        Console.Write("Valeur: " + configQuestions[i]);
                        string userCommand = AskForInput();
                        tw.WriteLine(userCommand);
                        /*
                         * Utiliser la définition des question types dans le static void Main()
                         * pour déterminer quelle "do loop" à faire selon le type de question
                         * posée.
                         * ... ret = false seulement si la personne à entrée une bonne valeur!
                         * 
                         * facul.: réécrire les questions posées en Main() pour avoir un programme
                         * plus petit!
                         */
                        ret = false;
                    } while (ret);
                }
                else if (getValue == false)
                    tw.WriteLine();
            }
            tw.Close();
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
                FileInfo file = new FileInfo(inputText);
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
                        DirectoryInfo file = new DirectoryInfo(input);
                        file.Create();
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
            DirectoryInfo file = new DirectoryInfo(inputText);
            file.Create();

            TextWriter saveData = new StreamWriter("saved.txt");
            saveData.WriteLine(file);

            saveData.Close();
            return file.ToString();
        }
        private static void DoTitle()
        {
            Console.Clear();
            string mainTitle = "Minecraft Server Utility";
            Console.Title = ":" + mainTitle+ ":" + " by qwertyuu";
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