using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Diagnostics;

namespace MC_Server_utility
{
    public partial class CreateServer : Form
    {
        public CreateServer()
        {
            InitializeComponent();
            this.Width = 345;
            this.Height = 126;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            KillMain = false;
            if (MainMenu.debug == true)
            {
                Go.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
                Go.Enabled = true;
            }
        }
        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }
        AdminForm adminPanel = new AdminForm();
        StartConfig startSettings = new StartConfig();
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
        bool didDownloadAndCopy = false;
        string url;
        string path;
        string fileName;
        string tmpFile;
        private void button2_Click(object sender, EventArgs e)
        {
            StreamReader serverListReader = new StreamReader("Stored Servers.txt");
            string s = serverListReader.ReadToEnd();
            serverListReader.Close();
            string[] lines = s.Split('\n');
            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = lines[i].Replace("\r", string.Empty);                
            }
            bool existingServer = false;
            int index = 0;
            foreach (string str in lines)
            {
                if (folderBrowserDialog1.SelectedPath == str)
                {
                    existingServer = true;
                    break;
                }
                index++;
            }
            if (existingServer == false)
            {
                StreamWriter serverListWriter = new StreamWriter("Stored Servers.txt");
                serverListWriter.WriteLine(folderBrowserDialog1.SelectedPath);
                serverListWriter.Close();
                if (File.Exists(folderBrowserDialog1.SelectedPath + "\\server.properties"))
                {
                    MessageBox.Show("The specified folder already contains a server.properties file\nI will read it and apply the properties to the editor!");
                    lines[0] = folderBrowserDialog1.SelectedPath;
                    LoadAllProps(lines, 0);
                }
                //SEE THIS: http://www.mycsharpcorner.com/Post.aspx?postID=22
            }
            else
            {
                MessageBox.Show("The selected server already exists in the database. Using the old entry.");
                LoadAllProps(lines, index);
            }
            url = "http://s3.amazonaws.com/MinecraftDownload/launcher/minecraft_server.jar";
            path = Path.GetTempPath();
            fileName = Path.GetFileName(url);
            tmpFile = Path.Combine(path, fileName);
                if (File.Exists(folderBrowserDialog1.SelectedPath + "\\minecraft_server.jar"))
                {
                    if (MainMenu.debug == false)
                    {
                        WebClient fileDownloader = new WebClient();
                        fileDownloader.DownloadFile(url, tmpFile);

                        FileStream fs = new FileStream(folderBrowserDialog1.SelectedPath + "\\minecraft_server.jar", FileMode.Open);
                        FileStream fsI = new FileStream(tmpFile, FileMode.Open);
                        StringBuilder byteInternet = new StringBuilder();
                        StringBuilder byteExisting = new StringBuilder();
                        using (MD5 md5Hash = MD5.Create())
                        {
                            var existingFileHash = md5Hash.ComputeHash(fs);
                            foreach (byte _byte in existingFileHash)
                            {
                                byteExisting.Append(_byte);
                            }
                            var internetFileHash = md5Hash.ComputeHash(fsI);
                            foreach (byte _byte in internetFileHash)
                            {
                                byteInternet.Append(_byte);
                            }
                            fs.Close();
                            fsI.Close();
                            if (byteInternet.ToString() != byteExisting.ToString())
                            {
                                DialogResult dialogResult = MessageBox.Show("The version of minecraft_server.jar inside the folder you selected seems to be outdated, would you like to update?", "Would you like to update?", MessageBoxButtons.YesNo);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    File.Copy(tmpFile, folderBrowserDialog1.SelectedPath + "\\minecraft_server.jar", true);
                                }
                            }
                        }
                    }
                }
                else
                {
                    WebClient fileDownloader = new WebClient();
                    fileDownloader.DownloadFile(url, folderBrowserDialog1.SelectedPath + "\\minecraft_server.jar");
                    didDownloadAndCopy = true;
                }
            

            this.Height = 374;
            this.Width = 496;
            SetEverything();
        }

        private void LoadAllProps(string[] lines, int index)
        {
            StreamReader propReader = new StreamReader(lines[index] + "\\server.properties");
            string props = propReader.ReadToEnd();
            propReader.Close();
            string[] propsLines = props.Split('\n');
            for (int i = 0; i < propsLines.Length; i++)
            {
                propsLines[i] = propsLines[i].Replace("\r", string.Empty);
            }
            foreach (string stre in propsLines)
            {
                if (stre.Length > 0)
                {
                    if (stre.Substring(0, 1) != "#")
                    {
                        LoadProps(stre);
                    }
                }
            }
        }

        private void LoadProps(string stre)
        {
            int l = stre.IndexOf('=');
            string toSwitch = stre.Substring(0, l);
            string arg = stre.Substring(l + 1);
            bool argOut = false;
            int index = 0;
            switch (toSwitch)
            {
                case "allow-nether":
                    if (bool.TryParse(arg, out argOut))
                    {
                        checkedListBox1.SetItemChecked(0, argOut);
                    }
                    break;
                case "level-name":
                    textBox2.Text = arg;
                    break;
                case "level-type":
                    if (arg.ToUpper() == "DEFAULT")
                    {
                        comboBox2.SelectedIndex = 0;
                    }
                    else if (arg.ToUpper() == "FLAT")
                    {
                        comboBox2.SelectedIndex = 1;
                    }
                    else if (arg.ToUpper() == "LARGEBIOMES")
                    {
                        comboBox2.SelectedIndex = 2;
                    }
                    break;
                case "level-seed":
                    textBox4.Text = arg;
                    break;
                case"spawn-npcs":
                    if (bool.TryParse(arg, out argOut))
                    {
                        checkedListBox1.SetItemChecked(1, argOut);
                    }
                    break;
                case "spawn-animals":
                    if (bool.TryParse(arg, out argOut))
                    {
                        checkedListBox1.SetItemChecked(3, argOut);
                    }
                    break;
                case "online-mode":
                    if (bool.TryParse(arg, out argOut))
                    {
                        checkedListBox1.SetItemChecked(5, !argOut);
                    }
                    break;
                case "pvp":
                    if (bool.TryParse(arg, out argOut))
                    {
                        checkedListBox1.SetItemChecked(6, argOut);
                    }
                    break;
                case "difficulty":
                    if (int.TryParse(arg, out index))
                    {
                        index--;
                        if (index < 0)
                        {
                            index = 3;
                        }
                        comboBox3.SelectedIndex = index;
                    }
                    break;
                case "gamemode":
                    if (int.TryParse(arg, out index))
                    {
                        comboBox1.SelectedIndex = index;
                    }
                    break;
                case "max-players":
                    if (int.TryParse(arg, out index))
                    {
                        MaxPlayerNum.Value = index;
                    }
                    break;
                case "spawn-monsters":
                    if (bool.TryParse(arg, out argOut))
                    {
                        checkedListBox1.SetItemChecked(7, argOut);
                    }
                    break;
                case "generate-structures":
                    if (bool.TryParse(arg, out argOut))
                    {
                        checkedListBox1.SetItemChecked(8, argOut);
                    }
                    break;
                case "motd":
                    textBox3.Text = arg;
                    break;
                case "white-list":
                    if (bool.TryParse(arg, out argOut))
                    {
                        checkedListBox1.SetItemChecked(2, argOut);
                    }
                    break;
                default:
                    break;
            }
        }

        private void SetEverything()
        {
            Go.Visible = false;
            Cancel.Visible = true;
            Create.Visible = true;
            checkedListBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            label2.Visible = true;
            button1.Enabled = false;
            MaxPlayers.Visible = true;
            Port.Visible = true;
            MaxPlayerNum.Visible = true;
            PortNum.Visible = true;
            CustomPortCheck.Visible = true;
            ServerNameBox.Visible = true;
            ServerName.Visible = true;
            this.CancelButton = Cancel;
            this.ControlBox = false;
            ServerNameBox.Focus();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CustomPortCheck.Checked == true)
            {
                PortNum.Enabled = true;
            }
            else
            {
                PortNum.Enabled = false;
            }
        }

        private void ServerNameBox_TextChanged(object sender, EventArgs e)
        {
            if (ServerNameBox.Text != string.Empty)
            {
                Create.Enabled = true;
            }
            else if (ServerNameBox.Text == string.Empty)
            {
                Create.Enabled = false;
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            if (didDownloadAndCopy == true && File.Exists(folderBrowserDialog1.SelectedPath + "\\minecraft_server.jar"))
            {
                File.Delete(folderBrowserDialog1.SelectedPath + "\\minecraft_server.jar");
            }
        }
        public static bool KillMain { get; set; }
        private void Create_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Yes;
            bool[] lel = new bool[checkedListBox1.Items.Count];
            if (checkedListBox1.CheckedItems.Count != 0)
            {
                for (int i = 0; i <= checkedListBox1.Items.Count - 1; i++)
                {
                    lel[i] = checkedListBox1.GetItemChecked(i);
                }
            }
            Writer.WriteConfigFile(comboBox3.SelectedIndex, textBox4.Text, textBox2.Text, MaxPlayerNum.Value, PortNum.Value, comboBox1.SelectedIndex, textBox3.Text, numericUpDown1.Value, comboBox2.SelectedIndex, lel, folderBrowserDialog1.SelectedPath);
            if (radioButton2.Checked == true)
            {
                if (startSettings.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    maxHeap = startSettings.MaxHeap;
                    minHeap = startSettings.MinHeap;
                    if (startSettings.KindOfStart == true)
                    {
                        StartServer(folderBrowserDialog1.SelectedPath);
                    }
                    else if (startSettings.KindOfStart == false)
                    {
                        StartServer(folderBrowserDialog1.SelectedPath, maxHeap, minHeap);
                    }
                    KillMain = true;
                    this.Close();
                }
            }
        }

        private void StartServer(string p)
        {
            Directory.SetCurrentDirectory(folderBrowserDialog1.SelectedPath + "\\");
            var processInfo = new ProcessStartInfo();
            Process proc;
            processInfo.FileName = "java.exe";
            processInfo.Arguments = "-jar \"" + folderBrowserDialog1.SelectedPath + "\\minecraft_server.jar\"";
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = true;
            proc = Process.Start(processInfo);
        }
        decimal maxHeap = 0;
        decimal minHeap = 0;
        private void StartServer(string p, decimal _maxheap, decimal _minheap)
        {
            Directory.SetCurrentDirectory(folderBrowserDialog1.SelectedPath + "\\");
            var processInfo = new ProcessStartInfo();
            Process proc;
            processInfo.FileName = @"C:\Program Files\Java\jre7\bin\java.exe";
            processInfo.Arguments = "-Xmx" + _minheap + "M -Xms" + _minheap + "M -jar \"" + folderBrowserDialog1.SelectedPath + "\\minecraft_server.jar\"";
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = true;
            proc = Process.Start(processInfo);
        }
        bool hasChecked = true;

        private void button2_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, hasChecked);
            }
            hasChecked = !hasChecked;
        }

        string adminList = "";
        private void button3_Click(object sender, EventArgs e)
        {
            if (adminPanel.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                adminList = adminPanel.WrittenText;
                Writer.WriteOpsFile(adminList, folderBrowserDialog1.SelectedPath);
            }
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.Index == 2)
            {
                button4.Enabled = e.NewValue == CheckState.Checked;
            }
        }
    }
}
