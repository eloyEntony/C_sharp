using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Exceptions
{
    class CD : Disk, IRemoveableDisk
    {
        public bool HasDisk { get; }

        private bool hasDisk { get; set; }

        public void Insert()
        {
           
        }

        public void Reject()
        {
            
        }

        string GetName()
        {
            return this.GetName();
        }

         
    }
}
