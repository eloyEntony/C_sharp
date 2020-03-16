using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Delegates
{
    class Arr
    {
        int[] A = new int[5];
        //var rand = new Random();

        public delegate void Callback();
        private Callback callback;

        public void Register_on_callback(Callback Callback)
        {
            this.callback = Callback;
        }

        public void Create_array()
        {
            var rand = new Random();

            for(int i=0; i < A.Length; i++)
            {
                A[i] = rand.Next(-5, 5);
            }

        }

        public void Show_array()
        {
            Console.WriteLine("\n--------------------------------- ");
            foreach (var item in A)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("---------------------------------\n ");
        }

        public int Negative_element()
        {
            int negativ_element = 0;

            foreach (var item in A){
                if(item < 0){
                    negativ_element++;
                }
            }

            //Console.WriteLine(" Counter negative element : " + negativ_element);
            return negativ_element;
        }

        public int Sum()
        {
            int sum = 0;
            foreach (var item in A){
                sum += item;
            }
            //Console.WriteLine(" SUM : " + sum);
            return sum;
        }

        public void Negative_0()
        {
            for (int i = 0; i < A.Length; i++){
                if (A[i] < 0)
                    A[i] = 0;
            }
        }

        public void Sort()
        {
            Array.Sort(A);
        }
    }
}
