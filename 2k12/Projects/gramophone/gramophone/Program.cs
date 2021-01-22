using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace gramophone
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                if (CalculateMD5Hash(args[0]) == "6eea9b7ef19179a06954edd0f6c05ceb")
                {

                    while (!File.Exists(Directory.GetCurrentDirectory() + "/gramophones.gr"))
                    {
                        File.Create(Directory.GetCurrentDirectory() + "/gramophones.gr").Close();
                    }
                    Console.WriteLine(Directory.GetCurrentDirectory() + "/gramophones.gr");
                    StreamReader reader = new StreamReader(Directory.GetCurrentDirectory() + "/gramophones.gr");
                    sites = new List<string>();
                    string ligne = null;
                    AES = new SimplerAES(args[0]);
                    int count = 1;
                    while ((ligne = reader.ReadLine()) != null)
                    {
                        sites.Add(AES.Decrypt(ligne));
                        Console.Write(count + " ");
                        Console.WriteLine(AES.Decrypt(ligne));
                        count++;
                    }
                    reader.Close();
                    reader.Dispose();
                    bool exit = false;
                    while (!exit)
                    {
                        exit = Analyze(Console.ReadLine());
                    }
                    StreamWriter saver = new StreamWriter(Directory.GetCurrentDirectory() + "/gramophones.gr");
                    foreach (var item in sites)
                    {
                        saver.WriteLine(AES.Encrypt(item));
                    }
                    saver.Close();
                    saver.Dispose();
                }
            }
        }
        private enum SingleCommands { exit, quit, close, help, list, stop };
        private enum CommandsWithArgs { add, rm };
        private static List<string> sites;
        private static SimplerAES AES;

        private static bool Analyze(string p)
        {
            string[] args = p.Trim().Split(' ');
            if (args.Length == 1)
            {
                SingleCommands a = new SingleCommands();
                if (Enum.TryParse<SingleCommands>(args[0], out a))
                {
                    switch (a)
                    {
                        case SingleCommands.exit:
                            return true;
                        case SingleCommands.quit:
                            return true;
                        case SingleCommands.close:
                            return true;
                        case SingleCommands.stop:
                            return true;
                        case SingleCommands.help:
                            Console.WriteLine(@"add <site> <uname> <pw>
rm <index>");
                            break;
                        case SingleCommands.list:
                            for (int i = 0; i < sites.Count; i++)
                            {
                                Console.WriteLine("{0} {1}", i + 1, sites[i]);
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                CommandsWithArgs a = new CommandsWithArgs();
                if (Enum.TryParse<CommandsWithArgs>(args[0], out a))
                {
                    switch (a)
                    {
                        case CommandsWithArgs.add:
                            if (args.Length == 4)
                            {
                                sites.Add(string.Format("{0} : {1}/{2}", args[1], args[2], args[3]));
                                Console.WriteLine("Added");
                            }
                            else
                            {
                                Console.WriteLine("Needs 3 args lol");
                            }
                            break;
                        case CommandsWithArgs.rm:
                            if (args.Length == 2)
                            {
                                int outcome = -1;
                                if (int.TryParse(args[1], out outcome))
                                {
                                    sites.RemoveAt(outcome - 1);
                                    Console.WriteLine("Removed at: {0}", outcome);
                                }
                            }
                            else
                            {
                                Console.WriteLine("needs 1 arg lol");
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            return false;
        }
        public static string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = MD5.Create();
            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
    public class SimplerAES
    {
        private static byte[] vector = { 146, 64, 191, 111, 23, 3, 113, 119, 231, 121, 221, 112, 79, 32, 114, 156 };
        private ICryptoTransform encryptor, decryptor;
        private UTF8Encoding encoder;

        public SimplerAES(string passw)
        {
            RijndaelManaged rm = new RijndaelManaged();
            encryptor = rm.CreateEncryptor(Encoding.UTF8.GetBytes(passw), vector);
            decryptor = rm.CreateDecryptor(Encoding.UTF8.GetBytes(passw), vector);
            encoder = new UTF8Encoding();
        }

        public string Encrypt(string unencrypted)
        {
            return Convert.ToBase64String(Encrypt(encoder.GetBytes(unencrypted)));
        }

        public string Decrypt(string encrypted)
        {
            return encoder.GetString(Decrypt(Convert.FromBase64String(encrypted)));
        }

        public byte[] Encrypt(byte[] buffer)
        {
            return Transform(buffer, encryptor);
        }

        public byte[] Decrypt(byte[] buffer)
        {
            return Transform(buffer, decryptor);
        }

        protected byte[] Transform(byte[] buffer, ICryptoTransform transform)
        {
            MemoryStream stream = new MemoryStream();
            using (CryptoStream cs = new CryptoStream(stream, transform, CryptoStreamMode.Write))
            {
                cs.Write(buffer, 0, buffer.Length);
            }
            return stream.ToArray();
        }
    }
}
