using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Exceptions
{
    class Disk : IDisk
    {
        //string memory;
        //int memSize;

        string Memory { get; set; }
        int MemSize { get; set; }

        public Disk()
        {
                 
        }

        public Disk(string memory, int memSize)
        {
            this.Memory = memory;
            this.MemSize = memSize;
        }

        string GetName()
        {
            return this.Memory;
        }

        public string Read()
        {
            return this.Memory;
        }

        public void Write(string text)
        {

        }



    }
}
