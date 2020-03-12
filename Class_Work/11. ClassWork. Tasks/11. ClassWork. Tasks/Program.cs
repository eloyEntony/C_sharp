using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*1. За допомогю мехінізмів наслідування та поліморфізму реалізувати
ієрархію наслідування наступних “створінь”:
a) Створіння - абстрактний базовий клас
b) Тварина - клас який реалізовує базовий функціонал, та дозволяє
перевизначити свої методи класам-нащадкам за допомогою
віртуальних методів
c) Класи Рептилія, Савець, Пташка, Риба - класи нащадки, що
реалізують повну функціональність вказаного типу тварини
d) Класи Ведмідь, Жаба, Дельфін, Карп, Орел - класи нащадки,
остаточні в дереві наслідування
e) Інтерфейси Літаючий, Бігаючий, Плаваюйчий, Повзаючий -
розширюють функціональність тварин, наділяючи їх певними
здатностями

    2. Створити “зоопарк” куди помістити не менше одного екземпляру
кожного з дочірніх класів
 
     */

namespace _11.ClassWork.Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var leo = new Leopard();
            //leo.Live();
            //leo.Run();
            //leo.Voise();

            var croc = new Crocodile();
            //croc.Live();
            //croc.Crawling();
            //croc.Voise();


            var orel = new Eagle();
            //orel.Live();
            //orel.Fly();
            //orel.Voise();

            var carp = new Carp();
            //carp.Live();
            //carp.Float();
            //carp.Voise();

            List<Enimal> myzoo = new List<Enimal>();

            myzoo.Add(leo);
            myzoo.Add(croc);
            myzoo.Add(orel);
            myzoo.Add(carp);

            foreach (var item in myzoo)
            {
                item.Voise();
            }

        }
    }
}
