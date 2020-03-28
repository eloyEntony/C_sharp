using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.Classwork.Tasks
{
    class MyList<T>
    {
        List<T> myList = new List<T>();
        
        public void Add(T tmp)
        {
            myList.Add(tmp);
        }

        public void Show_list()
        {
            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
        }

        public void Sort()
        {
            myList.Sort();
            //var len = myList.Length;
            //for (var i = 1; i < len; i++)
            //{
            //    for (var j = 0; j < len - i; j++)
            //    {
            //        if (myList[j] > myList[j + 1])
            //        {
            //            Swap(ref array[j], ref array[j + 1]);
            //        }
            //    }
            //}

            //return array;
        }
    }
}
