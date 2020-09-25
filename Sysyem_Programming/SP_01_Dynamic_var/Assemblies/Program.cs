using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assemblies
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain app = AppDomain.CurrentDomain;
            Console.WriteLine(app.BaseDirectory);
            Console.WriteLine(app.FriendlyName);
            foreach (Assembly item in app.GetAssemblies())
            {
                Console.WriteLine(item.FullName);
                Console.WriteLine(item.Location);               
            }

        }
    }
}
