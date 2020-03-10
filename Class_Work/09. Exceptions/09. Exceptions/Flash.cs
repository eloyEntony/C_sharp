using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Exceptions
{
    class Flash : Disk, IRemoveableDisk
    {
        public bool HasDisk => throw new NotImplementedException();
        private bool hasDisk { get; set; }
        public void Insert()
        {
            throw new NotImplementedException();
        }

        public void Reject()
        {
            throw new NotImplementedException();
        }

        string GetName()
        {
            return this.GetName();
        }
    }
}
