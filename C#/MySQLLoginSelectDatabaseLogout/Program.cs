using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data;
using MySql.Data.MySqlClient;
namespace MySQLLoginSelectDatabaseLogout
{
    class Program
    {
        static void Main(string[] args)
        {
            string server = "";
            if (args.Length >= 1)
                server = args[0];
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Please enter the host address of the MySQL server: ");
                server = Console.ReadLine();
            }
            string user = "";
            if (args.Length >= 2)
                user = args[1];
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Please enter a user name to use: ");
                user = Console.ReadLine();
            }
            string password = "";
            if (args.Length >= 3)
                password = args[2];
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Please enter password to use: ");
                password = Console.ReadLine();
            }
            string database = "";
            if (args.Length >= 4)
                database = args[3];
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Please enter database name: ");
                database = Console.ReadLine();
            }
            string port = "";
            if (args.Length >= 5)
                port = args[4];
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Please enter MySQL server port number: ");
                port = Console.ReadLine();
            }

            while (!ConnectrionInfo(ref server, ref user, ref password, ref database, ref port))
            {

            }

            Console.WriteLine("");
            Console.WriteLine("");
            string connStr = "server=" + server + ";user=" + user + ";database=" + database + ";port=" + port + ";password=" + password + ";";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                Console.WriteLine("Connection established");
                Console.WriteLine("");
                Console.WriteLine("Do you want to run an SQL query (Y, N) [N]:");
                if (Console.ReadLine().ToLower() == "y")
                {
                    Console.WriteLine("");
                    Console.WriteLine("Enter your query:");
                    string query = Console.ReadLine();
                    if (!string.IsNullOrEmpty(query) && !string.IsNullOrWhiteSpace(query))
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Initializing command...");
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        Console.WriteLine("Executing command...");
                        MySqlDataReader rdr = cmd.ExecuteReader();
                        Console.WriteLine("Reading result, printing the first to columns of each row");
                        while (rdr.Read())
                        {
                            Console.WriteLine(rdr[0] + " -- " + rdr[1]);
                        }
                        Console.WriteLine("Execution done");
                        rdr.Close();
                    }
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
            conn.Close();
            Console.WriteLine("");
            Console.WriteLine("DONE.. hit any key to exit");
            Console.ReadKey();
        }

        static bool ConnectrionInfo(ref string server, ref string user, ref string password, ref string database, ref string port)
        {
            Console.WriteLine("");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("- Connecting to MySQL with the following info -");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Server: " + server);
            Console.WriteLine("User name: " + user);
            Console.WriteLine("Password: " + password);
            Console.WriteLine("Database: " + database);
            Console.WriteLine("Port: " + port);
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Do you want to change the connection info? (Y, N) [N]:");
            if (Console.ReadLine().ToLower() == "y")
            {
                Console.Clear();
                Console.WriteLine("");
                string old_server = server;
                Console.WriteLine("Server [" + old_server + "]: ");
                server = Console.ReadLine();
                if (string.IsNullOrEmpty(server) || string.IsNullOrWhiteSpace(server))
                    server = old_server;

                Console.WriteLine("");
                string old_user = user;
                Console.WriteLine("User [" + old_user + "]: ");
                user = Console.ReadLine();
                if (string.IsNullOrEmpty(user) || string.IsNullOrWhiteSpace(user))
                    user = old_user;

                Console.WriteLine("");
                string old_password = password;
                Console.WriteLine("Password [" + old_password + "]: ");
                password = Console.ReadLine();
                if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
                    password = old_password;

                Console.WriteLine("");
                string old_database = database;
                Console.WriteLine("Database [" + old_database + "]: ");
                database = Console.ReadLine();
                if (string.IsNullOrEmpty(database) || string.IsNullOrWhiteSpace(database))
                    database = old_database;

                Console.WriteLine("");
                string old_port = port;
                Console.WriteLine("Port [" + old_port + "]: ");
                port = Console.ReadLine();
                if (string.IsNullOrEmpty(port) || string.IsNullOrWhiteSpace(port))
                    port = old_port;



                return false;
            }
            return true;
        }
    }
}
