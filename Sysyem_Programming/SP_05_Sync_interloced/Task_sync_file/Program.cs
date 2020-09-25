using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//Создайте приложение, использующее механизм событий. 
//Создайте в коде приложения несколько потоков.
//Первый поток генерирует и сохраняет в файл некоторое количество пар чисел. 
//Второй поток ожидает завершения генерации, после чего подсчитывает сумму каждой пары. Результат записывается в файл. 
//Третий поток тоже ожидает завершения генерации, после чего подсчитывает произведение каждой пары. Результат записывается в файл. 

namespace Task_sync_file
{
    class Para
    {
        public int x;
        public int y;
    }
    class Program
    {
        static AutoResetEvent resetEvent;
        
        static void Main(string[] args)
        {
            resetEvent = new AutoResetEvent(false);
            List<Para> paras = new List<Para>();

            Thread t1 = new Thread(Rand_save);
            t1.Start(paras);
            resetEvent.WaitOne();

            Thread t2 = new Thread(Sum_save);
            t2.Start(paras);

            Thread t3 = new Thread(Mul_save);
            t3.Start(paras);           

        }
       
        static void Rand_save(object x)
        {
            List<Para> paras = (List<Para>)x;
            Random random = new Random();

            for (int i = 0; i < 5; i++)            
                paras.Add(new Para { x = random.Next(1, 50), y = random.Next(1, 50) });            

            using (StreamWriter sw = new StreamWriter("1.txt"))            
                for (int i = 0; i < paras.Count; i++)                
                    sw.WriteLine($"{paras[i].x} {paras[i].y}"); 

            resetEvent.Set();
        }
        static void Sum_save(object x)
        {
            List<Para> paras = (List<Para>)x;
            List<int> res = new List<int>();

            foreach (var item in paras)
                res.Add(item.x + item.y);
            
            using (StreamWriter sw = new StreamWriter("2.txt"))            
                foreach (var item in res)
                    sw.WriteLine(item);

            resetEvent.Set();
        }

        static void Mul_save(object x)
        {
            List<Para> paras = (List<Para>)x;
            List<int> res = new List<int>();

            foreach (var item in paras)
                res.Add(item.x * item.y);

            using (StreamWriter sw = new StreamWriter("3.txt"))
                foreach (var item in res)
                    sw.WriteLine(item);

            resetEvent.Set();
        }
    }
}
