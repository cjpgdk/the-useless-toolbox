using System;
using System.Net.Sockets;

namespace SimpleTCPConnectDisconnect
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 3 || args.Length < 2)
            {
                Console.WriteLine("I need at least two arguments");
                Console.WriteLine("");
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("TcpTest.exe \"hostname|IP\" PORT [Timeout in seconds]");
                Console.WriteLine("-----------------------------------");

                Console.ReadKey();
                return;
            }
            string hostname = args[0];
            int port = Convert.ToInt32(args[1]);
                double WaitTime = 10;
            if (args.Length > 2)
                WaitTime = Convert.ToDouble(args[2]);
            try
            {
                Console.WriteLine("Create New TCP Connection");
                Console.WriteLine("");
                using (TcpClient tcpClient = new TcpClient())
                {
                    Console.WriteLine("Begin Connect: " + hostname + ":" + port.ToString());
                    Console.WriteLine("");
                    var result = tcpClient.BeginConnect(hostname, port, null, null);
                    Console.WriteLine("Connection awaits for " + WaitTime.ToString() + " seconds..");
                    Console.WriteLine("");
                    var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(WaitTime));
                    if (!success)
                        throw new Exception("Failed to connect.");

                    Console.WriteLine("TCP Connected successfully");
                    Console.WriteLine("");
                    Console.WriteLine("Closing all connections to " + hostname + ":" + port.ToString());
                    Console.WriteLine("");
                    tcpClient.EndConnect(result);
                    tcpClient.GetStream().Close();
                    tcpClient.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("----------  Exception  ------------");
                Console.WriteLine(ex.Message);
                Console.WriteLine("");
                Console.WriteLine("-----------------------------------");
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("-----------------------------------");
            }

            Console.WriteLine("DONE.. hit any key to exit");
            Console.WriteLine("");
            Console.ReadKey();
        }
    }
}
