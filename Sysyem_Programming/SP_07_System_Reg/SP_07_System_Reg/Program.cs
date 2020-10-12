using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_07_System_Reg
{
    class Program
    {
        static void Main(string[] args)
        {
            //Registry
            //RegistryKey

            RegistryKey key = Registry.CurrentUser;
            //PrintKey(key);


            //RegistryKey key1 = key.CreateSubKey("NewKEY");
            //key1.Close();


            //key1 = key.OpenSubKey("NewKEY", true);
            //var subkey = key1.CreateSubKey("Config");

            //subkey.SetValue("login", "admin");
            //subkey.SetValue("password", 1234);

            //key1.SetValue("Some value", "hello");

            //key1.Close();

            ////////////////
            RegistryKey run = key.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);

            var items = run.GetValueNames();
            foreach (var item in items)
            {
                if (item.Equals("Mikogo"))
                {
                    run.DeleteValue(item);
                    continue;
                }
                Console.WriteLine($"{item,-30}{run.GetValueKind(item),-15}{run.GetValue(item),-25} ");
            }
           
        }

        private static void PrintKey(RegistryKey key)
        {
            string[] names = key.GetSubKeyNames();
            Console.WriteLine(key.Name);
            foreach (var item in names)
            {
                Console.WriteLine(item);
            }
        }
    }
}
