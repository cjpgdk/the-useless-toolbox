using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Hex2Argb.exe
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 2)
            {
                if (args[0].ToLower() == "hex")
                {
                    System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml(args[1]);
                    Console.WriteLine("Convert hex: " + args[1] + " to ARGB");
                    Console.WriteLine("HEX: " + args[1]);
                    Console.WriteLine("ARGB:"
                        + "\r\n\tA: " + Convert.ToDecimal(c.A)
                        + "\r\n\tR: " + Convert.ToDecimal(c.R)
                        + "\r\n\tG: " + Convert.ToDecimal(c.G)
                        + "\r\n\tB: " + Convert.ToDecimal(c.B)
                        );
                }
                else if (args[0].ToLower() == "argb")
                {
                    string[] argbs = null;
                    if (args[1].Contains(";"))
                        argbs = args[1].Split(';');
                    else if (args[1].Contains(":"))
                        argbs = args[1].Split(':');
                    else if (args[1].Contains(","))
                        argbs = args[1].Split(',');

                    int a, r, g, b = 255;
                    if (argbs.Length == 3)
                    {
                        a = 255;
                        r = Convert.ToInt32(argbs[0]);
                        g = Convert.ToInt32(argbs[1]);
                        b = Convert.ToInt32(argbs[2]);
                    }
                    else if (argbs.Length == 4)
                    {
                        a = Convert.ToInt32(argbs[0]);
                        r = Convert.ToInt32(argbs[1]);
                        g = Convert.ToInt32(argbs[2]);
                        b = Convert.ToInt32(argbs[3]);
                    }
                    else
                    {
                        Console.WriteLine("Invalid argb string need 3 or 4 numberic values");
                        Console.WriteLine("seperated with ;|:|,");
                        Console.WriteLine("EG: 255;255;255;255");
                        Console.ReadKey();
                        return;
                    }


                    Console.WriteLine("Convert ARGB: " + args[1] + " to HEX");
                    Console.WriteLine("ARGB: " + args[1]);
                    Console.WriteLine("HEX:" + string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}",
                         Convert.ToByte(a), Convert.ToByte(r),
                         Convert.ToByte(g), Convert.ToByte(b)));
                }
                else
                {
                    Console.WriteLine("Invalid args..");
                    Console.WriteLine("Usage:");
                    Console.WriteLine("HEX => ARGB: Hex2Argb hex \"#ADFFA2\"");
                    Console.WriteLine("HEX => ARGB: Hex2Argb hex \"#FFADFFA2\"");
                    Console.WriteLine("");
                    Console.WriteLine("ARGB => HEX: Hex2Argb argb \"AAA;RRR;GGG;BBB\"");
                    Console.WriteLine("ARGB => HEX: Hex2Argb argb \"255;255;255;255\"");
                    Console.WriteLine("ARGB => HEX: Hex2Argb argb \"255:255:255:255\"");
                    Console.WriteLine("ARGB => HEX: Hex2Argb argb \"255,255,255,255\"");
                    Console.ReadKey();
                    return;
                }
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
