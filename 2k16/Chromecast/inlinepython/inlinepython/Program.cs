using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inlinepython
{
    class Program
    {
        static void Main(string[] args)
        {
            // Start the child process.
            Process p = new Process();
            // Redirect the output stream of the child process.
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.FileName = "python";
            p.OutputDataReceived += p_OutputDataReceived;
            p.ErrorDataReceived += p_OutputDataReceived;
            p.Start();
            //p.BeginOutputReadLine();
            //p.BeginErrorReadLine();
            // Do not wait for the child process to exit before
            // reading to the end of its redirected stream.
            // p.WaitForExit();
            // Read the output stream first and then wait.
            char[] chars = new char[5];
            int pos = 0;
            p.StandardInput.Flush();
            for (int i = 0; i < 100; i++)
            {
                while (p.StandardOutput.Peek() >= 0)
                {
                    Console.WriteLine(p.StandardOutput.ReadLine());
                }    
                p.StandardInput.WriteLine("a");
            }
            p.StandardInput.Flush();
            p.WaitForExit();
            while (!p.HasExited)
            {
                //Console.WriteLine("A");
                p.StandardInput.Write("a\r\n");
                System.Threading.Thread.Sleep(1000);
            }
        }

        static void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine(e.Data);
            Console.Write("end");
        }
    }
}
