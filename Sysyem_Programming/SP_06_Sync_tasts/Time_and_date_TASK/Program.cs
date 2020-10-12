using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Создайте приложение, использующее класс Task. Приложение должно отображать текущее время и дату. 
//    Запустите задачу три способами:
//■Через метод Start класса Task;
//■Через метод Task.Factory.StartNew;
//■Через метод Task.Run.

namespace Time_and_date_TASK
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t1 = new Task(DateAndTime);
            t1.Start();            

            Task t2 = Task.Factory.StartNew(DateAndTime);

            Task t3 = Task.Run(DateAndTime);

            Console.ReadLine();
        }


        static public void DateAndTime()
        {
            Console.WriteLine($"{DateTime.Now}");
        }
    }
}
