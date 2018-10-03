using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ASM_FORM_SERVER.Server;

namespace ASM_FORM_SERVER
{
    static class Program
    {
        private const Int32 DEFAULT_PORT = 9900, DEFAULT_NUM_CONNECTIONS = 10, DEFAULT_BUFFER_SIZE = Int16.MaxValue;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        // [STAThread]
        static void Main()
        {
            
            Thread server = new Thread(StartServer)
            {
                IsBackground = true
            };
            server.Start();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

        }

        static void StartServer()
        {
            try
            {

                SocketListener sl = new SocketListener(DEFAULT_NUM_CONNECTIONS, DEFAULT_BUFFER_SIZE);
                sl.Start(DEFAULT_PORT);

                Console.WriteLine("Server listening on port {0}. Press any key to terminate the server process...", DEFAULT_PORT);
                //Console.Read();

                //sl.Stop();

            }
            catch (IndexOutOfRangeException)
            {
                PrintUsage();
            }
            catch (FormatException)
            {
                PrintUsage();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private static void PrintUsage()
        {
            Console.WriteLine("Usage: ASM_FORM_SERVER <port> [numConnections] [bufferSize].");
            Console.WriteLine("\t<port> Numeric value for the listening TCP port.");
            Console.WriteLine("\t[numConnections] Numeric value for the maximum number of incoming connections.");
            Console.WriteLine("\t[bufferSize] Numeric value for the buffer size of incoming connections.");
        }
    }
}
