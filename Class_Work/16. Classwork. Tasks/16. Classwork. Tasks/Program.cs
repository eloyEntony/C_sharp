using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Створити узагальнюючий клас, який містить список елементів (List< T >) та реалізує роботу з ним, включаючи сортування.
 * Клас описати за допомогою узагальнюючих алгоритмів Generics.
 * Сортування реалізувати довільним методом (вибором, бульбашковим тощо).
 
     
    2. метод, який дозволяє підрахувати скільки разів кожне слово зустрічається в заданому тексті.
    Результат записати в колекцію Dictionary<TKey, TValue>.
     */

namespace _16.Classwork.Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            //MyList<string> myList = new MyList<string>();

            //myList.Add("Bob");
            //myList.Show_list();

            Console.WriteLine("Enter any text : ");
            string text = Console.ReadLine();

            Check(text);

        }

        static void Check(string text)
        {
            Dictionary<string, int> openWith = new Dictionary<string, int>();
            string word = "bob";
            int counter = 0;
            while (true)
            {
                int index = text.IndexOf(word);
                if (index == -1)
                    break;
                //Console.WriteLine(index);
                text = text.Substring(index + word.Length);
                counter++;
            };

            openWith.Add(word, counter);            

            foreach (var item in openWith)
            {
                Console.WriteLine(item);
            }
        }

       
    }
}
