using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace ProjectBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            AddEvent(this);
            System.Threading.Thread a = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(lol));
            a.IsBackground = true;
            a.Start();
        }

        private void lol(object obj)
        {
            kk12 = Directory.GetFiles(@"C:\Users\Paul\Documents\Visual Studio 2012\Projects", "*.exe", SearchOption.AllDirectories);
            kk10 = Directory.GetFiles(@"C:\Users\Paul\Documents\Visual Studio 2010\Projects", "*.exe", SearchOption.AllDirectories);

            lst2010D = new List<string>[2];
            lst2010R = new List<string>[2];
            lst2012D = new List<string>[2];
            lst2012R = new List<string>[2];

            lst2010D[0] = Trimmer(kk10.ToList(), true);
            lst2010R[0] = Trimmer(kk10.ToList(), false);
            lst2012D[0] = Trimmer(kk12.ToList(), true);
            lst2012R[0] = Trimmer(kk12.ToList(), false);

            lst2010D[1] = TrimmerToDisplay(lst2010D[0]);
            lst2010R[1] = TrimmerToDisplay(lst2010R[0]);
            lst2012D[1] = TrimmerToDisplay(lst2012D[0]);
            lst2012R[1] = TrimmerToDisplay(lst2012R[0]);

            foreach (var s in lst2010D[1])
            {
                what = 1;
                addThis = s;
                debug2010.Invoke(new MethodInvoker(addD2010));
            }
            foreach (var s in lst2010R[1])
            {
                what = 2;
                addThis = s;
                debug2010.Invoke(new MethodInvoker(addD2010));
            }
            foreach (var s in lst2012D[1])
            {
                what = 3;
                addThis = s;
                debug2010.Invoke(new MethodInvoker(addD2010));
            }
            foreach (var s in lst2012R[1])
            {
                what = 4;
                addThis = s;
                debug2010.Invoke(new MethodInvoker(addD2010));
            }

        }
        private string addThis = "";
        private int what = 0;
        private void addD2010()
        {
            switch (what)
            {
                case 1:
                    debug2010.Items.Add(addThis);
                    break;
                case 2:
                    release2010.Items.Add(addThis);
                    break;
                case 3:
                    debug2012.Items.Add(addThis);
                    break;
                case 4:
                    release2012.Items.Add(addThis);
                    break;
                default:
                    break;
            }
        }

        void c_DoubleClick(object sender, EventArgs e)
        {
            if (((ListBox)sender).SelectedItem != null && ((ListBox)sender).SelectedIndex.ToString().Length != 0)
            {
                int i = ((ListBox)sender).SelectedIndex;
                switch (((ListBox)sender).Name)
                {
                    case "debug2010":
                        Process.Start(System.IO.Path.Combine(@"C:\Users\Paul\Documents\Visual Studio 2010\Projects", lst2010D[0][i])).Close();
                        break;
                    case "debug2012":
                        Process.Start(System.IO.Path.Combine(@"C:\Users\Paul\Documents\Visual Studio 2012\Projects", lst2012D[0][i])).Close();
                        break;
                    case "release2010":
                        Process.Start(System.IO.Path.Combine(@"C:\Users\Paul\Documents\Visual Studio 2010\Projects", lst2010R[0][i])).Close();
                        break;
                    case "release2012":
                        Process.Start(System.IO.Path.Combine(@"C:\Users\Paul\Documents\Visual Studio 2012\Projects", lst2012R[0][i])).Close();
                        break;
                    default:
                        break;
                }
            }
        }
        private void AddEvent(Control parentCtrl)
        {
            foreach (Control c in parentCtrl.Controls)
            {
                if (c is ListBox)
                {
                    c.DoubleClick += c_DoubleClick;
                }
                AddEvent(c);
            }
        }

        List<string>[] lst2010D;
        List<string>[] lst2010R;
        List<string>[] lst2012D;
        List<string>[] lst2012R;
        string[] kk12;
        string[] kk10;
        static List<string> Trimmer(List<string> _lst, bool debug)
        {
            if (debug == true)
            {
                for (int i = 0; i < _lst.Count; i++)
                {
                    if (_lst[i].IndexOf("obj") != -1 || _lst[i].IndexOf("vshost") != -1 || _lst[i].IndexOf("release", StringComparison.OrdinalIgnoreCase) != -1)
                    {
                        _lst.RemoveAt(i);
                        i--;
                    }
                }
            }
            else if(debug == false)
            {
                for (int i = 0; i < _lst.Count; i++)
                {
                    if (_lst[i].IndexOf("obj") != -1 || _lst[i].IndexOf("vshost") != -1 || _lst[i].IndexOf("debug", StringComparison.OrdinalIgnoreCase) != -1)
                    {
                        _lst.RemoveAt(i);
                        i--;
                    }
                }
            }
            return _lst;
        }

        public List<string> TrimmerToDisplay(List<string> _lst)
        {
            int subMax = 0;
            List<string> a = new List<string>();
            List<string> buf = _lst;
            for (int i = 0; i < buf.Count; i++)
            {
                buf[i] = buf[i].Substring(52);
                subMax = buf[i].IndexOf(System.IO.Path.DirectorySeparatorChar);
                a.Add(buf[i].Substring(0, subMax));
            }
            return a;
        }
    }
}