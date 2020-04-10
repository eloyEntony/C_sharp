using System;
using System.Windows.Forms;

//Створити програму Вікторина(Тестування). Програма задає декілька питань користувачу, очікуючи відповіді типу Так-Ні.
//Програма видає результат проходження вікторини(тесту) :
//кількість правильних та загальне число відповідей(н-д, "правильних відповідей 2, всього питань  5")
//* Бажано створення класів
//Питання(Question)

//    текст питання(string)
//    відповідь(bool)

//Вікторина(Quiz)

//    список питань(List<Question>)
//    метод додавання питання(void AddQuestion(Question q))
//    метод запуску Тестування(void Run())

// Метод Run() запускає тестування, виводить кожне питання зі списку питань, аналізує відповіді на правильність
// та формує результат(кількість правильних)

namespace Quiz_homework
{
    public partial class Form1 : Form
    {
        Quiz quiz = new Quiz();

        public Form1()
        {
            InitializeComponent();
        }       

        private void Form1_Load(object sender, EventArgs e)
        {
            Question question0 = new Question("You is a man ? ");
            Question question1 = new Question("Do you have a name ? ");
            Question question2 = new Question("Your name is BOB ? ");
            Question question3 = new Question("Your name is definitely not BOB ? ");
            Question question4 = new Question("Are you sure ?");

            quiz.AddQuestion(question0);
            quiz.AddQuestion(question1);
            quiz.AddQuestion(question2);
            quiz.AddQuestion(question3);
            quiz.AddQuestion(question4);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;            
            btnNext_Click(sender, null);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {            
            quiz.Run(label1, radioButton1, radioButton2, label2);            
            if (radioButton1.Enabled == false)
            {
                panel1.Visible = true;
                btnStart.Enabled = false;                
            }
                
        }
        private void btnResult_Click(object sender, EventArgs e)
        {
            MessageBox.Show($" YES : {quiz.yes} \n NO : {quiz.no}");
        }
    }
}
