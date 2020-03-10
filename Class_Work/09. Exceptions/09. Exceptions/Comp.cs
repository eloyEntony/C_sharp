using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Exceptions
{
    class Comp
    {
        int countDisk { get; set; }
        int countPrintDevice { get; set; } = 0;
        Disk[] disks;
        IPrintInformation[] printDevice;

        public Comp(int d, int pd)
        {
            this.countDisk = d;
            this.countPrintDevice = pd;
        }
        public void AddDevice(int index, IPrintInformation si)
        {
            if (index <= countPrintDevice)
            {
                printDevice[index] = si;
            }           
            else
                Console.WriteLine("Bad index");
        }
        public void AddDisk(int index, Disk d)
        {
            if(index <= countDisk)
            {
                disks[index] = d;
            }
            else
                Console.WriteLine("Bad index");
        }

        public bool CheckDisk(string device)
        {
            if (device == "Monitor" || device == "Printer")
            {
                return true;
            }
            else
                return false;
                
        }       

        public void InsertReject(string device, bool b)
        {

        }

        public bool PrintInfo(string text, string device)
        {
            return true;
        }

        public string ReadInfo(string device)
        {
            return " ";
        }

        public void ShowDisk()
        {
            foreach (var item in disks)
            {
                Console.WriteLine("Bob");
            }
        }

        public void ShowPrintDevice()
        {
            foreach (var item in printDevice)
            {
                Console.WriteLine("Bill");
            }
        }

        public bool WriteInfo(string text, string showDevice)
        {
            return true;
        }
    }
}
