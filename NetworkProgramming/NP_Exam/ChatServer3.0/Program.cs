using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatServer3._0
{
    class Program
    {
        static ChatServer server;
        static Thread thread;
        static void Main(string[] args)
        {
            try
            {
                server = new ChatServer();
                thread = new Thread(new ThreadStart(server.Listen));
                thread.Start();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            
        }
    }
}
