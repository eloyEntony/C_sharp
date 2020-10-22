
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entityes
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        

        public virtual ICollection<UsersChat> UsersChats { get; set; }

        public User()
        {
            UsersChats = new List<UsersChat>();
        //    Chats = new List<Chat>();
        }

    }
}
