using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SP_03_Treads
{
    class Program
    {
        static void ShowInfo(object state)
        {
            Console.WriteLine("Thread => " + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Thread is Back? " + Thread.CurrentThread.IsBackground.ToString());
            Thread.Sleep(2000);
        }
        static void Main(string[] args)
        {
            //багатопоточність - властивість ос або додатку, що полягає в тому щоб один процес може складатися із багатьох потоків

            Console.WriteLine("main thread => " + Thread.CurrentThread.ManagedThreadId);

            TimerCallback timerCallback = new TimerCallback(ShowInfo);
            //Timer timer = new Timer(timerCallback);
            //timer.Change(1000, 500);

            Timer timer = new Timer(PrintTime, null, 1000, 1000);

            

            //Thread.Sleep(2000);
                        
            Console.WriteLine("main ended");
            Console.ReadLine();






        }

        private static void PrintTime(object state)
        {
            Console.Clear();
            Console.WriteLine(DateTime.Now.ToLongTimeString());
        }
    }
}
