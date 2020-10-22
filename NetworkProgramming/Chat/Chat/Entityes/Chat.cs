using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entityes
{
    public class Chat
    {
        [Key]
        public int Id { get; set; }        
        public string Name { get; set; }
       
        public virtual ICollection <Message> Messages { get; set; }
        public virtual ICollection <UsersChat> UserChats { get; set; }

        public Chat()
        {
            this.Messages = new List<Message>();
            this.UserChats = new List<UsersChat>();          
        }
    }
}
