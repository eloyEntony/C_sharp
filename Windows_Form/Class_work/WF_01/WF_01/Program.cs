using System.Drawing;
using System.Windows.Forms;

//Написати програму, яка міститиме дві кнопки: Increase Opacity, Decrease Opacity
//Перша при клікові буде збільшувати прозорість форми, друга - зменшувати

//------

//Написати програму "Впіймай кнопку". Кнопка при наведенні на неї курсора мишки буде міняти свою позицію на рандомну.
//Якщо користувач "спіймає" кнопку, програма має відобразити вікно привітання(MessageBox)

//------

//Програма(консольна) запитує користувача дані про форму:
//        --- Введіть ширину
//        --- Введіть висоту
//        --- Введіть заголовок
//        --- Введіть колір фону
//На основі відповідей користувача має створитись форма, що відповідає введеним параметрам

namespace WF_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Form form = new Form();
            form.Text = "Task # 1";

            Button button1 = new Button();
            button1.Text = "Increase Opacity";
            button1.Size = new Size(100, 40);
            button1.Top = 10;


            Button button2 = new Button();
            button2.Text = "Decrease Opacity";
            button2.Size = new Size(100, 40);
            button2.Top = 60;

            form.Controls.Add(button1);
            form.Controls.Add(button2);

            button1.MouseClick += Button1_MouseClick;
            button2.MouseClick += Button2_MouseClick;

            form.ShowDialog();
        }

        private static void Button2_MouseClick(object sender, MouseEventArgs e)
        {
            ((sender as Button).Parent as Form).Opacity += 0.1;
        }

        private static void Button1_MouseClick(object sender, MouseEventArgs e)
        {
            ((sender as Button).Parent as Form).Opacity -= 0.1;
        }
    }
}
