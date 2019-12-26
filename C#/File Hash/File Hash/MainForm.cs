using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace cmjscripter.net.apps.File_Hash
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!File.Exists(textBox1.Text))
            {
                textBox2.Text = "File: " + textBox1.Text;
                textBox2.Text += "\r\nNot found";
                return;
            }

            string filename = textBox1.Text;
            string md5value, sha1value, sha256value, sha384value, sha512value = null;




            md5value = GetMD5(filename);
            sha1value = GetSha1(filename);
            sha256value = GetSha256(filename);
            sha384value = GetSha384(filename);
            sha512value = GetSha512(filename);

            textBox2.Text = "\r\nFile  : " + textBox1.Text;
            textBox2.Text += "\r\n\r\n";
            textBox2.Text += "MD5   : " + md5value.ToLower() + "\r\n\r\n";
            textBox2.Text += "SHA1  : " + sha1value.ToLower() + "\r\n\r\n";
            textBox2.Text += "SHA256: " + sha256value.ToLower() + "\r\n\r\n";
            textBox2.Text += "SHA384: " + sha384value.ToLower() + "\r\n\r\n";
            textBox2.Text += "SHA512: " + sha512value.ToLower() + "\r\n\r\n";
            
        }

        internal static string GetMD5(string filename)
        {
            string md5value = "";
            using (MD5 md5 = MD5.Create())
            using (var stream = File.OpenRead(filename))
                md5value = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "");
            return md5value;
        }

        internal static string GetSha1(string filename)
        {
            string sha1value = "";
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            using (BufferedStream bs = new BufferedStream(fs))
            {
                using (SHA1Managed sha1 = new SHA1Managed())
                {
                    byte[] hash = sha1.ComputeHash(bs);
                    StringBuilder formatted = new StringBuilder(2 * hash.Length);
                    foreach (byte b in hash)
                        formatted.AppendFormat("{0:X2}", b);

                    sha1value = formatted.ToString();
                }
            }
            return sha1value;
        }

        internal static string GetSha256(string filename)
        {
            string sha256value = "";
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            using (BufferedStream bs = new BufferedStream(fs))
            {
                using (SHA256Managed sha1 = new SHA256Managed())
                {
                    byte[] hash = sha1.ComputeHash(bs);
                    StringBuilder formatted = new StringBuilder(2 * hash.Length);
                    foreach (byte b in hash)
                        formatted.AppendFormat("{0:X2}", b);

                    sha256value = formatted.ToString();
                }
            }
            return sha256value;
        }


        internal static string GetSha512(string filename)
        {
            string sha512value = "";
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            using (BufferedStream bs = new BufferedStream(fs))
            {
                using (SHA512Managed sha1 = new SHA512Managed())
                {
                    byte[] hash = sha1.ComputeHash(bs);
                    StringBuilder formatted = new StringBuilder(2 * hash.Length);
                    foreach (byte b in hash)
                        formatted.AppendFormat("{0:X2}", b);

                    sha512value = formatted.ToString();
                }
            }
            return sha512value;
        }

        internal static string GetSha384(string filename)
        {
            string sha384value = "";
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            using (BufferedStream bs = new BufferedStream(fs))
            {
                using (SHA384Managed sha1 = new SHA384Managed())
                {
                    byte[] hash = sha1.ComputeHash(bs);
                    StringBuilder formatted = new StringBuilder(2 * hash.Length);
                    foreach (byte b in hash)
                        formatted.AppendFormat("{0:X2}", b);

                    sha384value = formatted.ToString();
                }
            }
            return sha384value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    textBox1.Text = dlg.FileName;
                }
            }
        }
    }
}
