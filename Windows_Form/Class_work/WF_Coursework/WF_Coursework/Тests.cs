using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
/*Тестова система
Реалізувати програму для проходження тестів.
Вимоги:
Програма має працювати для БУДЬ-ЯКОГО тесту визначеної структури (може бути кнопка Open test, чи відповідний пункт меню)
На поточному кроці проходження має показуватись питання та можливі варіанти відповідей.
Після проходження останнього запитання -  має з'явитись кнопка Завершити, клік по ній
призводить до виводу результатів тестування.

 */
namespace WF_Coursework
{
    public partial class Тests : Form
    {
        Questions issue;
        List<Questions> test = new List<Questions>();

        List<string> alllist = new List<string>();
        RadioButton[] radioButton;
        CheckBox[] checkBox;
        string path;
        int l = 0;
        int size = 0;
        int questionsCount = 0;
        int counter = 0;
        int balu = 0;

        public Тests()
        {
            InitializeComponent();
            button2.Visible = false;
            button3.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            var dialogResult = of.ShowDialog();
            path = of.FileName;
            if (dialogResult == DialogResult.OK)
            {
                button2.Visible = true;
                button1.Visible = false;

                var lines = File.ReadAllLines(path);
                for (int i = 0; i < lines.Length; i++)
                {
                    alllist.Add(lines[i]); // зчитую всі строки

                    if (alllist[i].Contains('?'))
                        questionsCount++;
                }

                for (int i = 0; i < questionsCount; i++)
                {
                    if (alllist[l] == "")
                        l++;

                    if (alllist[l].Contains('?'))//шукаю запитання
                    {
                        try
                        {
                            issue = new Questions();
                            issue.question = alllist[l];
                            issue.type = alllist[++l]; //вказю тип відповідей
                            listBox1.Items.Add(issue.question); //додаю запитання в ліст

                            while (alllist[l] != "")
                            {
                                if (alllist[l].Contains('1'))
                                    issue.trueAnswer.Add(alllist[l].Trim(new char[] { '0', '1' }));

                                if (alllist[l].Contains('1') || alllist[l].Contains('0'))
                                    issue.answers.Add(alllist[l]);

                                l++;
                            }
                        }
                        catch { }
                        test.Add(issue);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Text = test[counter].question;
            CreateAnswers(counter);
            ++counter;
            button3.Visible = true;
            button1.Visible = false;
            button2.Visible = false;
        }
        private void CreateAnswers(int index)
        {
            try
            {
                if (test[index].type == "R")
                {
                    radioButton = new RadioButton[test[index].answers.Count];
                    for (int j = 0; j < test[index].answers.Count; j++)
                    {
                        radioButton[j] = new RadioButton();
                        radioButton[j].Name = "r" + index;
                        radioButton[j].Text = test[index].answers[j].Trim(new char[] { '0', '1' });
                        radioButton[j].Size = new Size(300, 17);
                        radioButton[j].Location = new Point(357, 70 + size);
                        radioButton[j].CheckedChanged += CheckedChanged;
                        this.Controls.Add(radioButton[j]);
                        size += 20;
                    }
                }

                if (test[index].type == "C")
                {
                    checkBox = new CheckBox[test[index].answers.Count];
                    for (int j = 0; j < test[index].answers.Count; j++)
                    {
                        checkBox[j] = new CheckBox();
                        checkBox[j].Name = "c" + index;
                        checkBox[j].Text = test[index].answers[j].Trim(new char[] { '0', '1' });
                        checkBox[j].Size = new Size(300, 17);
                        checkBox[j].Location = new Point(357, 70 + size);
                        checkBox[j].CheckedChanged += CheckedChanged;
                        this.Controls.Add(checkBox[j]);
                        size += 20;
                    }
                }
            }
            catch { }
           
        }
        private void DeleteAnswers(int index)
        {
            if (radioButton == null)
                return;
            size = 0;

            for (int i = 0; i < radioButton.Length; i++)
            {
                this.Controls.Remove(radioButton[i]);
            }
            
            if (checkBox == null)
                return;

            for (int i = 0; i < checkBox.Length; i++)
            {
                this.Controls.Remove(checkBox[i]);
            }
            
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (counter < test.Count)
            {                
                label2.Text = test[counter].question;
                DeleteAnswers(counter);
                CreateAnswers(counter);

                counter++;
            }
            else
                button3.Text = "RESULT";

            if (button3.Text == "RESULT")
            {
                label2.Text = "";
                DeleteAnswers(counter);
                MessageBox.Show($"{balu} / {questionsCount}  points", "RESULT");
            }
                
        }

        private void CheckAnswer(int index)
        {
            try
            {
                index--;
                if (test[index].type == "R")
                {
                    for (int i = 0; i < radioButton.Length; i++)
                    {
                        if (radioButton[i].Checked && radioButton[i].Text == test[index].trueAnswer[0])
                            balu++;
                    }
                }
            
                int tmp = 0;
                if (test[index].type == "C")
                {
                    for (int i = 0; i < checkBox.Length; i++)
                    {
                        if (checkBox[i].Checked)
                        {
                            for (int j = 0; j < test[index].trueAnswer.Count; j++)
                            {
                                if (checkBox[i].Text == test[index].trueAnswer[j])
                                    tmp++;
                            }
                        }
                    }
                    if (tmp == test[--index].trueAnswer.Count)
                        balu++;
                }
                
            }
            catch { }
            
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            CheckAnswer(counter);
        }

        
    }
}
