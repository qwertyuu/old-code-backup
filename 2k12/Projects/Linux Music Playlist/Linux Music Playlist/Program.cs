using System;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace Linux_Music_Playlist
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Dir: ");
            string dir = Console.ReadLine();
            string[] filePaths = Directory.GetFiles(dir, "*.mp3", SearchOption.AllDirectories);
            StreamWriter sw = File.AppendText("/home/pi/playlists/playlist000.txt");
            foreach (string s in filePaths)
            {
                sw.WriteLine(s);
            }
            sw.Close();
            StreamWriter sw1 = File.AppendText("/home/pi/Desktop/StartJukebox.sh");
            sw1.WriteLine("mpg123 -C -z --list playlist000.txt");
            sw1.Close();
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "sudo";
            psi.Arguments = "chmod 777 /home/pi/Desktop/StartJukebox.sh";
            Process p = Process.Start(psi);
            Console.WriteLine("Maintenant, lancez \"StartJukebox.sh\" de sur le bureau!");
        }
    }
}