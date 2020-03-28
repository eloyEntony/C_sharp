using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.Index
{
    class Telefon_book
    {
        Telefon[] telefons;
        string Book_title { get; set; }
        string Date_create { get; set; }
        int Free_num = 0;
        public Telefon_book(string name)
        {
            this.Book_title = name;
            this.Date_create = "26.03.2020";

            this.telefons = new Telefon[99];
            for (int i = 0; i < telefons.Length; i++)
            {
                telefons[i] = new Telefon();
            }

        }

        public Telefon this[int index]
        {
            get
            {
                return this.telefons[index];
            }
            set
            {
                this.telefons[index] = value;
            }
        }

        public void Show_telefons()
        {
            int counter = 1;
            int page = 0;
            Console.WriteLine($" Title book : {this.Book_title}");
            for (int i = 0; i < telefons.Length; i++)
            {
                counter++;
                Console.WriteLine($"{i}. Telefon number > {telefons[i].Telefon_number}   Name > {telefons[i].Name}");

                if (counter == 10)
                {
                    counter = 1;
                    page++;
                    Console.WriteLine($"\t\t{page} from 11");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }

        public void Edit_number()
        {
            Console.WriteLine("Enter telefon idex : ");
            int choice = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < telefons.Length; i++)
            {
                if (choice == i)
                {
                    telefons[i].Show_telefon();
                    telefons[i].Edit();
                }
            }

        }

        public void Delete_number()
        {
            Console.WriteLine("Enter telefon idex : ");
            int choice = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < telefons.Length; i++)
            {
                if (choice == i)
                {
                    telefons[i].Delete();
                    Free_num--;
                }
            }
        }

        public void Free_numbers()
        {
            int counter = 0;

            for (int i = 0; i < telefons.Length; i++)
            {
                if (telefons[i].Telefon_number == "..................")
                {
                    counter++;
                }
            }
            Free_num = counter;
            Console.WriteLine($" Free number count : {Free_num}");

        }

        public void Add_number()
        {
            string number = " ";
            string name = " ";
            Console.WriteLine("----ADD NEW NUMBER----");
            Console.WriteLine(" Enter telefon idex : ");
            int choice = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < telefons.Length; i++)
            {
                if (i == choice && telefons[i].Telefon_number == "..................")
                {
                    Console.WriteLine(" Enter NEW telefon : ");
                    number = Console.ReadLine();                    
                    Console.WriteLine(" Enter NEW name    : ");
                    name = Console.ReadLine();

                    telefons[i].Telefon_number = number;
                    telefons[i].Name = name;
                    Free_num++;
                }
            }            
            Console.WriteLine($" Name > {name}   Number > {number} ---- add");
        }


        public void Sherch_felefon()
        {
            bool v = false;
            Console.WriteLine(" Enter number or name to sherch : ");
            string tmp = Console.ReadLine();

            for (int i = 0; i < telefons.Length; i++){
                if(tmp == telefons[i].Name || tmp == telefons[i].Telefon_number){
                    //telefons[i].Show_telefon();
                    v = true;
                }
            }
            if (v == true){
                Console.WriteLine(" <<< Found >>> ");
                for (int i = 0; i < telefons.Length; i++)
                {
                    if (tmp == telefons[i].Name || tmp == telefons[i].Telefon_number)
                    {
                        telefons[i].Show_telefon();
                    }
                }
            }
            else{
                Console.WriteLine(" <<< NOT Found >>> ");
            }            
        }


    }
}
