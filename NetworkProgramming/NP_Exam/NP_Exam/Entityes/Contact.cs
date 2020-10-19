using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NP_Exam.Entityes
{
    public class Contact
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public virtual ICollection<User> Contacts { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
        public Contact()
        {
            Contacts = new List<User>();
        }
    }
}
