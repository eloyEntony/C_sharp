using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mutex_singelton
{
    class Program
    {
        static Mutex mutex;
        static void Main(string[] args)
        {
            try
            {
                mutex = Mutex.OpenExisting("my_mutex");
            }
            catch(WaitHandleCannotBeOpenedException ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (mutex != null)
            {
                MessageBox.Show("Program has start!!!");
                return;
            }
            else
            {
                mutex = new Mutex(true, "my_mutex");
                Console.WriteLine("hello word");
            }
            Console.ReadLine();
        }
    }
}
