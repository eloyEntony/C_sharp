using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NP_Exam.Entityes
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int? ContactId { get; set; }
        public int? ChatId { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual Chat Chat { get; set; }

        //public virtual ICollection<User> Contacts { get; set; }
        public virtual ICollection<Chat> Chats { get; set; }

        public User()
        {
            //Contacts = new List<User>();
            Chats = new List<Chat>();
        }
    }
}
