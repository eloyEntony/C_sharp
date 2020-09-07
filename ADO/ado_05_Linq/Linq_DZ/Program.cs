using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Linq_DZ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

            DataClasses1DataContext context = new DataClasses1DataContext(connectionString);
            #region
            ////            1. Вибрати всі книги, кількість сторінок в яких більше 100

            //var res1 = context.GetTable<Books>().Where(x => x.Pages > 100);
            //foreach (var item in res1){   Console.WriteLine(item.Name);}

            ////            2. Вибрати всі книги, ім'я яких починається на літеру 'А' або 'а

            //var res2 = context.GetTable<Books>().Where(x =>x.Name.StartsWith("A") || x.Name.StartsWith("a"));
            //foreach (var item in res2) {   Console.WriteLine(item.Name); }

            ////            3. Вибрати всі книги автора William Shakespeare

            //var res3 = context.GetTable<Books>().Where(x => x.Authors.Name == "R.S.Martin");
            //foreach (var item in res3)     {  Console.WriteLine(item.Name);     }

            ////           4. Вибрати всі книги українських авторів

            //var res4 = context.GetTable<Books>().Where(x => x.Authors.Name == "L. Kostenko");//треба добавити країну автора
            //foreach (var item in res4){    Console.WriteLine(item.Name);}

            ////           5. Вибрати всі книги, ім'я в яких складається менше ніж з 10-ти символів

            //var res5 = context.Books.Where(x =>x.Name.Length < 10);
            //foreach (var item in res5){    Console.WriteLine(item.Name);}

            ////            6. Вибрати книгу з максимальною кількістю сторінок не американського автор

            //var book = context.Books.Where(x => x.Authors.Name == "R.S.Martin").Max(x => x.Pages);
            //var res6 = context.Books.Where(x => x.Pages == book);//треба добавити країну автора
            //foreach (var item in res6){    Console.WriteLine(item.Name);}

            ////           7. Вибрати автора, який має найменше книг в базі даних

            //var res7 = context.Authors.Where(x => x.Books.Count == (context.Authors.Select(y => y.Books.Count)).Min());
            //Console.WriteLine(res7);

            ////           8. Вибрати імена всіх авторів, крім американських, розташованих в алфавітном порядку

            //var res8 = context.Authors.Where(x => x.Name == "1").OrderBy(z=>z.Name);//треба добавити країну автора
            //foreach (var item in res8){    Console.WriteLine(item.Name);}

            ////            9. Вибрати країну, авторів якої є найбільше в базі

            //треба добавити країну автора
            #endregion
            #region
            int[] values1 = new int[5] { 1, 10, 5, 13, 4 };
            int[] values2 = new int[5] { 19, 1, 4, 9, 8 };
            ////1) Посчитать среднее значение четных элементов, которые больше 10.

            //var res1 = values1.Where(i => i >= 10 && i % 2 == 0).Average();
            //Console.WriteLine(res1);

            ////2) Выбрать только уникальные элементы из массивов values1 и values2.

            //var dist = values1.Concat(values2).Distinct();
            //foreach (var item in dist)   {     Console.WriteLine(item);       }

            ////3) Найти максимальный элемент массива values2, который есть в массиве values1.

            //var res3 = values1.Concat(values2);
            //var max = res3.Where(x => res3.Count(z=> z == x) > 1).Distinct().Max();
            //Console.WriteLine(max);

            ////4) Посчитать сумму элементов массивов values1 и values2, которые попадают в диапазон от 5 до 15.

            //var sum = values1.Concat(values2).Where(x => x > 5 && x < 10).Sum();
            //Console.WriteLine(sum);

            ////5) Отсортировать элементы массивов values1 и values2 по убыванию.

            //var sort = values1.Concat(values2).OrderByDescending(x => x);
            //foreach (var item in sort) {      Console.WriteLine(item);  }      
            #endregion
            #region
            //List<Good> goods1 = new List<Good>()
            //{
            //       new Good()         { Id = 1, Title = "Nokia 1100", Price = 450.99, Category = "Mobile" },
            //       new Good()         { Id = 2, Title = "Iphone 4", Price = 5000, Category = "Mobile" },
            //       new Good()         { Id = 3, Title = "Refregirator 5000", Price = 2555, Category = "Kitchen" },
            //       new Good()         { Id = 4, Title = "Mixer", Price = 150, Category = "Kitchen" },
            //       new Good()         { Id = 5, Title = "Magnitola", Price = 1499, Category = "Car" }
            //};
            //List<Good> goods2 = new List<Good>()
            //{       new Good()     { Id = 6, Title = "Samsung Galaxy", Price = 3100, Category = "Mobile" },
            //        new Good()     { Id = 7, Title = "Auto Cleaner", Price = 2300, Category = "Car" },
            //        new Good()     { Id = 8, Title = "Owen", Price = 700, Category = "Kitchen" },
            //        new Good()     { Id = 9, Title = "Siemens Turbo", Price = 3199, Category = "Mobile" },
            //        new Good()     { Id = 10, Title = "Lighter", Price = 150, Category = "Car" }
            //};
            ////Рассматривать как одну коллекцию

            //List<Good> goods = goods1.Concat(goods2).ToList();

            ////1) Выбрать товары категории Mobile, цена которых превышает 1000 грн.

            //var res1 = goods.Where(x => x.Category == "Mobile" && x.Price > 1000);
            //Console.WriteLine(res1);

            ////2) Вывести название и цену тех товаров, которые не относятся к категории Kitchen,
            ////цена которых превышает 1000 грн.

            //var res2 = goods.Where(x => x.Category != "Kitchen" && x.Price > 1000);
            //Print(res2);

            ////3) Вывести название товара и его категорию, который имеет максимальную цену.

            //var res3 = goods.Where(x => x.Price == goods.Select(z => z.Price).Max());
            //Console.WriteLine(res3);

            ////4) Вычислить среднее значение всех цен товаров.

            //var res4 = goods.Average(x => x.Price);
            //Console.WriteLine(res4);

            ////5) Вывести список категорий без повторений.

            //var res5 = goods.Select(x => x.Category).Distinct();
            //Print(res5);

            ////6) Вывести названия тех товаров, цены которых совпадают.

            //var res6 = goods.Where(x => goods.Count(z => z.Price == x.Price) > 1);
            //Print(res6);

            ////7) Вывести названия и категории товаров в алфавитном порядке, упорядоченных по
            ////названию.

            //var res7 = goods.OrderBy(x => x.Title);
            //Print(res7);

            ////8) Проверить, содержит ли категория Car товары, с ценой от 1000 до 2000 грн.

            //var res8 = goods.Where(x => x.Category == "Car" && (x.Price >= 1000 && x.Price <= 2000));
            //Print(res8);

            ////9) Посчитать суммарное количество товаров категорий Сar и Mobile.

            //var res9 = goods.Where(x => x.Category == "Car" || x.Category == "Mobile").Count();
            //Console.WriteLine(res9);

            ////10) Вывести список категорий и количество товаров каждой категории.

            //var res10 = goods.Select(x => x.Category).Distinct();
            //foreach (var item in res10)
            //{
            //    Console.WriteLine($"{item} = {goods.Where(x=>x.Category == item).Count()}");
            //}
            #endregion
        }

        private static void Print(IEnumerable ts)
        {
            foreach (var item in ts)
            {
                Console.WriteLine(item);
            }
        }

        class Good
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public double Price { get; set; }
            public string Category { get; set; }

            public override string ToString()
            {
                return $"{Title} {Price}  {Category}";
            }
        }
    }
}
