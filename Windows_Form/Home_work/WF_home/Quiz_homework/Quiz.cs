using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz_homework
{
    class Quiz
    {
        List<Question> questions = new List<Question>();
        public int yes { get; private set; } = 0;
        public int no { get; private set; } = 0;
        int index = 0;
        public void AddQuestion(Question q)
        {
            questions.Add(q);
        }

        public void Run(Label label, RadioButton rYes, RadioButton rNo, Label label2)
        {
            try
            {   
                if (rYes.Checked == true){
                    questions[index].reply = true;
                    yes++;
                    index++;                    
                }
                else if (rNo.Checked == true) {
                    questions[index].reply = false;
                    no++;
                    index++;
                }
                label2.Text = $" YES : {yes}  \n NO : {no}";

                label.Text = questions[index].ToString();               
                
            }
            catch (Exception)
            {                
                label2.Text = String.Empty;
                label.Text = label2.Text;
                MessageBox.Show($"You result\n YES : {yes} \n NO : {no}");
                rYes.Checked = false;
                rNo.Checked = false;
                rYes.Enabled = false;
                rNo.Enabled = false;
            }
        }
    }
}
