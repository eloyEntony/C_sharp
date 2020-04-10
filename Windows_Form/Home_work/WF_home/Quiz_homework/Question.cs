using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_homework
{
    class Question
    {
        string text_question;
        public bool reply;

        public Question(string text)
        {
            this.text_question = text; 
        }

        public override string ToString()
        {
            return $"{text_question}";
        }
        
    }
}
