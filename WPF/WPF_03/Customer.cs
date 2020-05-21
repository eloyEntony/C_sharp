using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_03
{
    [Serializable]
    public class Customer
    {
        public string Name { get; set; }
        public string Second_name { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public Customer()
        {

        }
        public Customer( string naem, string second, string email, string type)
        {
            this.Name = naem;
            this.Second_name = second;
            this.Email = email;
            this.Type = type;
        }

        public override string ToString()
        {
            return $" {Name}  {Second_name}  {Email}  {Type}";
        }
    }
}
