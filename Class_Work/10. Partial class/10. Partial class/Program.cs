using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 1. Class Factory, містить авто-властивість string Name, масив Departments[], масив Products[], метод string ReturnString(); 
 * 2. Class Department містить авто-властивість string Name, масив Employees[], метод string ReturnString(); 
 * 3. Class Employee містить авто-властивість string Name, авто-властивість string Surname, авто-властивість int Age, авто-властивість decimal Salary, метод string ReturnString(); 
 * 4. Class Product містить авто-властивість string Name, авто-властивість int Size, авто-властивість double Price, метод string ReturnString(); 
 * 5. Класи розмістити в окремих файлах з відповідними класами
========================
    1. Class Factory - модифікувати і перетворити на partial class. 
    2. Описання полів та оголошеня масиву Департаментів зробити в 1й частині (в першому файлі), 
            оголошення масиву Products[] та оголошення і реалізацію методу string ReturnString() в 2му. 
    3. Створти 4 partial метода: 
        a)void SetAvgSalary   - встановлення для відповідного приватного поля середньої ЗП по підприємству 
        b)void SetTotalSalary - встановлення для відповідного приватного поля сумарної ЗП 
        c)void SetGDP         - встановлення для відповідного приватного поля валового доходу на 1го працівника - сума вартості всіх товарів / на кількість працівників 
        d)void SetEmpCount    - встановлення для відповідного поля загальної кількості працюючих 
    4.Для отримання даних з відповідних приватних полів cтворити відповідні публічні інтерфейси-методи
    5.Оголошення часткових методів зробити в 1й частині, а реалізацію виконати в 2 частині класу (в іншому файлі) 
    6.Зміна структури класу Фабрика не повинна вплинути на описи інших класів 
    7.Змінити поле “Ім”я “ для департаменту на readonly, яке повинне ініціалізуватися у параметризованому конструкторі заданим строковим параметром. 
    8.Класи розмежовуюься окремими файлами.
*/

namespace _10.Partial_class
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new Factory("My FACTORY", 100, 200, 300, 10, 2);
            factory.Show_factory();
            factory.Show_depart();
        }
    }
}
