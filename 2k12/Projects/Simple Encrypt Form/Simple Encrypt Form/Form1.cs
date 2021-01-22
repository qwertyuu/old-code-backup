using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Simple_Encrypt_Form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Activated += Form1_Activated;
            textBox1.Focus();
            autoEncrypt = checkBox1.Checked;
            button1.Enabled = !checkBox1.Checked;
        }
        string oldEncrypt;
        string oldDecrypt;
        bool autoEncrypt = false;
        void Form1_Activated(object sender, EventArgs e)
        {
            string newEncrypt = Clipboard.GetText();
            if (Clipboard.GetText() != null)
            {
                if (Clipboard.GetText().Substring(0, 1) == ">" && oldDecrypt != newEncrypt && oldEncrypt != newEncrypt)
                {
                    textBox3.Text = Decrypt(Clipboard.GetText());
                    oldDecrypt = textBox2.Text;
                    textBox2.Text = Clipboard.GetText();
                    encryptLabel.Text = "decrypted into:";
                }
                else
                {
                    encryptLabel.Text = "Nothing to decrypt.";
                    textBox1.Text = string.Empty;
                    textBox2.Text = string.Empty;
                    textBox3.Text = string.Empty;
                }
            }
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Substring(0, 1) == ">")
            {
                textBox3.Text = Decrypt(textBox1.Text);
                oldDecrypt = textBox3.Text;
                textBox2.Text = textBox1.Text;
                encryptLabel.Text = "decrypted into:";
                textBox1.Text = string.Empty;
            }
            else
            {
                string encryptedText = Encrypt(textBox1.Text);
                Clipboard.SetText(encryptedText);
                encryptLabel.Text = "encrypted into:";
                textBox2.Text = textBox1.Text;
                textBox3.Text = encryptedText;
                oldEncrypt = textBox3.Text;
                textBox1.Text = string.Empty;
            }
        }

        private string Encrypt(string toDecrypt)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append('>');
            char[] currentChars = toDecrypt.ToCharArray();
            int offsetOffset = 3;
            foreach (char toOffset in currentChars)
            {
                stringBuilder.Append((char)(toOffset - offsetOffset));
                if (offsetOffset > 10)
                {
                    offsetOffset = 1;
                }
                offsetOffset++;
            }
            return stringBuilder.ToString();
        }

        private string Decrypt(string toDecrypt)
        {
            toDecrypt = toDecrypt.Substring(1);
            StringBuilder stringBuilder = new StringBuilder();
            char[] currentChars = toDecrypt.ToCharArray();
            int offsetOffset = 3;
            foreach (char toOffset in currentChars)
            {
                stringBuilder.Append((char)(toOffset + offsetOffset));
                if (offsetOffset > 10)
                {
                    offsetOffset = 1;
                }
                offsetOffset++;
            }
            return stringBuilder.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (autoEncrypt)
            {
                string encryptedText = Encrypt(textBox1.Text);
                Clipboard.SetText(encryptedText);
                encryptLabel.Text = "encrypted into:";
                textBox2.Text = textBox1.Text;
                textBox3.Text = encryptedText;
                oldEncrypt = textBox3.Text;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Focus();
            autoEncrypt = checkBox1.Checked;
            button1.Enabled = !checkBox1.Checked;
        }
    }
}
