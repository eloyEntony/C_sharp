using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NP_Exam.Entityes
{
    public class Message
    {
        public int Id { get; set; }
        public string MessageText { get; set; }
        public int? ChatId { get; set; }
        public virtual Chat Chat { get; set; }
    }
}
