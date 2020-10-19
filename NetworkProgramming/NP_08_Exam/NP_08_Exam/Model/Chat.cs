using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NP_08_Exam.Model
{
    public class Chat
    {
        public int Id { get; set; }
        public int? FirstUserId { get; set;}
        public int? SecondUserId { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        [ForeignKey(nameof(FirstUserId))]
        public virtual User FirstUser { get; set; }
        [ForeignKey(nameof(SecondUserId))]
        public virtual User SecondUser { get; set; }
        public Chat()
        {
            Messages = new List<Message>();
        }
    }
}
