using DB.Entityes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class AppContext:DbContext
    {
        public AppContext():base("name = ContactContext")
        {

        }

        public DbSet<DB.Entityes.Chat> Chats { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UsersChat> UsersChats { get; set; }
        public DbSet<Message> Messages { get; set; }

    }
}
