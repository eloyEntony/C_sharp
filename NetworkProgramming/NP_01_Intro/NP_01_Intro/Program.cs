using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net; //ipaddress///
using System.Net.Sockets;

namespace NP_01_Intro
{
    class Program
    {
        static void Main(string[] args)
        {
            // TCP/IP
            // OSI

            //client-server app

            string hostName = Dns.GetHostName();
            Console.WriteLine(hostName);

            Print(hostName); //127.0.0.1 - localhost
        }

        private static void Print(string hostName)
        {
            var ip = Dns.GetHostEntry(hostName);
            Console.WriteLine("Host name : " + ip.HostName);
            Console.WriteLine("Addresses : ");
            foreach (var item in ip.AddressList)
            {
                Console.WriteLine("\t" + item);
            }

            Console.WriteLine();

            Console.WriteLine("Aliasses : ");
            foreach (var item in ip.Aliases)
            {
                Console.WriteLine("\t" + item);
            }

            Console.WriteLine();
        }
    }
}
