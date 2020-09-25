using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//Создайте приложение, использующее механизм событий. Создайте в коде приложения несколько потоков.
//Первый поток генерирует 1000 чисел в диапазоне от 0 до
//5000. Три потока ожидают, когда генерирование будет
//завершено. Когда все числа сгенерированы, три потока
//стартуют процесс анализа полученных данных. Первый
//поток находит максимум среди чисел. Второй поток находит минимум. Третий поток высчитывает среднее
//арифметическое. 


namespace RandomProgram_0_5000
{
    class RandomList
    {
        public AutoResetEvent resetEvent = new AutoResetEvent(false);
        Thread thread = null;
        public List<int> list = new List<int>();
        public RandomList(AutoResetEvent ev)
        {
            thread = new Thread(Rando);
            resetEvent = ev;
            thread.Start();
        }

        private void Rando()
        {
            int tmp;
            Random random = new Random();
            for (int i = 0; i < 1000; i++)
            {
                tmp = random.Next(0, 5000);
                list.Add(tmp);
            }
            resetEvent.Set();
        }
        public void Print()
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(Max);
            Thread t2 = new Thread(Min);
            Thread t3 = new Thread(Avg);

            AutoResetEvent resetEvent = new AutoResetEvent(false);
            RandomList randomList = new RandomList(resetEvent);
            resetEvent.WaitOne();

            randomList.Print();

            t1.Start(randomList);

            t2.Start(randomList);
            t3.Start(randomList);


        }

        static void Max(object x)
        {
            Console.WriteLine(" MAX " + (x as RandomList).list.Max());
            //(x as RandomList).resetEvent.Set();
        }

        static void Min(object x)
        {
            Console.WriteLine(" MIN " + (x as RandomList).list.Min());
            //(x as RandomList).resetEvent.Set();
        }

        static void Avg(object x)
        {
            Console.WriteLine(" AVG " + (x as RandomList).list.Average());
            //(x as RandomList).resetEvent.Set();
        }
    }
}
