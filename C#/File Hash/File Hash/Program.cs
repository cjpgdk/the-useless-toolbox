using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace cmjscripter.net.apps.File_Hash
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 1 && File.Exists(args[0]))
            {
                string filename = args[0];
                string md5value, sha1value, sha256value, sha384value, sha512value = "";

                md5value = MainForm.GetMD5(filename);
                sha1value = MainForm.GetSha1(filename);
                sha256value = MainForm.GetSha256(filename);
                sha384value = MainForm.GetSha384(filename);
                sha512value = MainForm.GetSha512(filename);

                Console.WriteLine("Hash of file: " + filename);
                Console.WriteLine("");
                Console.WriteLine("MD5    : " + md5value);
                Console.WriteLine("SHA1   : " + sha1value);
                Console.WriteLine("SHA256 : " + sha256value);
                Console.WriteLine("SHA384 : " + sha384value);
                Console.WriteLine("SHA512 : " + sha512value);

                Console.WriteLine("");
                Console.WriteLine("Hit any key to exit");
                Console.ReadKey();
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
        }
    }
}
