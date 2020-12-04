using DB.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class DBHelper
    {
        AppContext context = new AppContext();
        public List<Address> GetAddresses()
        {
            return context.Addresses.ToList();
        }
    }
}
